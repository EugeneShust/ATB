using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using NFTService.ATBToken.ContractDefinition;

namespace NFTService.ATBToken
{
    public partial class ATBTokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ATBTokenDeployment aTBTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ATBTokenDeployment>().SendRequestAndWaitForReceiptAsync(aTBTokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ATBTokenDeployment aTBTokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ATBTokenDeployment>().SendRequestAsync(aTBTokenDeployment);
        }

        public static async Task<ATBTokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ATBTokenDeployment aTBTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, aTBTokenDeployment, cancellationTokenSource);
            return new ATBTokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ATBTokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public ATBTokenService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BreedingRequestAsync(BreedingFunction breedingFunction)
        {
             return ContractHandler.SendRequestAsync(breedingFunction);
        }

        public Task<TransactionReceipt> BreedingRequestAndWaitForReceiptAsync(BreedingFunction breedingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(breedingFunction, cancellationToken);
        }

        public Task<string> BreedingRequestAsync(BigInteger token1, BigInteger token2)
        {
            var breedingFunction = new BreedingFunction();
                breedingFunction.Token1 = token1;
                breedingFunction.Token2 = token2;
            
             return ContractHandler.SendRequestAsync(breedingFunction);
        }

        public Task<TransactionReceipt> BreedingRequestAndWaitForReceiptAsync(BigInteger token1, BigInteger token2, CancellationTokenSource cancellationToken = null)
        {
            var breedingFunction = new BreedingFunction();
                breedingFunction.Token1 = token1;
                breedingFunction.Token2 = token2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(breedingFunction, cancellationToken);
        }

        public Task<string> ChargeRequestAsync(ChargeFunction chargeFunction)
        {
             return ContractHandler.SendRequestAsync(chargeFunction);
        }

        public Task<TransactionReceipt> ChargeRequestAndWaitForReceiptAsync(ChargeFunction chargeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(chargeFunction, cancellationToken);
        }

        public Task<string> ChargeRequestAsync(BigInteger tokenId, byte value)
        {
            var chargeFunction = new ChargeFunction();
                chargeFunction.TokenId = tokenId;
                chargeFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(chargeFunction);
        }

        public Task<TransactionReceipt> ChargeRequestAndWaitForReceiptAsync(BigInteger tokenId, byte value, CancellationTokenSource cancellationToken = null)
        {
            var chargeFunction = new ChargeFunction();
                chargeFunction.TokenId = tokenId;
                chargeFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(chargeFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(BigInteger genes, byte charge)
        {
            var mintFunction = new MintFunction();
                mintFunction.Genes = genes;
                mintFunction.Charge = charge;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(BigInteger genes, byte charge, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.Genes = genes;
                mintFunction.Charge = charge;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> ContractURIQueryAsync(ContractURIFunction contractURIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractURIFunction, string>(contractURIFunction, blockParameter);
        }

        
        public Task<string> ContractURIQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractURIFunction, string>(null, blockParameter);
        }

        public Task<string> GetApprovedQueryAsync(GetApprovedFunction getApprovedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApprovedFunction = new GetApprovedFunction();
                getApprovedFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        public Task<string> GetTrustedForwarderQueryAsync(GetTrustedForwarderFunction getTrustedForwarderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTrustedForwarderFunction, string>(getTrustedForwarderFunction, blockParameter);
        }

        
        public Task<string> GetTrustedForwarderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTrustedForwarderFunction, string>(null, blockParameter);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Owner = owner;
                isApprovedForAllFunction.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public Task<bool> IsTrustedForwarderQueryAsync(IsTrustedForwarderFunction isTrustedForwarderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsTrustedForwarderFunction, bool>(isTrustedForwarderFunction, blockParameter);
        }

        
        public Task<bool> IsTrustedForwarderQueryAsync(string forwarder, BlockParameter blockParameter = null)
        {
            var isTrustedForwarderFunction = new IsTrustedForwarderFunction();
                isTrustedForwarderFunction.Forwarder = forwarder;
            
            return ContractHandler.QueryAsync<IsTrustedForwarderFunction, bool>(isTrustedForwarderFunction, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOfFunction ownerOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOfFunction = new OwnerOfFunction();
                ownerOfFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom1Function safeTransferFrom1Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom1Function safeTransferFrom1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetBaseExtensionRequestAsync(SetBaseExtensionFunction setBaseExtensionFunction)
        {
             return ContractHandler.SendRequestAsync(setBaseExtensionFunction);
        }

        public Task<TransactionReceipt> SetBaseExtensionRequestAndWaitForReceiptAsync(SetBaseExtensionFunction setBaseExtensionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBaseExtensionFunction, cancellationToken);
        }

        public Task<string> SetBaseExtensionRequestAsync(string extension)
        {
            var setBaseExtensionFunction = new SetBaseExtensionFunction();
                setBaseExtensionFunction.Extension = extension;
            
             return ContractHandler.SendRequestAsync(setBaseExtensionFunction);
        }

        public Task<TransactionReceipt> SetBaseExtensionRequestAndWaitForReceiptAsync(string extension, CancellationTokenSource cancellationToken = null)
        {
            var setBaseExtensionFunction = new SetBaseExtensionFunction();
                setBaseExtensionFunction.Extension = extension;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBaseExtensionFunction, cancellationToken);
        }

        public Task<string> SetBaseURIRequestAsync(SetBaseURIFunction setBaseURIFunction)
        {
             return ContractHandler.SendRequestAsync(setBaseURIFunction);
        }

        public Task<TransactionReceipt> SetBaseURIRequestAndWaitForReceiptAsync(SetBaseURIFunction setBaseURIFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBaseURIFunction, cancellationToken);
        }

        public Task<string> SetBaseURIRequestAsync(string uri)
        {
            var setBaseURIFunction = new SetBaseURIFunction();
                setBaseURIFunction.Uri = uri;
            
             return ContractHandler.SendRequestAsync(setBaseURIFunction);
        }

        public Task<TransactionReceipt> SetBaseURIRequestAndWaitForReceiptAsync(string uri, CancellationTokenSource cancellationToken = null)
        {
            var setBaseURIFunction = new SetBaseURIFunction();
                setBaseURIFunction.Uri = uri;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBaseURIFunction, cancellationToken);
        }

        public Task<string> SetBreedingContractRequestAsync(SetBreedingContractFunction setBreedingContractFunction)
        {
             return ContractHandler.SendRequestAsync(setBreedingContractFunction);
        }

        public Task<TransactionReceipt> SetBreedingContractRequestAndWaitForReceiptAsync(SetBreedingContractFunction setBreedingContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBreedingContractFunction, cancellationToken);
        }

        public Task<string> SetBreedingContractRequestAsync(string breedingContract)
        {
            var setBreedingContractFunction = new SetBreedingContractFunction();
                setBreedingContractFunction.BreedingContract = breedingContract;
            
             return ContractHandler.SendRequestAsync(setBreedingContractFunction);
        }

        public Task<TransactionReceipt> SetBreedingContractRequestAndWaitForReceiptAsync(string breedingContract, CancellationTokenSource cancellationToken = null)
        {
            var setBreedingContractFunction = new SetBreedingContractFunction();
                setBreedingContractFunction.BreedingContract = breedingContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBreedingContractFunction, cancellationToken);
        }

        public Task<string> SetBreedingPriceRequestAsync(SetBreedingPriceFunction setBreedingPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setBreedingPriceFunction);
        }

        public Task<TransactionReceipt> SetBreedingPriceRequestAndWaitForReceiptAsync(SetBreedingPriceFunction setBreedingPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBreedingPriceFunction, cancellationToken);
        }

        public Task<string> SetBreedingPriceRequestAsync(byte breedingPrice)
        {
            var setBreedingPriceFunction = new SetBreedingPriceFunction();
                setBreedingPriceFunction.BreedingPrice = breedingPrice;
            
             return ContractHandler.SendRequestAsync(setBreedingPriceFunction);
        }

        public Task<TransactionReceipt> SetBreedingPriceRequestAndWaitForReceiptAsync(byte breedingPrice, CancellationTokenSource cancellationToken = null)
        {
            var setBreedingPriceFunction = new SetBreedingPriceFunction();
                setBreedingPriceFunction.BreedingPrice = breedingPrice;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBreedingPriceFunction, cancellationToken);
        }

        public Task<string> SetCoinContractRequestAsync(SetCoinContractFunction setCoinContractFunction)
        {
             return ContractHandler.SendRequestAsync(setCoinContractFunction);
        }

        public Task<TransactionReceipt> SetCoinContractRequestAndWaitForReceiptAsync(SetCoinContractFunction setCoinContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCoinContractFunction, cancellationToken);
        }

        public Task<string> SetCoinContractRequestAsync(string coinContract)
        {
            var setCoinContractFunction = new SetCoinContractFunction();
                setCoinContractFunction.CoinContract = coinContract;
            
             return ContractHandler.SendRequestAsync(setCoinContractFunction);
        }

        public Task<TransactionReceipt> SetCoinContractRequestAndWaitForReceiptAsync(string coinContract, CancellationTokenSource cancellationToken = null)
        {
            var setCoinContractFunction = new SetCoinContractFunction();
                setCoinContractFunction.CoinContract = coinContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCoinContractFunction, cancellationToken);
        }

        public Task<string> SetContractURIRequestAsync(SetContractURIFunction setContractURIFunction)
        {
             return ContractHandler.SendRequestAsync(setContractURIFunction);
        }

        public Task<TransactionReceipt> SetContractURIRequestAndWaitForReceiptAsync(SetContractURIFunction setContractURIFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractURIFunction, cancellationToken);
        }

        public Task<string> SetContractURIRequestAsync(string uri)
        {
            var setContractURIFunction = new SetContractURIFunction();
                setContractURIFunction.Uri = uri;
            
             return ContractHandler.SendRequestAsync(setContractURIFunction);
        }

        public Task<TransactionReceipt> SetContractURIRequestAndWaitForReceiptAsync(string uri, CancellationTokenSource cancellationToken = null)
        {
            var setContractURIFunction = new SetContractURIFunction();
                setContractURIFunction.Uri = uri;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractURIFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURIFunction tokenURIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenURIFunction = new TokenURIFunction();
                tokenURIFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }
    }
}
