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

namespace NFTService.ATBToken.ContractDefinition
{


    public partial class ATBTokenDeployment : ATBTokenDeploymentBase
    {
        public ATBTokenDeployment() : base(BYTECODE) { }
        public ATBTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class ATBTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60c06040526005608090815264173539b7b760d91b60a052600f906200002690826200022d565b503480156200003457600080fd5b506040518060400160405280600881526020016720aa212a37b5b2b760c11b815250604051806040016040528060048152602001631055109560e21b81525081600090816200008491906200022d565b5060016200009382826200022d565b505050620000b0620000aa620000b660201b60201c565b620000d2565b620002f9565b6000620000cd6200012460201b62000e971760201c565b905090565b600680546001600160a01b038381166001600160a01b0319831681179093556040519116919082907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a35050565b6000601436108015906200013e57506200013e3362000156565b1562000151575060131936013560601c90565b503390565b60006200016e826200017460201b62000ec51760201c565b92915050565b6007546001600160a01b0391821691161490565b634e487b7160e01b600052604160045260246000fd5b600181811c90821680620001b357607f821691505b602082108103620001d457634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156200022857600081815260208120601f850160051c81016020861015620002035750805b601f850160051c820191505b8181101562000224578281556001016200020f565b5050505b505050565b81516001600160401b0381111562000249576200024962000188565b62000261816200025a84546200019e565b84620001da565b602080601f831160018114620002995760008415620002805750858301515b600019600386901b1c1916600185901b17855562000224565b600085815260208120601f198616915b82811015620002ca57888601518255948401946001909101908401620002a9565b5085821015620002e95787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b61220380620003096000396000f3fe608060405234801561001057600080fd5b50600436106101da5760003560e01c8063938e3d7b11610104578063c87b56dd116100a2578063e8a3d48511610071578063e8a3d485146103dc578063e985e9c5146103e4578063f2fde38b14610420578063fcbc4cee1461043357600080fd5b8063c87b56dd14610392578063ce1b815f146103a5578063da3ef23f146103b6578063de405b18146103c957600080fd5b8063b88d4fde116100de578063b88d4fde14610346578063b921a40014610359578063bc4ddb521461036c578063c6be88a41461037f57600080fd5b8063938e3d7b1461031857806395d89b411461032b578063a22cb4651461033357600080fd5b806342842e0e1161017c57806370a082311161014b57806370a08231146102d9578063715018a6146102ec5780638c5527cf146102f45780638da5cb5b1461030757600080fd5b806342842e0e1461028d57806355f804b3146102a0578063572b6c05146102b35780636352211e146102c657600080fd5b8063095ea7b3116101b8578063095ea7b31461024757806318160ddd1461025c57806323b872dd146102725780633ccfd60b1461028557600080fd5b806301ffc9a7146101df57806306fdde0314610207578063081812fc1461021c575b600080fd5b6101f26101ed36600461190c565b610446565b60405190151581526020015b60405180910390f35b61020f610498565b6040516101fe9190611979565b61022f61022a36600461198c565b61052a565b6040516001600160a01b0390911681526020016101fe565b61025a6102553660046119c1565b610551565b005b61026461067d565b6040519081526020016101fe565b61025a6102803660046119eb565b61068d565b61025a6106c5565b61025a61029b3660046119eb565b610741565b61025a6102ae366004611ab3565b61075c565b6101f26102c1366004611afc565b610774565b61022f6102d436600461198c565b61078e565b6102646102e7366004611afc565b6107ee565b61025a610874565b61025a610302366004611afc565b610888565b6006546001600160a01b031661022f565b61025a610326366004611b17565b6108b2565b61020f6108c7565b61025a610341366004611b97565b6108d6565b61025a610354366004611bce565b6108e8565b610264610367366004611c4a565b610927565b61026461037a366004611c7d565b610bce565b61025a61038d366004611c7d565b610bee565b61020f6103a036600461198c565b610d12565b6007546001600160a01b031661022f565b61025a6103c4366004611ab3565b610db6565b61025a6103d7366004611ca9565b610dca565b61020f610de8565b6101f26103f2366004611cc4565b6001600160a01b03918216600090815260056020908152604080832093909416825291909152205460ff1690565b61025a61042e366004611afc565b610df7565b61025a610441366004611afc565b610e6d565b60006001600160e01b031982166380ac58cd60e01b148061047757506001600160e01b03198216635b5e139f60e01b145b8061049257506301ffc9a760e01b6001600160e01b03198316145b92915050565b6060600080546104a790611cee565b80601f01602080910402602001604051908101604052809291908181526020018280546104d390611cee565b80156105205780601f106104f557610100808354040283529160200191610520565b820191906000526020600020905b81548152906001019060200180831161050357829003601f168201915b5050505050905090565b600061053582610ed9565b506000908152600460205260409020546001600160a01b031690565b600061055c8261078e565b9050806001600160a01b0316836001600160a01b0316036105ce5760405162461bcd60e51b815260206004820152602160248201527f4552433732313a20617070726f76616c20746f2063757272656e74206f776e656044820152603960f91b60648201526084015b60405180910390fd5b806001600160a01b03166105e0610f29565b6001600160a01b031614806105fc57506105fc816103f2610f29565b61066e5760405162461bcd60e51b815260206004820152603d60248201527f4552433732313a20617070726f76652063616c6c6572206973206e6f7420746f60448201527f6b656e206f776e6572206f7220617070726f76656420666f7220616c6c00000060648201526084016105c5565b6106788383610f33565b505050565b600061068860085490565b905090565b61069e610698610f29565b82610fa1565b6106ba5760405162461bcd60e51b81526004016105c590611d28565b610678838383611020565b6106cd611191565b60006106e16006546001600160a01b031690565b6001600160a01b03164760405160006040518083038185875af1925050503d806000811461072b576040519150601f19603f3d011682016040523d82523d6000602084013e610730565b606091505b505090508061073e57600080fd5b50565b610678838383604051806020016040528060008152506108e8565b610764611191565b600e6107708282611dc3565b5050565b6000610492826007546001600160a01b0391821691161490565b6000818152600260205260408120546001600160a01b0316806104925760405162461bcd60e51b8152602060048201526018602482015277115490cdcc8c4e881a5b9d985b1a59081d1bdad95b88125160421b60448201526064016105c5565b60006001600160a01b0382166108585760405162461bcd60e51b815260206004820152602960248201527f4552433732313a2061646472657373207a65726f206973206e6f7420612076616044820152683634b21037bbb732b960b91b60648201526084016105c5565b506001600160a01b031660009081526003602052604090205490565b61087c611191565b610886600061120a565b565b610890611191565b600c80546001600160a01b0319166001600160a01b0392909216919091179055565b6108ba611191565b600d610678828483611e83565b6060600180546104a790611cee565b6107706108e1610f29565b838361125c565b6108f96108f3610f29565b83610fa1565b6109155760405162461bcd60e51b81526004016105c590611d28565b6109218484848461132a565b50505050565b6000610931611191565b61093a8361135d565b6109565760405162461bcd60e51b81526004016105c590611f44565b61095f8261135d565b61097b5760405162461bcd60e51b81526004016105c590611f44565b6000838152600a60205260408082208483529120600954600483015460ff918216911610156109e25760405162461bcd60e51b8152602060048201526013602482015272696e73756666696369656e742063686172676560681b60448201526064016105c5565b600954600482015460ff91821691161015610a355760405162461bcd60e51b8152602060048201526013602482015272696e73756666696369656e742063686172676560681b60448201526064016105c5565b6000600282600301548460030154610a4d9190611f91565b610a579190611fa4565b610a62906001611f91565b600c5460028581015490850154604051630a7cc0f560e41b815260048101929092526024820152604481018390529192506000916001600160a01b039091169063a7cc0f50906064016020604051808303816000875af1158015610aca573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610aee9190611fc6565b9050610afe87878484600161137a565b60095460048601805492975060ff918216929091600091610b2191859116611fdf565b82546101009290920a60ff818102199093169183160217909155600954600486018054918316935091600091610b5991859116611fdf565b92506101000a81548160ff021916908360ff1602179055507fb6da9597f5553d5deafc722dcc1f69d5463612674a36bae2aa8698bd86af1c7c85888884604051610bbc949392919093845260208401929092526040830152606082015260800190565b60405180910390a15050505092915050565b6000610bd8611191565b610be76000806000868661137a565b9392505050565b610bf6611191565b610bff8261135d565b610c1b5760405162461bcd60e51b81526004016105c590611f44565b600b5460405163c290d69160e01b815260ff831660048201526001600160a01b039091169063c290d691906024016020604051808303816000875af1158015610c68573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610c8c9190611ff8565b506000828152600a602052604081206004018054839290610cb190849060ff16612015565b92506101000a81548160ff021916908360ff1602179055507ff4d8c9183c1ae5f9d1dde6edf0d08ab75f4e38c8896340f590b8a8e20acea9b68282604051610d0692919091825260ff16602082015260400190565b60405180910390a15050565b6060610d1d8261135d565b610d815760405162461bcd60e51b815260206004820152602f60248201527f4552433732314d657461646174613a2055524920717565727920666f72206e6f60448201526e3732bc34b9ba32b73a103a37b5b2b760891b60648201526084016105c5565b600e610d8c83611433565b600f604051602001610da0939291906120a1565b6040516020818303038152906040529050919050565b610dbe611191565b600f6107708282611dc3565b610dd2611191565b6009805460ff191660ff92909216919091179055565b6060600d80546104a790611cee565b610dff611191565b6001600160a01b038116610e645760405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b60648201526084016105c5565b61073e8161120a565b610e75611191565b600b80546001600160a01b0319166001600160a01b0392909216919091179055565b600060143610801590610eae5750610eae33610774565b15610ec0575060131936013560601c90565b503390565b6007546001600160a01b0391821691161490565b610ee28161135d565b61073e5760405162461bcd60e51b8152602060048201526018602482015277115490cdcc8c4e881a5b9d985b1a59081d1bdad95b88125160421b60448201526064016105c5565b6000610688610e97565b600081815260046020526040902080546001600160a01b0319166001600160a01b0384169081179091558190610f688261078e565b6001600160a01b03167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92560405160405180910390a45050565b600080610fad8361078e565b9050806001600160a01b0316846001600160a01b03161480610ff457506001600160a01b0380821660009081526005602090815260408083209388168352929052205460ff165b806110185750836001600160a01b031661100d8461052a565b6001600160a01b0316145b949350505050565b826001600160a01b03166110338261078e565b6001600160a01b0316146110595760405162461bcd60e51b81526004016105c5906120c9565b6001600160a01b0382166110bb5760405162461bcd60e51b8152602060048201526024808201527f4552433732313a207472616e7366657220746f20746865207a65726f206164646044820152637265737360e01b60648201526084016105c5565b6110c883838360016114c6565b826001600160a01b03166110db8261078e565b6001600160a01b0316146111015760405162461bcd60e51b81526004016105c5906120c9565b600081815260046020908152604080832080546001600160a01b03199081169091556001600160a01b0387811680865260038552838620805460001901905590871680865283862080546001019055868652600290945282852080549092168417909155905184937fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef91a4505050565b611199610f29565b6001600160a01b03166111b46006546001600160a01b031690565b6001600160a01b0316146108865760405162461bcd60e51b815260206004820181905260248201527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e657260448201526064016105c5565b600680546001600160a01b038381166001600160a01b0319831681179093556040519116919082907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a35050565b816001600160a01b0316836001600160a01b0316036112bd5760405162461bcd60e51b815260206004820152601960248201527f4552433732313a20617070726f766520746f2063616c6c65720000000000000060448201526064016105c5565b6001600160a01b03838116600081815260056020908152604080832094871680845294825291829020805460ff191686151590811790915591519182527f17307eab39ab6107e8899845ad3d59bd9653f200f220920489ca2b5937696c31910160405180910390a3505050565b611335848484611020565b6113418484848461154e565b6109215760405162461bcd60e51b81526004016105c59061210e565b6000908152600260205260409020546001600160a01b0316151590565b6000806040518060a001604052808881526020018781526020018581526020018681526020018460ff1681525090506113b7600880546001019055565b60006113c260085490565b6000818152600a6020908152604091829020855181559085015160018201559084015160028201556060840151600382015560808401516004909101805460ff191660ff909216919091179055600654909150611428906001600160a01b031682611656565b979650505050505050565b6060600061144083611670565b600101905060008167ffffffffffffffff81111561146057611460611a27565b6040519080825280601f01601f19166020018201604052801561148a576020820181803683370190505b5090508181016020015b600019016f181899199a1a9b1b9c1cb0b131b232b360811b600a86061a8153600a850494508461149457509392505050565b6001811115610921576001600160a01b0384161561150c576001600160a01b03841660009081526003602052604081208054839290611506908490612160565b90915550505b6001600160a01b03831615610921576001600160a01b03831660009081526003602052604081208054839290611543908490611f91565b909155505050505050565b60006001600160a01b0384163b1561164b57836001600160a01b031663150b7a02611577610f29565b8786866040518563ffffffff1660e01b81526004016115999493929190612173565b6020604051808303816000875af19250505080156115d4575060408051601f3d908101601f191682019092526115d1918101906121b0565b60015b611631573d808015611602576040519150601f19603f3d011682016040523d82523d6000602084013e611607565b606091505b5080516000036116295760405162461bcd60e51b81526004016105c59061210e565b805181602001fd5b6001600160e01b031916630a85bd0160e11b149050611018565b506001949350505050565b610770828260405180602001604052806000815250611748565b60008072184f03e93ff9f4daa797ed6e38ed64bf6a1f0160401b83106116af5772184f03e93ff9f4daa797ed6e38ed64bf6a1f0160401b830492506040015b6d04ee2d6d415b85acef810000000083106116db576d04ee2d6d415b85acef8100000000830492506020015b662386f26fc1000083106116f957662386f26fc10000830492506010015b6305f5e1008310611711576305f5e100830492506008015b612710831061172557612710830492506004015b60648310611737576064830492506002015b600a83106104925760010192915050565b611752838361177b565b61175f600084848461154e565b6106785760405162461bcd60e51b81526004016105c59061210e565b6001600160a01b0382166117d15760405162461bcd60e51b815260206004820181905260248201527f4552433732313a206d696e7420746f20746865207a65726f206164647265737360448201526064016105c5565b6117da8161135d565b156118275760405162461bcd60e51b815260206004820152601c60248201527f4552433732313a20746f6b656e20616c7265616479206d696e7465640000000060448201526064016105c5565b6118356000838360016114c6565b61183e8161135d565b1561188b5760405162461bcd60e51b815260206004820152601c60248201527f4552433732313a20746f6b656e20616c7265616479206d696e7465640000000060448201526064016105c5565b6001600160a01b038216600081815260036020908152604080832080546001019055848352600290915280822080546001600160a01b0319168417905551839291907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef908290a45050565b6001600160e01b03198116811461073e57600080fd5b60006020828403121561191e57600080fd5b8135610be7816118f6565b60005b8381101561194457818101518382015260200161192c565b50506000910152565b60008151808452611965816020860160208601611929565b601f01601f19169290920160200192915050565b602081526000610be7602083018461194d565b60006020828403121561199e57600080fd5b5035919050565b80356001600160a01b03811681146119bc57600080fd5b919050565b600080604083850312156119d457600080fd5b6119dd836119a5565b946020939093013593505050565b600080600060608486031215611a0057600080fd5b611a09846119a5565b9250611a17602085016119a5565b9150604084013590509250925092565b634e487b7160e01b600052604160045260246000fd5b600067ffffffffffffffff80841115611a5857611a58611a27565b604051601f8501601f19908116603f01168101908282118183101715611a8057611a80611a27565b81604052809350858152868686011115611a9957600080fd5b858560208301376000602087830101525050509392505050565b600060208284031215611ac557600080fd5b813567ffffffffffffffff811115611adc57600080fd5b8201601f81018413611aed57600080fd5b61101884823560208401611a3d565b600060208284031215611b0e57600080fd5b610be7826119a5565b60008060208385031215611b2a57600080fd5b823567ffffffffffffffff80821115611b4257600080fd5b818501915085601f830112611b5657600080fd5b813581811115611b6557600080fd5b866020828501011115611b7757600080fd5b60209290920196919550909350505050565b801515811461073e57600080fd5b60008060408385031215611baa57600080fd5b611bb3836119a5565b91506020830135611bc381611b89565b809150509250929050565b60008060008060808587031215611be457600080fd5b611bed856119a5565b9350611bfb602086016119a5565b925060408501359150606085013567ffffffffffffffff811115611c1e57600080fd5b8501601f81018713611c2f57600080fd5b611c3e87823560208401611a3d565b91505092959194509250565b60008060408385031215611c5d57600080fd5b50508035926020909101359150565b803560ff811681146119bc57600080fd5b60008060408385031215611c9057600080fd5b82359150611ca060208401611c6c565b90509250929050565b600060208284031215611cbb57600080fd5b610be782611c6c565b60008060408385031215611cd757600080fd5b611ce0836119a5565b9150611ca0602084016119a5565b600181811c90821680611d0257607f821691505b602082108103611d2257634e487b7160e01b600052602260045260246000fd5b50919050565b6020808252602d908201527f4552433732313a2063616c6c6572206973206e6f7420746f6b656e206f776e6560408201526c1c881bdc88185c1c1c9bdd9959609a1b606082015260800190565b601f82111561067857600081815260208120601f850160051c81016020861015611d9c5750805b601f850160051c820191505b81811015611dbb57828155600101611da8565b505050505050565b815167ffffffffffffffff811115611ddd57611ddd611a27565b611df181611deb8454611cee565b84611d75565b602080601f831160018114611e265760008415611e0e5750858301515b600019600386901b1c1916600185901b178555611dbb565b600085815260208120601f198616915b82811015611e5557888601518255948401946001909101908401611e36565b5085821015611e735787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b67ffffffffffffffff831115611e9b57611e9b611a27565b611eaf83611ea98354611cee565b83611d75565b6000601f841160018114611ee35760008515611ecb5750838201355b600019600387901b1c1916600186901b178355611f3d565b600083815260209020601f19861690835b82811015611f145786850135825560209485019460019092019101611ef4565b5086821015611f315760001960f88860031b161c19848701351681555b505060018560011b0183555b5050505050565b6020808252601b908201527f717565727920666f72206e6f6e6578697374656e7420746f6b656e0000000000604082015260600190565b634e487b7160e01b600052601160045260246000fd5b8082018082111561049257610492611f7b565b600082611fc157634e487b7160e01b600052601260045260246000fd5b500490565b600060208284031215611fd857600080fd5b5051919050565b60ff828116828216039081111561049257610492611f7b565b60006020828403121561200a57600080fd5b8151610be781611b89565b60ff818116838216019081111561049257610492611f7b565b6000815461203b81611cee565b60018281168015612053576001811461206857612097565b60ff1984168752821515830287019450612097565b8560005260208060002060005b8581101561208e5781548a820152908401908201612075565b50505082870194505b5050505092915050565b60006120ad828661202e565b84516120bd818360208901611929565b6114288183018661202e565b60208082526025908201527f4552433732313a207472616e736665722066726f6d20696e636f72726563742060408201526437bbb732b960d91b606082015260800190565b60208082526032908201527f4552433732313a207472616e7366657220746f206e6f6e20455243373231526560408201527131b2b4bb32b91034b6b83632b6b2b73a32b960711b606082015260800190565b8181038181111561049257610492611f7b565b6001600160a01b03858116825284166020820152604081018390526080606082018190526000906121a69083018461194d565b9695505050505050565b6000602082840312156121c257600080fd5b8151610be7816118f656fea26469706673582212206d04e4b94ad4cf44a345ddf73c2beb9769b03296c06c310212ec5a9c4cfe3ebd64736f6c63430008110033";
        public ATBTokenDeploymentBase() : base(BYTECODE) { }
        public ATBTokenDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class BreedingFunction : BreedingFunctionBase { }

