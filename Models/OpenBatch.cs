namespace CouponManagementLLD
{
    public class OpenBatch : Batch
    {
        public OpenBatch(string id, CouponType couponType, string distributor, Period validityPeriod, int maxAllowedGrants) : base(id, couponType, distributor, validityPeriod)
        {
            MaxAllowedGrants = maxAllowedGrants;
            CurrentGrantedCount = 0;
        }

        public int MaxAllowedGrants { get; set; }
        public int CurrentGrantedCount { get; set; }
        private static readonly object lockObject = new();

        public override Coupon GrantCoupon()
        {
            Coupon coupon;
            lock (lockObject)
            {
                if (CurrentGrantedCount >= MaxAllowedGrants)
                    throw new BatchExhaustedException();

                if (Status != BatchStatus.ACTIVE)
                    throw new InactiveBatchException();

                string code = AvailableCouponCodes.GetEnumerator().Current;
                coupon = CouponFactory.Create(code);
                AvailableCouponCodes.Remove(code);
                GrantedCouponCodes.Add(code);

                CurrentGrantedCount++;
            }

            return coupon;
        }
    }
}