using System.Numerics;
using Nethereum.RPC.Fee1559Suggestions;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.XUnitEthereumClients;
using Xunit;

namespace ContractLibrary.Testing
{
    [Collection(EthereumClientIntegrationFixture.ETHEREUM_CLIENT_COLLECTION_DEFAULT)]
    public class TransferEtherTests
    {
        private readonly EthereumClientIntegrationFixture _ethereumClientIntegrationFixture;

        public TransferEtherTests(EthereumClientIntegrationFixture ethereumClientIntegrationFixture)
        {
            _ethereumClientIntegrationFixture = ethereumClientIntegrationFixture;
        }

        [Fact]
        public async void ShouldTransferEtherWithGasPrice()
        {
            
            var web3 = _ethereumClientIntegrationFixture.GetWeb3();

            //Example of using Legacy instead of 1559
            if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Ganache)
            {
                web3.TransactionManager.UseLegacyAsDefault = true;
            }

            var toAddress = "0xde0B295669a9FD93d5F28D9Ec85E40f4cb697BAe";
            var balanceOriginal = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            var balanceOriginalEther = Web3.Convert.FromWei(balanceOriginal.Value);
            var receipt = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, 1.11m, 2);

            var balance = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            Assert.Equal(balanceOriginalEther + 1.11m, Web3.Convert.FromWei(balance));
        }

        [Fact]
        public async void ShouldTransferEther()
        {
            var web3 = _ethereumClientIntegrationFixture.GetWeb3();

            //Example of using Legacy instead of 1559
            if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Ganache)
            {
                web3.TransactionManager.UseLegacyAsDefault = true;
            }

            var toAddress = "0xde0B295669a9FD93d5F28D9Ec85E40f4cb697BA1";
            var balanceOriginal = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            var balanceOriginalEther = Web3.Convert.FromWei(balanceOriginal.Value);

            var receipt = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, 1.11m);

            var balance = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            Assert.Equal(balanceOriginalEther + 1.11m, Web3.Convert.FromWei(balance));
        }

        [Fact]
        public async void ShouldTransferEtherWithGasPriceAndGasAmount()
        {
            var web3 = _ethereumClientIntegrationFixture.GetWeb3();

            //Example of using Legacy instead of 1559
            if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Ganache)
            {
                web3.TransactionManager.UseLegacyAsDefault = true;
            }

            var toAddress = "0xde0B295669a9FD93d5F28D9Ec85E40f4cb697BA1";
            var balanceOriginal = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            var balanceOriginalEther = Web3.Convert.FromWei(balanceOriginal.Value);

            var receipt = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, 1.11m, (decimal)2, new BigInteger(25000));

            var balance = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            Assert.Equal(balanceOriginalEther + 1.11m, Web3.Convert.FromWei(balance));
        }

        [Fact]
        public async void ShouldTransferEtherEstimatingAmount()
        {
            var web3 = _ethereumClientIntegrationFixture.GetWeb3();

            //Example of using Legacy instead of 1559
            if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Ganache)
            {
                web3.TransactionManager.UseLegacyAsDefault = true;
            }

            var toAddress = "0xde0B295669a9FD93d5F28D9Ec85E40f4cb697BA1";
            var balanceOriginal = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            var balanceOriginalEther = Web3.Convert.FromWei(balanceOriginal.Value);
            var transferService = web3.Eth.GetEtherTransferService();
            var estimate = await transferService.EstimateGasAsync(toAddress, 1.11m);
            var receipt = await transferService
                .TransferEtherAndWaitForReceiptAsync(toAddress, 1.11m, (decimal)2, estimate);

            var balance = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            Assert.Equal(balanceOriginalEther + 1.11m, Web3.Convert.FromWei(balance));
        }

        [Fact]
        public async void ShouldTransferWholeBalanceInEtherUsingGasPrice()
        {
            var web3 = _ethereumClientIntegrationFixture.GetWeb3();
            //Example of using Legacy instead of 1559
            if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Ganache)
            {
                web3.TransactionManager.UseLegacyAsDefault = true;
            }

            var privateKey = EthECKey.GenerateKey();
            var newAccount = new Account(privateKey.GetPrivateKey(), EthereumClientIntegrationFixture.ChainId);
            var toAddress = newAccount.Address;
            var transferService = web3.Eth.GetEtherTransferService();

            var receipt = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, 1000, 2);

            var balance = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
            Assert.Equal(1000, Web3.Convert.FromWei(balance));

            var gasPriceInGwei = 1.3M;
            var totalAmountBack =
                await transferService.CalculateTotalAmountToTransferWholeBalanceInEtherAsync(toAddress,gasPriceInGwei);

            var web32 = new Web3(newAccount, web3.Client);
            var receiptBack = await web32.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(EthereumClientIntegrationFixture.AccountAddress, totalAmountBack, gasPriceInGwei);

            var balanceFrom = await web32.Eth.GetBalance.SendRequestAsync(toAddress);
            Assert.Equal(0, Web3.Convert.FromWei(balanceFrom));
        }

        [Fact]
        public async void ShouldTransferWholeBalanceInEtherUsing1559MaxPriorityFeeAndMedianPriorityStrategy()
        {
            //Example of using Legacy instead of 1559
            if (_ethereumClientIntegrationFixture.EthereumClient != EthereumClient.Ganache)
            {
                
           
                var web3 = _ethereumClientIntegrationFixture.GetWeb3();

             

                var privateKey = EthECKey.GenerateKey();
                var newAccount = new Account(privateKey.GetPrivateKey(), EthereumClientIntegrationFixture.ChainId);
                var toAddress = newAccount.Address;
                var transferService = web3.Eth.GetEtherTransferService();

                var receipt = await web3.Eth.GetEtherTransferService()
                    .TransferEtherAndWaitForReceiptAsync(toAddress, 1000, 2);

                var balance = await web3.Eth.GetBalance.SendRequestAsync(toAddress);
                Assert.Equal(1000, Web3.Convert.FromWei(balance));

                // using the Median Priority fee strategy
                var feeStrategy = new MedianPriorityFeeHistorySuggestionStrategy(web3.Client);
                var fee = await feeStrategy.SuggestFeeAsync();

                //when calculating the total amount to transfer, we only use the MaxFeePerGas so no crumbs are left
                var totalAmountBack =
                    await transferService.CalculateTotalAmountToTransferWholeBalanceInEtherAsync(toAddress, fee.MaxFeePerGas.Value);

                var web32 = new Web3(newAccount, web3.Client);
                //Example of using Legacy instead of 1559
                if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Ganache)
                {
                    web32.TransactionManager.UseLegacyAsDefault = true;
                }

                var receiptBack = await web32.Eth.GetEtherTransferService()
                    .TransferEtherAndWaitForReceiptAsync(EthereumClientIntegrationFixture.AccountAddress, totalAmountBack, fee.MaxFeePerGas.Value, fee.MaxFeePerGas.Value);

                var balanceFrom = await web32.Eth.GetBalance.SendRequestAsync(toAddress);
                Assert.Equal(0, Web3.Convert.FromWei(balanceFrom));
                }
        }
    }
}