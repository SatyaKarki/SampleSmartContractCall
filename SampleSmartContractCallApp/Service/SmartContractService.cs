using Newtonsoft.Json;
using SampleSmartContractCallApp.Entities;
using SampleSmartContractCallApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSmartContractCallApp.Service
{
    public class SmartContractService
    {
        private readonly CommonAPIRequestService _commonAPIRequestService;
        private string _defaultEndPoint="http://localhost:38223";
        private string _contractAddress= "PNhr8Qo9tbmVXyzz38xnBVm9oceJqzD8Q5";
        public SmartContractService(CommonAPIRequestService commonAPIRequestService)
        {
            _commonAPIRequestService = commonAPIRequestService;
        }    
        
        public async Task<APIRequestResponse> GetOwnerSmartContractCall(string senderAddress)
        {
            try
            {                
                var smartContractLocalCall = new SmartContractLocalCallModel
                {
                    GasPrice = 100,
                    GasLimit = 50000,
                    Amount = 0,
                    MethodName = "GetOwner",
                    ContractAddress =_contractAddress,
                    Sender =senderAddress,
                    Parameters =null, 
                    };

                    APIRequestResponse response = await _commonAPIRequestService.PostRequestAsync(_defaultEndPoint, "/api/SmartContracts/local-call", smartContractLocalCall).ConfigureAwait(false);

                    return response;                
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
