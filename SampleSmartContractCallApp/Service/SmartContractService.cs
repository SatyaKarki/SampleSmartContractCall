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
        private readonly CommonAPIRequestService commonAPIRequestService;
        private string defaultEndPoint="http://localhost:38223";
        public SmartContractService(CommonAPIRequestService commonAPIRequestService)
        {
            this.commonAPIRequestService = commonAPIRequestService;
        }    
        
        public async Task<APIRequestResponse> GetOwnerSmartContractCall(string senderAddress)
        {
            string ownerContractAddress = "";
            try
            {                
                var smartContractLocalCall = new SmartContractLocalCallModel
                {
                    GasPrice = 100,
                    GasLimit = 50000,
                    Amount = 0,
                    MethodName = "GetOwner",
                    ContractAddress = "PNhr8Qo9tbmVXyzz38xnBVm9oceJqzD8Q5",
                    Sender =senderAddress,
                    Parameters =null, 
                    };

                    APIRequestResponse response = await commonAPIRequestService.PostRequestAsync(defaultEndPoint, "/api/SmartContracts/local-call", smartContractLocalCall).ConfigureAwait(false);

                    return response;                
            }
            catch (Exception ex)
            {
              
            }

            return null;
        }

    }
}
