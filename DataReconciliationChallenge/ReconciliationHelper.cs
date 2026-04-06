namespace DataReconciliationChallenge
{
    public static class ReconciliationHelper
    {
        public static ReconciliationResult Reconcile(List<CustomerRecord> crm, List<CustomerRecord> billing)
        {
            var dictionary = new Dictionary<string, Identifier>();

            foreach (var crmRecord in crm)
            {
                dictionary[crmRecord.CustomerId] = new Identifier(
                    ReconcileType.Unique,
                    "CRM",
                    crmRecord
                );
            }

            var result = new ReconciliationResult();

            foreach (var billingRecord in billing)
            {
                if (dictionary.TryGetValue(billingRecord.CustomerId, out var existingRecord))
                {
                    var crmRecord = existingRecord.CustomerRecord;
                    var differences = GetDifferences(crmRecord, billingRecord);

                    if (differences.Count == 0)
                    {
                        result.Matched.Add(crmRecord);
                    }
                    else
                    {
                        result.Conflicts.Add(new ConflictRecord(billingRecord.CustomerId, differences));
                    }

                    dictionary.Remove(billingRecord.CustomerId);
                }
                else
                {
                    result.OnlyInBilling.Add(billingRecord);
                }
            }

            foreach (var remainingRecord in dictionary.Values)
            {
                result.OnlyInCrm.Add(remainingRecord.CustomerRecord);
            }

            return result;
        }

        private static List<string> GetDifferences(CustomerRecord crmRecord, CustomerRecord billingRecord)
        {
            var differences = new List<string>();

            if (crmRecord.Name != billingRecord.Name)
                differences.Add($"Name (CRM: {crmRecord.Name} vs Billing: {billingRecord.Name})");

            if (crmRecord.Email != billingRecord.Email)
                differences.Add($"Email (CRM: {crmRecord.Email} vs Billing: {billingRecord.Email})");

            if (crmRecord.Tier != billingRecord.Tier)
                differences.Add($"Tier (CRM: {crmRecord.Tier} vs Billing: {billingRecord.Tier})");

            return differences;
        }
    }
}
