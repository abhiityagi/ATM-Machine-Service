using System.ComponentModel.DataAnnotations;

namespace ATMSoftware.API.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public long RecipientAccountNumber { get; set; }
        public string BranchName { get; set; }
        public float TransferAmount { get; set; }
    }
}
