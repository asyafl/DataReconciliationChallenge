# DataReconciliationChallenge

 * Data Reconciliation Challenge
 *
 * We have customer data from two sources — a CRM system and a billing system.
 * Both have records keyed by CustomerId, but sometimes they disagree on field
 * values, and sometimes one source has records the other doesn't.
 *
 * Your task: Implement the Reconcile method that compares both lists and
 * produces a report with four categories:
 *   - Matched: same CustomerId, all fields identical
 *   - Conflicts: same CustomerId, but one or more fields differ
 *   - Only in CRM: exists in CRM but not in billing
 *   - Only in Billing: exists in billing but not in CRM
 */

 /*
 * Expected output:
 *
 * Matched: 2
 *   C001 - Alice Johnson
 *   C003 - Charlie Brown
 *
 * Conflicts: 1
 *   C002: Email (CRM: bob@email.com vs Billing: bob.smith@newmail.com), Tier (CRM: Basic vs Billing: Premium)
 *
 * Only in CRM: 1
 *   C005 - Eve Davis
 *
 * Only in Billing: 1
 *   C004 - Diana Prince
 */