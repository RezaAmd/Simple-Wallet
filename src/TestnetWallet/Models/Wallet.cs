namespace TestnetWallet.Models
{
    internal class Wallet
    {
        public Wallet(string privateKey, decimal balance)
        {
            PrivateKey = privateKey;
            LastBalance = balance;
        }
        public string PrivateKey { get; set; }
        public decimal LastBalance { get; set; }
    }
}