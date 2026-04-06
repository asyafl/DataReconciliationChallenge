namespace DataReconciliationChallenge
{
    public class Identifier
    {
        public ReconcileType ReconcileType { get; set; }
        public string SourceSystem { get; set; }
        public CustomerRecord CustomerRecord { get; set; }

        public Identifier(ReconcileType reconcileType, string sourceSystem, CustomerRecord customerRecord)
        {
            ReconcileType = reconcileType;
            SourceSystem = sourceSystem;
            CustomerRecord = customerRecord;
        }
    }
}
