namespace CouponManagementLLD
{
    public class BatchService
    {
        public BatchService()
        {
            this.batchRepository = new BatchRepository();
            this.couponRepository = new CouponRepository();
        }

        private readonly BatchRepository batchRepository;
        private readonly CouponRepository couponRepository;

        public Batch CreateBatch(CouponType couponType, string id, string distributor, DateTime start, DateTime end, int maxAllowedGrants)
        {
            if (start >= end)
                throw new Exception();

            Batch batch = BatchFactory.Create(couponType, id, distributor, start, end, maxAllowedGrants);
            this.batchRepository.AddBatch(batch);
            return batch;
        }

        public void UpdateBatchState(string batchId, BatchStatus state) => this.batchRepository.GetBatchById(batchId).UpdateStateTo(state);
        public Batch GetBatch(string batchId) => this.batchRepository.GetBatchById(batchId);

        public void IngestCouponCodes(string batchId, HashSet<string> couponCodes) => this.batchRepository.GetBatchById(batchId).AddCouponCodes(couponCodes);

        public Coupon GrantCoupon(string batchId) => this.batchRepository.GetBatchById(batchId).GrantCoupon();
        public Coupon GetCouponByCode(string code) => this.couponRepository.GetCouponByCode(code);
    }
}