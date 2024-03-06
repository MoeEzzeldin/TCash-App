namespace TenmoClient.Models
{
    public class Account
    {
        private int AccountId { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; } = 1000M;
    }
}
