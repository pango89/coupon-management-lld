namespace CouponManagementLLD
{
    public abstract class Batch
    {
        protected Batch(string id, CouponType couponType, string distributor, Period validityPeriod)
        {
            Id = id;
            Status = BatchStatus.CREATED;
            CouponType = couponType;
            Distributor = distributor;
            AvailableCouponCodes = new HashSet<string>();
            GrantedCouponCodes = new HashSet<string>();
            ValidityPeriod = validityPeriod;
        }

        public string Id { get; set; }
        public CouponType CouponType { get; set; }
        public string Distributor { get; set; }
        public HashSet<string> AvailableCouponCodes { get; set; }
        public HashSet<string> GrantedCouponCodes { get; set; }
        public Period ValidityPeriod { get; set; }
        public BatchStatus Status { get; set; }

        public void AddCouponCodes(HashSet<string> couponCodes) => this.AvailableCouponCodes.UnionWith(couponCodes);
        public abstract Coupon GrantCoupon();
        public void UpdateStateTo(BatchStatus state)
        {
            if (!BatchStateMachine.IsTransitionFeasible(this, state))
                throw new InvalidStateTransitionException();

            this.Status = state;
        }

        public bool IsValid()
        {
            DateTime now = DateTime.Now;
            return this.ValidityPeriod.Start <= now && now < this.ValidityPeriod.End;
        }
    }
}