    [Function("Breeding", "uint256")]
    public class BreedingFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "token1", 1)]
        public virtual BigInteger Token1 { get; set; }
        [Parameter("uint256", "token2", 2)]
        public virtual BigInteger Token2 { get; set; }
    }

    public partial class ChargeFunction : ChargeFunctionBase { }

    [Function("Charge")]
    public class ChargeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint8", "value", 2)]
        public virtual byte Value { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("Mint", "uint256")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_genes", 1)]
        public virtual BigInteger Genes { get; set; }
        [Parameter("uint8", "_charge", 2)]
        public virtual byte Charge { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class ContractURIFunction : ContractURIFunctionBase { }

    [Function("contractURI", "string")]
    public class ContractURIFunctionBase : FunctionMessage
    {

    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetTrustedForwarderFunction : GetTrustedForwarderFunctionBase { }

    [Function("getTrustedForwarder", "address")]
    public class GetTrustedForwarderFunctionBase : FunctionMessage
    {

    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class IsTrustedForwarderFunction : IsTrustedForwarderFunctionBase { }

    [Function("isTrustedForwarder", "bool")]
    public class IsTrustedForwarderFunctionBase : FunctionMessage
    {
        [Parameter("address", "forwarder", 1)]
        public virtual string Forwarder { get; set; }
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

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SetBaseExtensionFunction : SetBaseExtensionFunctionBase { }

    [Function("setBaseExtension")]
    public class SetBaseExtensionFunctionBase : FunctionMessage
    {
        [Parameter("string", "extension", 1)]
        public virtual string Extension { get; set; }
    }

    public partial class SetBaseURIFunction : SetBaseURIFunctionBase { }

    [Function("setBaseURI")]
    public class SetBaseURIFunctionBase : FunctionMessage
    {
        [Parameter("string", "URI", 1)]
        public virtual string Uri { get; set; }
    }

    public partial class SetBreedingContractFunction : SetBreedingContractFunctionBase { }

    [Function("setBreedingContract")]
    public class SetBreedingContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "breedingContract", 1)]
        public virtual string BreedingContract { get; set; }
    }

    public partial class SetBreedingPriceFunction : SetBreedingPriceFunctionBase { }

    [Function("setBreedingPrice")]
    public class SetBreedingPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "breedingPrice", 1)]
        public virtual byte BreedingPrice { get; set; }
    }

    public partial class SetCoinContractFunction : SetCoinContractFunctionBase { }

    [Function("setCoinContract")]
    public class SetCoinContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "coinContract", 1)]
        public virtual string CoinContract { get; set; }
    }

    public partial class SetContractURIFunction : SetContractURIFunctionBase { }

    [Function("setContractURI")]
    public class SetContractURIFunctionBase : FunctionMessage
    {
        [Parameter("string", "URI", 1)]
        public virtual string Uri { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {

    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class ChargedEventDTO : ChargedEventDTOBase { }

    [Event("Charged")]
    public class ChargedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, false )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint8", "charge", 2, false )]
        public virtual byte Charge { get; set; }
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
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class WasBornEventDTO : WasBornEventDTOBase { }

    [Event("WasBorn")]
    public class WasBornEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, false )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "parent1", 2, false )]
        public virtual BigInteger Parent1 { get; set; }
        [Parameter("uint256", "parent2", 3, false )]
        public virtual BigInteger Parent2 { get; set; }
        [Parameter("uint256", "genes", 4, false )]
        public virtual BigInteger Genes { get; set; }
    }









    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ContractURIOutputDTO : ContractURIOutputDTOBase { }

    [FunctionOutput]
    public class ContractURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetTrustedForwarderOutputDTO : GetTrustedForwarderOutputDTOBase { }

    [FunctionOutput]
    public class GetTrustedForwarderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "forwarder", 1)]
        public virtual string Forwarder { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsTrustedForwarderOutputDTO : IsTrustedForwarderOutputDTOBase { }

    [FunctionOutput]
    public class IsTrustedForwarderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





















    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
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
