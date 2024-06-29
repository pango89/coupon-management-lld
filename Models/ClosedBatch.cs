
namespace CouponManagementLLD
{
    public class ClosedBatch : Batch
    {
        public ClosedBatch(string id, CouponType couponType, string distributor, Period validityPeriod) : base(id, couponType, distributor, validityPeriod)
        {
        }

        private static readonly object lockObject = new();

        public override Coupon GrantCoupon()
        {
            Coupon coupon;
            lock (lockObject)
            {
                if (Status != BatchStatus.ACTIVE)
                    throw new InactiveBatchException();

                if (this.AvailableCouponCodes.Count == 0)
                    throw new BatchExhaustedException();

                string code = AvailableCouponCodes.GetEnumerator().Current;
                coupon = CouponFactory.Create(code);
                AvailableCouponCodes.Remove(code);
                GrantedCouponCodes.Add(code);
            }

            return coupon;
        }
    }
}