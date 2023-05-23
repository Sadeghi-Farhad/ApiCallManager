# ApiCallManager
REST API call manager

## How to use ApiManager in ASP.NET Core Web API Project
in asp.net core web api project you should add ApiManager in Service Container:

```
builder.Services.AddHttpClient();
builder.Services.AddScoped<ApiCallManager.IApiManager, ApiCallManager.ApiManager>();
```
<sub>Note that if you dont want to use HttpClientFactory, you can remove `builder.Services.AddHttpClient();`</sub>

Then Inject ApiManager service where you want and use it.
In below example code ApiManager service injected into TestController:

```
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
```

## How to use ApiManager in Console or Windows Application Projects


