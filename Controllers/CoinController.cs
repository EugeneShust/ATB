using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Eth.DTOs;
using NFTService.Blockchain;
using NFTService.ATBCoin.ContractDefinition;
using Nethereum.Contracts;
using Nethereum.Util;
using Nethereum.RPC.NonceServices;

namespace NFTService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinController : ControllerBase
    {
        private readonly ILogger<NFTController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITransactionSender _sender;


        public CoinController(ILogger<NFTController> logger, IConfiguration configuration, ITransactionSender sender)
        {
            _sender = sender;
            _logger = logger;
            _configuration = configuration;

        }

        [HttpPost("mint")]
        public async Task<TransactionReceipt> Mint(string amount)
        {
            try
            {
                var mint = new MintFunction
                {
                    Amount = BigInteger.Parse(amount),
                    Nonce = await _sender.Account.NonceService.GetNextNonceAsync()
                };

                // скільки газу коштує транзакція
                //mint.Gas = await _sender.Coin.ContractHandler.EstimateGasAsync(mint);

                // Ціна за одиницю газу - наприклад 38881 газу коштує транзакція => 38881*0.00000025
                //mint.GasPrice = Nethereum.Web3.Web3.Convert.ToWei(25, UnitConversion.EthUnit.Gwei);

                // mint.MaxFeePerGas = Nethereum.Web3.Web3.Convert.ToWei(25, UnitConversion.EthUnit.Gwei);

                // надбавка майнеру для швидшої обробки транзакції
                // mint.MaxPriorityFeePerGas = Nethereum.Web3.Web3.Convert.ToWei(25, UnitConversion.EthUnit.Gwei);

                var receipt = await _sender.Coin.MintRequestAndWaitForReceiptAsync(mint);
                
                var eventLogs = receipt.DecodeAllEvents<TransferEventDTO>();
  
                foreach (var log in eventLogs)
                {
                    _logger.LogInformation("From:" + log.Event.From);
                    _logger.LogInformation("To:" + log.Event.To);
                    _logger.LogInformation("Value:" + log.Event.Value);

                    // TODO ось тут треба нарахувати монети на балланс користувача.
                }

                return receipt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}