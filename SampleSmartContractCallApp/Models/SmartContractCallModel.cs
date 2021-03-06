using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSmartContractCallApp.Models
{
    public class SmartContractCallModel
    {
        public string WalletName { get; set; }
        public string AccountName { get; set; }
        public int Amount { get; set; }
        public double FeeAmount { get; set; }
        public string Password { get; set; }
        public int GasPrice { get; set; }
        public int GasLimit { get; set; }
        public string Sender { get; set; }
        public string ContractAddress { get; set; }
        public string MethodName { get; set; }
        public string[] Parameters { get; set; }
    }
}
