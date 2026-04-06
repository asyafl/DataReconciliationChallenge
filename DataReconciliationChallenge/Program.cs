using DataReconciliationChallenge;

class Solution
{
    static void Main(string[] args)
    {
        var crmRecords = new List<CustomerRecord>
        {
            new("C001", "Alice Johnson", "alice@email.com", "Premium"),
            new("C002", "Bob Smith", "bob@email.com", "Basic"),
            new("C003", "Charlie Brown", "charlie@email.com", "Premium"),
            new("C005", "Eve Davis", "eve@email.com", "Basic"),
        };

        var billingRecords = new List<CustomerRecord>
        {
            new("C001", "Alice Johnson", "alice@email.com", "Premium"),
            new("C002", "Bob Smith", "bob.smith@newmail.com", "Premium"),
            new("C003", "Charlie Brown", "charlie@email.com", "Premium"),
            new("C004", "Diana Prince", "diana@email.com", "Basic"),
        };

        var result = ReconciliationHelper.Reconcile(crmRecords, billingRecords);

        Console.WriteLine($"Matched: {result.Matched.Count}");
        foreach (var m in result.Matched)
            Console.WriteLine($"  {m.CustomerId} - {m.Name}");

        Console.WriteLine($"\nConflicts: {result.Conflicts.Count}");
        foreach (var c in result.Conflicts)
            Console.WriteLine($"  {c.CustomerId}: {string.Join(", ", c.Differences)}");

        Console.WriteLine($"\nOnly in CRM: {result.OnlyInCrm.Count}");
        foreach (var r in result.OnlyInCrm)
            Console.WriteLine($"  {r.CustomerId} - {r.Name}");

        Console.WriteLine($"\nOnly in Billing: {result.OnlyInBilling.Count}");
        foreach (var r in result.OnlyInBilling)
            Console.WriteLine($"  {r.CustomerId} - {r.Name}");
    }


}