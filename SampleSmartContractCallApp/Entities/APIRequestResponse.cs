using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSmartContractCallApp.Entities
{
    public class APIRequestResponse
    {
        public bool IsSuccess { get; set; }
        public dynamic Content { get; set; }
    }
}
