namespace CouponManagementLLD
{
    public class Coupon
    {
        public Coupon(string code)
        {
            Code = code;
            Status = CouponStatus.GRANTED;
        }

        public string Code { get; set; }
        public CouponStatus Status { get; set; }
    }
}