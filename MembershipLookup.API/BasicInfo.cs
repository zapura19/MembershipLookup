using System; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MembershipLookup.API.Services;

namespace MembershipLookup.API
{
    public class BasicInfo
    {
        private IConfigReaderService _readerService;
        public BasicInfo(IConfigReaderService readerService) {
            _readerService = readerService;
        }

        [FunctionName("Version")]
        public async Task<IActionResult> GetVersion(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "basicinfo/version")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetVersion HTTP trigger function processed a request.");

            //get version string from app settings
            string responseMessage = $"version {_readerService.GetConfigValue("Version")}";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Health")]
        public async Task<IActionResult> CheckHealth(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", "patch", "delete", Route = "basicinfo/healthstatus")] HttpRequest req,
            ILogger log)
        {
            //set start time
            var startTime = DateTime.Now.TimeOfDay;

            log.LogInformation("CheckHealth HTTP trigger function processed a request.");

            //identify request method
            var method = req.Method;

            //set end time
            var endTime = DateTime.Now.TimeOfDay;

            //calculate timespan
            TimeSpan span = endTime - startTime;
            int ms = (int)span.TotalMilliseconds;

            return new OkObjectResult($"The response time is {ms} milliseconds when using the {method} method.");
        }
    }
}
