namespace CouponManagementLLD
{
    public class BatchRepository
    {
        public BatchRepository()
        {
            this.batches = new();
        }

        private readonly Dictionary<string, Batch> batches;

        public void AddBatch(Batch batch)
        {
            if (this.batches.ContainsKey(batch.Id))
                throw new DuplicateBatchException();
            this.batches.Add(batch.Id, batch);
        }

        public Batch GetBatchById(string id)
        {
            if (this.batches.ContainsKey(id))
                return this.batches[id];
            throw new InvalidBatchException();
        }
    }
}