using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Eth.DTOs;
using NFTService.Blockchain;
using NFTService.ATBCoin.ContractDefinition;

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
            var message = new MintFunction
            {
                Amount = BigInteger.Parse(amount)
            };

            var receipt = await _sender.Coin.MintRequestAndWaitForReceiptAsync(message);

            var mintEvent = _sender.Coin.ContractHandler.GetEvent<TransferEventDTO>();
            var filterInput = mintEvent.CreateFilterInput(new BlockParameter(receipt.BlockNumber), BlockParameter.CreateLatest());
            var logs = await mintEvent.GetAllChangesAsync(filterInput);

            foreach (var log in logs)
            {
                Console.WriteLine("logs" + log.Event.From);
                Console.WriteLine("logs" + log.Event.To);
                Console.WriteLine("logs" + log.Event.Value);
                // TODO ось тут треба нарахувати монети, але я тупо не розумію як хендлити кому їх нараховувати
            }

            return receipt;
        }
    }
}