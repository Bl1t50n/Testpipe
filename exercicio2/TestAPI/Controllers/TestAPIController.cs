using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestsAutomation;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        private readonly ILogger<TestAPIController> _logger;

        public TestAPIController(ILogger<TestAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "RunTest")]
        public bool RunTest()
        {
            return (new TestAutomation()).RunTestOne().GetAwaiter().GetResult();
        }

        [HttpGet("TestTwo")]
        public bool RunTestTwo()
        {
            return (new TestAutomation()).RunTestTwo().GetAwaiter().GetResult();
        }

        [HttpGet("TestThree")]
        public bool RunTestThree()
        {
            return (new TestAutomation()).RunTestThree().GetAwaiter().GetResult();
        }

    }
}