# ApiCallManager
REST API call manager

## How to use ApiManager in ASP.NET Core Web API Projects
in asp.net core web api project you should add ApiManager in Service Container:

```
builder.Services.AddHttpClient();
builder.Services.AddScoped<ApiCallManager.IApiManager, ApiCallManager.ApiManager>();
```
_Note that if you don't want to use HttpClientFactory, you can remove `builder.Services.AddHttpClient();` line_

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
```

## ** How to use ApiManager in Console or Windows Application Projects **
in console applications or windows applications you can create a static instance of ApiManager inside a Helper class or in program global scope.

```
public class ClassHelper
{
    public static IApiManager apiManager;

    public static void ShowApiCallError(ValidationProblemDetails? error)
    {
        if (error != null)
        {
            MessageBox.Show($"Title: {error?.Title ?? "-"}\n\rDetails: {error?.Detail ?? "-"}", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show($"An unknown error has occurred!", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

Then in program startup or main form loading initial defined static ApiManager object.
```
private void Form1_Load(object sender, EventArgs e)
{
    ClassHelper.apiManager = new ApiManager();
}
```

If you use Authorization in application, after user login to application and Access Token and Refresh Token recieved from Authorization server, Set Token in ApiManger:
```
private async void button_login_Click(object sender, EventArgs e)
{
    string username = textBox_username.Text;
    string password = textBox_password.Text;

    var res = await LoginAsync(username, password);
    if (res != null)
    {
        ClassHelper.apiManager.SetTokens(res.AccessToken, res.RefreshToken, "https://gorest.co.in/public/v2/refreshtoken", true);
    }
}
```

Congratulation, you now call any web api using ApiManger easily.
```
public async Task<List<User>?> GetUsersAsync()
{
    var result = await ClassHelper.apiManager.GetAsync<List<User>>("https://gorest.co.in/public/v2/users");

    if (result.IsSuccess)
    {
        return result.Result;
    }
    else
    {
        ClassHelper.ShowApiCallError(result.Problem);
        return null;
    }
}
```


