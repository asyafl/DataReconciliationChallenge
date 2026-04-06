namespace DataReconciliationChallenge
{
    public class ReconciliationResult
    {
        public List<CustomerRecord> Matched { get; set; } = new();
        public List<ConflictRecord> Conflicts { get; set; } = new();
        public List<CustomerRecord> OnlyInCrm { get; set; } = new();
        public List<CustomerRecord> OnlyInBilling { get; set; } = new();
    }

}
