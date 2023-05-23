using ApiCallManager;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceTester.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private IApiManager _apiManager;
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger, IApiManager apiManager)
        {
            _apiManager = apiManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _apiManager.GetAsync<List<User>>("https://gorest.co.in/public/v2/users");

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            else
            {
                return Problem(
                        type: result?.Problem?.Type,
                        statusCode: result?.Problem?.Status,
                        title: result?.Problem?.Title,
                        detail: result?.Problem?.Detail
                    );
            }
        }
    }
}