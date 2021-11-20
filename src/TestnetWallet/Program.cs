using BlockCypher;
using NBitcoin;
using TestnetWallet.Services;

// Import
WalletService walletService = new(new Context());
var wallet = await walletService.InitializingWalletAsync();

// Address
string address = wallet.PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.TestNet).ToString();
Console.WriteLine("\nAddress: " + address + "\n");

var explorer = new Blockcypher("6277183c7085424b9913ee3e3d955332", Endpoint.BtcTest3);
var addressBalance = await explorer.GetBalanceForAddress(address);
decimal balance = addressBalance.Balance.Btc;

var context = new Context();
await context.SaveAsync(new(wallet.ToString(), balance));

Console.WriteLine("Balance: " + balance.ToString() + " BTC\n");
Console.WriteLine("--------------------");
//cN2Xvq3eqzgYfCgyXj2wdoTG95pQz8zNmY1TN3cKDsm1vVK6axyF
//tb1q03hfekx0w9n2nj3ac9d20x47ajj576xg53tv90