using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleSmartContractCallApp.Entities;
using SampleSmartContractCallApp.Models;
using SampleSmartContractCallApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSmartContractCallApp.Controllers
{
    [Route("contractCall")]
    public class ContractCallController : Controller
    {
        private readonly SmartContractService smartContractService;
        public ContractCallController(SmartContractService smartContractService)
        {
            this.smartContractService = smartContractService;
        }

        [HttpPost]
        [Route("getowneraddress")]
        public async Task<IActionResult> OwnerAddress([FromBody] string senderAddress)
        {
            if (string.IsNullOrEmpty(senderAddress))
                return this.BadRequest("Please provide Sender Address!!");

            APIRequestResponse response = await this.smartContractService.GetOwnerSmartContractCall(senderAddress);
            if (response.IsSuccess)
            {
                return this.Ok(response.Content.ToString());
            }

            if (response.Content?.errors != null)
                return this.BadRequest($"An error occurred trying to get owner address: {response.Content?.errors[0].message}");

            return this.BadRequest($"An error occurred trying to get owner address: {response.Content}");
        }

    }
}
