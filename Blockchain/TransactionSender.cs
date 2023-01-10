using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NFTService.ATBToken;
using NFTService.ATBCoin;
using Nethereum.Contracts;
using Nethereum.RPC.NonceServices;

namespace NFTService.Blockchain
{
    public interface ITransactionSender
    {
        ATBTokenService NFT { get; }
        ATBCoinService Coin { get; }
        Web3 Web3 { get; }
        Account Account { get; }
    }

    public class TransactionSender : ITransactionSender
    {
        private readonly ILogger<TransactionSender> _logger;
        private readonly IConfiguration _configuration;
        public Account Account { get; private set; }
        public Web3 Web3 { get; private set; }
        public ATBTokenService NFT 
        { 
            get 
            { 
                return new ATBTokenService(Web3, _configuration["NFT_CONTRACT_ADDRESS"]);
            } 
        }

        public ATBCoinService Coin 
        { 
            get
            { 
                return new ATBCoinService(Web3, _configuration["COIN_CONTRACT_ADDRESS"]);
            }
        }

        public TransactionSender(ILogger<TransactionSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            Account = new Account(_configuration["ACCOUNT_PRIVATE_KEY"]);
            Web3 = new Web3(Account, _configuration["NETWORK"]);
            Account.NonceService = new InMemoryNonceService(Account.Address, Web3.Client);

            
        }
    }
}
