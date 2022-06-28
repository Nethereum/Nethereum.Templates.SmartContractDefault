using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace ContractLibrary.Contracts.ERC20Token.ContractDefinition
{


    public partial class ERC20TokenDeployment : ERC20TokenDeploymentBase
    {
        public ERC20TokenDeployment() : base(BYTECODE) { }
        public ERC20TokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class ERC20TokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b5060405162000ae238038062000ae283398101604081905262000034916200014f565b336000908152602081905260409020849055600284905560036200005984826200026d565b506004805460ff191660ff841617905560056200007782826200026d565b505050505062000339565b634e487b7160e01b600052604160045260246000fd5b600082601f830112620000aa57600080fd5b81516001600160401b0380821115620000c757620000c762000082565b604051601f8301601f19908116603f01168101908282118183101715620000f257620000f262000082565b816040528381526020925086838588010111156200010f57600080fd5b600091505b8382101562000133578582018301518183018401529082019062000114565b83821115620001455760008385830101525b9695505050505050565b600080600080608085870312156200016657600080fd5b845160208601519094506001600160401b03808211156200018657600080fd5b620001948883890162000098565b94506040870151915060ff82168214620001ad57600080fd5b606087015191935080821115620001c357600080fd5b50620001d28782880162000098565b91505092959194509250565b600181811c90821680620001f357607f821691505b6020821081036200021457634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156200026857600081815260208120601f850160051c81016020861015620002435750805b601f850160051c820191505b8181101562000264578281556001016200024f565b5050505b505050565b81516001600160401b0381111562000289576200028962000082565b620002a1816200029a8454620001de565b846200021a565b602080601f831160018114620002d95760008415620002c05750858301515b600019600386901b1c1916600185901b17855562000264565b600085815260208120601f198616915b828110156200030a57888601518255948401946001909101908401620002e9565b5085821015620003295787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b61079980620003496000396000f3fe608060405234801561001057600080fd5b50600436106100a95760003560e01c8063313ce56711610071578063313ce567146101395780635c6581651461015857806370a082311461018357806395d89b41146101ac578063a9059cbb146101b4578063dd62ed3e146101c757600080fd5b806306fdde03146100ae578063095ea7b3146100cc57806318160ddd146100ef57806323b872dd1461010657806327e235e314610119575b600080fd5b6100b6610200565b6040516100c391906105b8565b60405180910390f35b6100df6100da366004610629565b61028e565b60405190151581526020016100c3565b6100f860025481565b6040519081526020016100c3565b6100df610114366004610653565b6102fa565b6100f861012736600461068f565b60006020819052908152604090205481565b6004546101469060ff1681565b60405160ff90911681526020016100c3565b6100f86101663660046106b1565b600160209081526000928352604080842090915290825290205481565b6100f861019136600461068f565b6001600160a01b031660009081526020819052604090205490565b6100b66104a6565b6100df6101c2366004610629565b6104b3565b6100f86101d53660046106b1565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b6003805461020d906106e4565b80601f0160208091040260200160405190810160405280929190818152602001828054610239906106e4565b80156102865780601f1061025b57610100808354040283529160200191610286565b820191906000526020600020905b81548152906001019060200180831161026957829003601f168201915b505050505081565b3360008181526001602090815260408083206001600160a01b038716808552925280832085905551919290917f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925906102e99086815260200190565b60405180910390a350600192915050565b6001600160a01b038316600081815260016020908152604080832033845282528083205493835290829052812054909190831180159061033a5750828110155b6103b15760405162461bcd60e51b815260206004820152603960248201527f746f6b656e2062616c616e6365206f7220616c6c6f77616e6365206973206c6f60448201527f776572207468616e20616d6f756e74207265717565737465640000000000000060648201526084015b60405180910390fd5b6001600160a01b038416600090815260208190526040812080548592906103d9908490610734565b90915550506001600160a01b0385166000908152602081905260408120805485929061040690849061074c565b909155505060001981101561044e576001600160a01b03851660009081526001602090815260408083203384529091528120805485929061044890849061074c565b90915550505b836001600160a01b0316856001600160a01b03167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef8560405161049391815260200190565b60405180910390a3506001949350505050565b6005805461020d906106e4565b3360009081526020819052604081205482111561052a5760405162461bcd60e51b815260206004820152602f60248201527f746f6b656e2062616c616e6365206973206c6f776572207468616e207468652060448201526e1d985b1d59481c995c5d595cdd1959608a1b60648201526084016103a8565b336000908152602081905260408120805484929061054990849061074c565b90915550506001600160a01b03831660009081526020819052604081208054849290610576908490610734565b90915550506040518281526001600160a01b0384169033907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef906020016102e9565b600060208083528351808285015260005b818110156105e5578581018301518582016040015282016105c9565b818111156105f7576000604083870101525b50601f01601f1916929092016040019392505050565b80356001600160a01b038116811461062457600080fd5b919050565b6000806040838503121561063c57600080fd5b6106458361060d565b946020939093013593505050565b60008060006060848603121561066857600080fd5b6106718461060d565b925061067f6020850161060d565b9150604084013590509250925092565b6000602082840312156106a157600080fd5b6106aa8261060d565b9392505050565b600080604083850312156106c457600080fd5b6106cd8361060d565b91506106db6020840161060d565b90509250929050565b600181811c908216806106f857607f821691505b60208210810361071857634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b600082198211156107475761074761071e565b500190565b60008282101561075e5761075e61071e565b50039056fea2646970667358221220fe5dd1fc8da102c188804e755a4a643a0ade9942cd3578e43bef8c60f88ce03b64736f6c634300080f0033";
        public ERC20TokenDeploymentBase() : base(BYTECODE) { }
        public ERC20TokenDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "_initialAmount", 1)]
        public virtual BigInteger InitialAmount { get; set; }
        [Parameter("string", "_tokenName", 2)]
        public virtual string TokenName { get; set; }
        [Parameter("uint8", "_decimalUnits", 3)]
        public virtual byte DecimalUnits { get; set; }
        [Parameter("string", "_tokenSymbol", 4)]
        public virtual string TokenSymbol { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "_spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class AllowedFunction : AllowedFunctionBase { }

    [Function("allowed", "uint256")]
    public class AllowedFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class BalancesFunction : BalancesFunctionBase { }

    [Function("balances", "uint256")]
    public class BalancesFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
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
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "_spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "_from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "remaining", 1)]
        public virtual BigInteger Remaining { get; set; }
    }

    public partial class AllowedOutputDTO : AllowedOutputDTOBase { }

    [FunctionOutput]
    public class AllowedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "balance", 1)]
        public virtual BigInteger Balance { get; set; }
    }

    public partial class BalancesOutputDTO : BalancesOutputDTOBase { }

    [FunctionOutput]
    public class BalancesOutputDTOBase : IFunctionOutputDTO 
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

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
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
