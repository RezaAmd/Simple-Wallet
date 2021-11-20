using Newtonsoft.Json;
using TestnetWallet.Models;

namespace TestnetWallet.Services
{
    internal class Context
    {
        public async Task SaveAsync(Wallet wallet)
        {
            await File.WriteAllTextAsync("Source.txt", JsonConvert.SerializeObject(wallet));
        }

        public async Task<Wallet> RestoreAsync(CancellationToken cancellationToken = default)
        {
            string serialzedWallet = await File.ReadAllTextAsync("Source.txt", cancellationToken);
            return JsonConvert.DeserializeObject<Wallet>(serialzedWallet);
        }
    }
}
