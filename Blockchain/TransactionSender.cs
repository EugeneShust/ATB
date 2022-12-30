using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NFTService.ATBToken;
using NFTService.ATBCoin;

namespace NFTService.Blockchain
{
    public interface ITransactionSender
    {
        ATBTokenService NFT { get; }
        ATBCoinService Coin { get; }
    }

    public class TransactionSender : ITransactionSender
    {
        private readonly Web3 web3;
        private readonly ILogger<TransactionSender> _logger;
        private readonly IConfiguration _configuration;

        public ATBTokenService NFT { get; private set; }
        public ATBCoinService Coin { get; private set; }

        public TransactionSender(ILogger<TransactionSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            web3 = new Web3(new Account(_configuration["ACCOUNT_PRIVATE_KEY"]), _configuration["NETWORK"]);

            NFT = new ATBTokenService(web3, _configuration["NFT_CONTRACT_ADDRESS"]);
            Coin = new ATBCoinService(web3, _configuration["COIN_CONTRACT_ADDRESS"]);
            //NFTContract = web3.Eth.GetContract(abi, receipt.ContractAddress);
        }
    }
}
