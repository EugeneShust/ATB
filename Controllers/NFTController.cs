using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Eth.DTOs;
using NFTService.Blockchain;
using NFTService.ATBToken.ContractDefinition;

namespace NFTService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NFTController : ControllerBase
    {
        private readonly ILogger<NFTController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITransactionSender _sender;


        public NFTController(ILogger<NFTController> logger, IConfiguration configuration, ITransactionSender sender)
        {
            _sender = sender;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("MintNFT")]
        public async Task<TransactionReceipt> MintNFT(string genes, byte charge)
        {
            try 
            { 
                var message = new MintFunction
                {
                    Genes = BigInteger.Parse(genes),
                    Charge = charge
                };

                var mintEvent = _sender.NFT.ContractHandler.GetEvent<WasBornEventDTO>();

                var receipt = await _sender.NFT.MintRequestAndWaitForReceiptAsync(message);
                
                var filterInput = mintEvent.CreateFilterInput(new BlockParameter(receipt.BlockNumber), BlockParameter.CreateLatest());
                var logs = await mintEvent.GetAllChangesAsync(filterInput);

                foreach (var log in logs)
                {
                    Console.WriteLine("logs" + log.Event.TokenId);
                    Console.WriteLine("logs" + log.Event.Parent1);
                    Console.WriteLine("logs" + log.Event.Parent2);
                    Console.WriteLine("logs" + log.Event.Genes);
                    // TODO ось тут треба виконати код на прив'язку токена(ИД) до картинки на віддаленому сервері
                    // Отримати на одну транзакцію один івент неможливо, тільки додаткові фільтрі, транзакція не повертає значення.
                    Thread.Sleep(1500);
                }

                return receipt;
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                throw;
            }
        }

        [HttpPost("Breeding")]
        public async Task<TransactionReceipt> Breeding(string tokenId1, string tokenId2)
        {
            var message = new BreedingFunction
            {
                Token1 = BigInteger.Parse(tokenId1),
                Token2 = BigInteger.Parse(tokenId1)
            };

            var receipt = await _sender.NFT.BreedingRequestAndWaitForReceiptAsync(message);

            var mintEvent = _sender.NFT.ContractHandler.GetEvent<WasBornEventDTO>();
            var filterInput = mintEvent.CreateFilterInput(new BlockParameter(receipt.BlockNumber), BlockParameter.CreateLatest());
            var logs = await mintEvent.GetAllChangesAsync(filterInput);

            foreach (var log in logs)
            {
                Console.WriteLine("logs" + log.Event.TokenId);
                Console.WriteLine("logs" + log.Event.Parent1);
                Console.WriteLine("logs" + log.Event.Parent2);
                Console.WriteLine("logs" + log.Event.Genes);
                // TODO ось тут треба виконати код на прив'язку токена(ИД) до картинки на віддаленому сервері
                // Отримати на одну транзакцію один івент неможливо, тільки додаткові фільтрі, транзакція не повертає значення.
            }

            return receipt;
        }

        [HttpPost("ChargeNFT")]
        public async Task<TransactionReceipt> ChargeNFT(string tokenId1, byte value)
        {
            var message = new ChargeFunction
            {
                TokenId = BigInteger.Parse(tokenId1),
                Value = value
            };

            var receipt = await _sender.NFT.ChargeRequestAndWaitForReceiptAsync(message);

            var mintEvent = _sender.NFT.ContractHandler.GetEvent<ChargedEventDTO>();
            var filterInput = mintEvent.CreateFilterInput(new BlockParameter(receipt.BlockNumber), BlockParameter.CreateLatest());
            var logs = await mintEvent.GetAllChangesAsync(filterInput);

            foreach (var log in logs)
            {
                Console.WriteLine("logs" + log.Event.TokenId);
                Console.WriteLine("logs" + log.Event.Charge);
                // TODO оце подія, за рахунок якої треба підвищити заряд, але логіку виключення дубликатів треба писати на сервері окремо
            }

            return receipt;
        }


        [HttpPost("TestParallel")]
        public async Task<TransactionReceipt> TestParallel()
        {
            Parallel.Invoke(
                () => MintNFT("626837621154801616088980922659877168609154386318304496692374110716999053", 2),
                () => MintNFT("626837621154801616088980922659877168609154386318304496692374110716999053", 2),
                () => MintNFT("626837621154801616088980922659877168609154386318304496692374110716999053", 2),
                () => MintNFT("626837621154801616088980922659877168609154386318304496692374110716999053", 2));

            Thread.Sleep(20000);

            return new TransactionReceipt();
        }
    }
}