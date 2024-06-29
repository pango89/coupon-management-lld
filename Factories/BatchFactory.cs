namespace CouponManagementLLD
{
    public static class BatchFactory
    {
        public static Batch Create(CouponType couponType, string id, string distributor, DateTime start, DateTime end, int maxAllowedGrants)
        {
            if (couponType == CouponType.OPEN)
                return new OpenBatch(id, couponType, distributor, new Period(start, end), maxAllowedGrants);
            if (couponType == CouponType.CLOSED)
                return new ClosedBatch(id, couponType, distributor, new Period(start, end));

            throw new InvalidBatchException();
        }
    }
}