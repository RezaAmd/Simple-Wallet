using NBitcoin;

namespace TestnetWallet.Services
{
    internal class WalletService
    {
        private readonly Context context;
        public WalletService(Context _context)
        {
            context = _context;
        }

        public async Task<BitcoinSecret> InitializingWalletAsync(CancellationToken cancellationToken = default)
        {
            var restoreWallet = await context.RestoreAsync(cancellationToken);
            if(restoreWallet != null)
            {
                return new BitcoinSecret(restoreWallet.PrivateKey, Network.TestNet);
            }
            var newWallet = new Key().GetWif(Network.TestNet);
            await context.SaveAsync(new(newWallet.ToString(), 0));
            return newWallet;
        }
    }
}