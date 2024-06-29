namespace CouponManagementLLD
{
    public class BatchStateMachine
    {
        private static readonly Dictionary<BatchStatus, List<BatchStatus>> stateTransitions = new() {
            { BatchStatus.CREATED, new List<BatchStatus>{ BatchStatus.APPROVED} },
            { BatchStatus.APPROVED, new List<BatchStatus>{ BatchStatus.ACTIVE, BatchStatus.SUSPENDED, BatchStatus.TERMINATED } },
            { BatchStatus.ACTIVE, new List<BatchStatus>{ BatchStatus.SUSPENDED, BatchStatus.TERMINATED } },
            { BatchStatus.SUSPENDED, new List<BatchStatus>{ BatchStatus.ACTIVE } },
        };

        public static bool IsTransitionFeasible(Batch batch, BatchStatus status)
        {
            if (!stateTransitions.ContainsKey(batch.Status)) return false;
            return stateTransitions[batch.Status].Contains(status);
        }
    }
}
