namespace CouponManagementLLD
{
    public static class CouponFactory
    {
        public static Coupon Create(string code)
        {
            Coupon c = new(code);
            return c;
        }
    }
}