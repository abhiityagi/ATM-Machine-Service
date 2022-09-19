namespace ATMSoftware.API.Models
{
    public class CustomerData
    {
        public Guid Id { get; set; }
        public long AccountNumber { get; set; }
        public string FullName { get; set; }
        public string BranchName { get; set; }
        public float TotalBalance { get; set; }
        public int CardPin { get; set; }
    }
}
