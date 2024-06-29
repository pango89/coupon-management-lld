namespace CouponManagementLLD
{
    public class CouponRepository
    {
        public CouponRepository()
        {
            this.coupons = new();
        }

        private Dictionary<string, Coupon> coupons;

        public void AddCoupon(Coupon coupon)
        {
            if (this.coupons.ContainsKey(coupon.Code))
                throw new DuplicateCouponException();
            this.coupons.Add(coupon.Code, coupon);
        }

        public Coupon GetCouponByCode(string code)
        {
            if (this.coupons.ContainsKey(code))
                return this.coupons[code];
            throw new InvalidCouponException();
        }
    }
}