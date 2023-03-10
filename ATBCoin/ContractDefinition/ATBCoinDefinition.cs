using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace NFTService.ATBCoin.ContractDefinition
{


    public partial class ATBCoinDeployment : ATBCoinDeploymentBase
    {
        public ATBCoinDeployment() : base(BYTECODE) { }
        public ATBCoinDeployment(string byteCode) : base(byteCode) { }
    }

    public class ATBCoinDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b506040518060400160405280600781526020016620aa2121b7b4b760c91b815250604051806040016040528060048152602001634154424360e01b81525081600390816200006091906200018d565b5060046200006f82826200018d565b5050506200008c620000866200009260201b60201c565b62000096565b62000259565b3390565b600580546001600160a01b038381166001600160a01b0319831681179093556040519116919082907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a35050565b634e487b7160e01b600052604160045260246000fd5b600181811c908216806200011357607f821691505b6020821081036200013457634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156200018857600081815260208120601f850160051c81016020861015620001635750805b601f850160051c820191505b8181101562000184578281556001016200016f565b5050505b505050565b81516001600160401b03811115620001a957620001a9620000e8565b620001c181620001ba8454620000fe565b846200013a565b602080601f831160018114620001f95760008415620001e05750858301515b600019600386901b1c1916600185901b17855562000184565b600085815260208120601f198616915b828110156200022a5788860151825594840194600190910190840162000209565b5085821015620002495787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b610f7880620002696000396000f3fe608060405234801561001057600080fd5b50600436106101215760003560e01c8063715018a6116100ad578063a9059cbb11610071578063a9059cbb14610252578063b78376e914610265578063c290d69114610278578063dd62ed3e1461028b578063f2fde38b1461029e57600080fd5b8063715018a6146102015780638da5cb5b1461020957806395d89b4114610224578063a0712d681461022c578063a457c2d71461023f57600080fd5b806318160ddd116100f457806318160ddd1461019157806323b872dd146101a3578063313ce567146101b657806339509351146101c557806370a08231146101d857600080fd5b8063048f16271461012657806306fdde031461013b578063095ea7b3146101595780631055d7081461017c575b600080fd5b610139610134366004610d41565b6102b1565b005b61014361033b565b6040516101509190610d63565b60405180910390f35b61016c610167366004610db1565b6103cd565b6040519015158152602001610150565b6101846103e7565b6040516101509190610ddb565b6002545b604051908152602001610150565b61016c6101b1366004610e28565b610448565b60405160128152602001610150565b61016c6101d3366004610db1565b61046c565b6101956101e6366004610d41565b6001600160a01b031660009081526020819052604090205490565b61013961048e565b6005546040516001600160a01b039091168152602001610150565b6101436104a2565b61013961023a366004610e64565b6104b1565b61016c61024d366004610db1565b6104d7565b61016c610260366004610db1565b610557565b610139610273366004610d41565b610565565b610139610286366004610e64565b6105bf565b610195610299366004610e7d565b6106a5565b6101396102ac366004610d41565b6106d0565b6102b9610746565b60005b60065481101561033757600681815481106102d9576102d9610eb0565b6000918252602090912001546001600160a01b0390811690831603610325576006818154811061030b5761030b610eb0565b600091825260209091200180546001600160a01b03191690555b8061032f81610edc565b9150506102bc565b5050565b60606003805461034a90610ef5565b80601f016020809104026020016040519081016040528092919081815260200182805461037690610ef5565b80156103c35780601f10610398576101008083540402835291602001916103c3565b820191906000526020600020905b8154815290600101906020018083116103a657829003601f168201915b5050505050905090565b6000336103db8185856107a0565b60019150505b92915050565b606060068054806020026020016040519081016040528092919081815260200182805480156103c357602002820191906000526020600020905b81546001600160a01b03168152600190910190602001808311610421575050505050905090565b6000336104568582856108c4565b61046185858561093e565b506001949350505050565b6000336103db81858561047f83836106a5565b6104899190610f2f565b6107a0565b610496610746565b6104a06000610ae2565b565b60606004805461034a90610ef5565b6104b9610746565b6104d46104ce6005546001600160a01b031690565b82610b34565b50565b600033816104e582866106a5565b90508381101561054a5760405162461bcd60e51b815260206004820152602560248201527f45524332303a2064656372656173656420616c6c6f77616e63652062656c6f77604482015264207a65726f60d81b60648201526084015b60405180910390fd5b61046182868684036107a0565b6000336103db81858561093e565b61056d610746565b600680546001810182556000919091527ff652222313e28459528d920b65115c16c04f3efc82aaedc97be59f3f377c0d3f0180546001600160a01b0319166001600160a01b0392909216919091179055565b60008060005b60065481101561061d57336001600160a01b0316600682815481106105ec576105ec610eb0565b6000918252602090912001546001600160a01b03160361060b57600191505b8061061581610edc565b9150506105c5565b50806106855760405162461bcd60e51b815260206004820152603160248201527f6f6e6c79546f6b656e436f6e74726163744f776e61626c653a2063616c6c65726044820152701034b9903737ba103a3432903830bcb2b960791b6064820152608401610541565b6106a061069a6005546001600160a01b031690565b84610bf3565b505050565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b6106d8610746565b6001600160a01b03811661073d5760405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b6064820152608401610541565b6104d481610ae2565b6005546001600160a01b031633146104a05760405162461bcd60e51b815260206004820181905260248201527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e65726044820152606401610541565b6001600160a01b0383166108025760405162461bcd60e51b8152602060048201526024808201527f45524332303a20617070726f76652066726f6d20746865207a65726f206164646044820152637265737360e01b6064820152608401610541565b6001600160a01b0382166108635760405162461bcd60e51b815260206004820152602260248201527f45524332303a20617070726f766520746f20746865207a65726f206164647265604482015261737360f01b6064820152608401610541565b6001600160a01b0383811660008181526001602090815260408083209487168084529482529182902085905590518481527f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925910160405180910390a3505050565b60006108d084846106a5565b90506000198114610938578181101561092b5760405162461bcd60e51b815260206004820152601d60248201527f45524332303a20696e73756666696369656e7420616c6c6f77616e63650000006044820152606401610541565b61093884848484036107a0565b50505050565b6001600160a01b0383166109a25760405162461bcd60e51b815260206004820152602560248201527f45524332303a207472616e736665722066726f6d20746865207a65726f206164604482015264647265737360d81b6064820152608401610541565b6001600160a01b038216610a045760405162461bcd60e51b815260206004820152602360248201527f45524332303a207472616e7366657220746f20746865207a65726f206164647260448201526265737360e81b6064820152608401610541565b6001600160a01b03831660009081526020819052604090205481811015610a7c5760405162461bcd60e51b815260206004820152602660248201527f45524332303a207472616e7366657220616d6f756e7420657863656564732062604482015265616c616e636560d01b6064820152608401610541565b6001600160a01b03848116600081815260208181526040808320878703905593871680835291849020805487019055925185815290927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a3610938565b600580546001600160a01b038381166001600160a01b0319831681179093556040519116919082907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a35050565b6001600160a01b038216610b8a5760405162461bcd60e51b815260206004820152601f60248201527f45524332303a206d696e7420746f20746865207a65726f2061646472657373006044820152606401610541565b8060026000828254610b9c9190610f2f565b90915550506001600160a01b038216600081815260208181526040808320805486019055518481527fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35050565b6001600160a01b038216610c535760405162461bcd60e51b815260206004820152602160248201527f45524332303a206275726e2066726f6d20746865207a65726f206164647265736044820152607360f81b6064820152608401610541565b6001600160a01b03821660009081526020819052604090205481811015610cc75760405162461bcd60e51b815260206004820152602260248201527f45524332303a206275726e20616d6f756e7420657863656564732062616c616e604482015261636560f01b6064820152608401610541565b6001600160a01b0383166000818152602081815260408083208686039055600280548790039055518581529192917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a3505050565b80356001600160a01b0381168114610d3c57600080fd5b919050565b600060208284031215610d5357600080fd5b610d5c82610d25565b9392505050565b600060208083528351808285015260005b81811015610d9057858101830151858201604001528201610d74565b506000604082860101526040601f19601f8301168501019250505092915050565b60008060408385031215610dc457600080fd5b610dcd83610d25565b946020939093013593505050565b6020808252825182820181905260009190848201906040850190845b81811015610e1c5783516001600160a01b031683529284019291840191600101610df7565b50909695505050505050565b600080600060608486031215610e3d57600080fd5b610e4684610d25565b9250610e5460208501610d25565b9150604084013590509250925092565b600060208284031215610e7657600080fd5b5035919050565b60008060408385031215610e9057600080fd5b610e9983610d25565b9150610ea760208401610d25565b90509250929050565b634e487b7160e01b600052603260045260246000fd5b634e487b7160e01b600052601160045260246000fd5b600060018201610eee57610eee610ec6565b5060010190565b600181811c90821680610f0957607f821691505b602082108103610f2957634e487b7160e01b600052602260045260246000fd5b50919050565b808201808211156103e1576103e1610ec656fea264697066735822122066c2fc64f1834b487fec7675760f424a0ff53429d6bffe4d6f0a4e754783db0f64736f6c63430008110033";
        public ATBCoinDeploymentBase() : base(BYTECODE) { }
        public ATBCoinDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddPayerFunction : AddPayerFunctionBase { }

    [Function("addPayer")]
    public class AddPayerFunctionBase : FunctionMessage
    {
        [Parameter("address", "payer", 1)]
        public virtual string Payer { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class GetPayersFunction : GetPayersFunctionBase { }

    [Function("getPayers", "address[]")]
    public class GetPayersFunctionBase : FunctionMessage
    {

    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PayFunction : PayFunctionBase { }

    [Function("pay")]
    public class PayFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class RemovePayerFunction : RemovePayerFunctionBase { }

    [Function("removePayer")]
    public class RemovePayerFunctionBase : FunctionMessage
    {
        [Parameter("address", "payer", 1)]
        public virtual string Payer { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }



    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class GetPayersOutputDTO : GetPayersOutputDTOBase { }

    [FunctionOutput]
    public class GetPayersOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }





    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }






}
