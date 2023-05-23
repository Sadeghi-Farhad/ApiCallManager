using ApiCallManager;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            else if (result.Problem != null)
            {
                return Problem(
                        type: result.Problem.Type,
                        statusCode: result.Problem.Status,
                        title: result.Problem.Title,
                        detail: result.Problem.Detail
                    );
            }
            else
            {
                return Problem(
                    type: ErrorTypes.server_unexpected_error,
                    statusCode: (int)HttpStatusCode.InternalServerError
                );
            }
        }
    }
}