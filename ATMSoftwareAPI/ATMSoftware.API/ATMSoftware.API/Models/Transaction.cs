namespace ATMSoftware.API.Models
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public int Pin { get; set; }
        public long RecipientAccountNumber { get; set; }
        public string BranchName { get; set; }
        public float AmountTransfer { get; set; }
    }
}