using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Eth.DTOs;
using NFTService.Blockchain;
using NFTService.ATBToken.ContractDefinition;
using Nethereum.Contracts;
using Nethereum.Util;

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
                var request = new MintFunction
                {
                    Genes = BigInteger.Parse(genes),
                    Charge = charge,
                    Nonce = await _sender.Account.NonceService.GetNextNonceAsync()
                };
             
                var receipt = await _sender.NFT.MintRequestAndWaitForReceiptAsync(request);
                
                var logs = receipt.DecodeAllEvents<WasBornEventDTO>();

                foreach (var log in logs)
                {
                    _logger.LogInformation("TokenId:" + log.Event.TokenId);
                    _logger.LogInformation("Parent1:" + log.Event.Parent1);
                    _logger.LogInformation("Parent2:" + log.Event.Parent2);
                    _logger.LogInformation("Genes:" + log.Event.Genes);

                    // TODO ось тут треба виконати код на прив'язку токена(ИД) до картинки на віддаленому сервері
                }

                return receipt;
            }
            catch (Exception E)
            {
                _logger.LogError("NFTController.Mint:", E);
                throw;
            }
        }

        [HttpPost("Breeding")]
        public async Task<TransactionReceipt> Breeding(string tokenId1, string tokenId2)
        {
            try
            {
                var request = new BreedingFunction
                {
                    Token1 = BigInteger.Parse(tokenId1),
                    Token2 = BigInteger.Parse(tokenId2),
                    Nonce = await _sender.Account.NonceService.GetNextNonceAsync()
                };


                // Ціна за одиницю газу - наприклад 38881 газу коштує транзакція => 38881*0.00000025
                request.GasPrice = Nethereum.Web3.Web3.Convert.ToWei(75, UnitConversion.EthUnit.Gwei);
                var estimateGas = await _sender.NFT.ContractHandler.EstimateGasAsync(request);
                // тут збільшено газ за рахунок того, що точна оцінка газу неможлива так як не відомо як само буде прорахований рандом
                // це значення треба встановити імпірично. Не вірна оцінка спричинить використання газу і транзакція завершиться фейлом(шрощі за транзакцію сгорять).
                // в будь якому разі на сервері треба обробити помилку вичерпаного газу і запустити транзакцію знов.
                request.Gas = estimateGas.Value + 10000; 

                var receipt = await _sender.NFT.BreedingRequestAndWaitForReceiptAsync(request);

                var logs = receipt.DecodeAllEvents<WasBornEventDTO>();

                foreach (var log in logs)
                {
                    _logger.LogInformation("TokenId:" + log.Event.TokenId);
                    _logger.LogInformation("Parent1:" + log.Event.Parent1);
                    _logger.LogInformation("Parent2:" + log.Event.Parent2);
                    _logger.LogInformation("Genes:" + log.Event.Genes);

                    // TODO ось тут треба виконати код на прив'язку токена(ИД) до картинки на віддаленому сервері
                }

                return receipt;
            }
            catch (Exception E)
            {
                _logger.LogError("NFTController.Breeding", E);
                throw;
            }
        }

        [HttpPost("ChargeNFT")]
        public async Task<TransactionReceipt> ChargeNFT(string tokenId1, byte value)
        {
            try
            {
                var request = new ChargeFunction
                {
                    TokenId = BigInteger.Parse(tokenId1),
                    Value = value,
                    Nonce = await _sender.Account.NonceService.GetNextNonceAsync()
                };


                request.GasPrice = Nethereum.Web3.Web3.Convert.ToWei(75, UnitConversion.EthUnit.Gwei);
                var estimateGas = await _sender.NFT.ContractHandler.EstimateGasAsync(request);
                // тут збільшено газ за рахунок того, що точна оцінка газу неможлива так як не відомо як само буде прорахований рандом
                // це значення треба встановити імпірично. Не вірна оцінка спричинить використання газу і транзакція завершиться фейлом(шрощі за транзакцію сгорять).
                // в будь якому разі на сервері треба обробити помилку вичерпаного газу і запустити транзакцію знов.
                request.Gas = estimateGas.Value + 10000;

                var receipt = await _sender.NFT.ChargeRequestAndWaitForReceiptAsync(request);

                var logs = receipt.DecodeAllEvents<ChargedEventDTO>();

                foreach (var log in logs)
                {
                    _logger.LogInformation("TokenId:" + log.Event.TokenId);
                    _logger.LogInformation("Charge" + log.Event.Charge);
                    // TODO ось тут треба закинути монети на рахунок гравця
                }

                return receipt;
            }
            catch (Exception E)
            {
                _logger.LogError("NFTController.Charge", E);
                throw;
            }
        }
    }
}