using ApiCallManager.Tests.DTO;
using System.Diagnostics;

namespace ApiCallManager.Tests
{
    [TestClass]
    public class ApiManagerTests2
    {
        private string AccessToken = string.Empty;
        private string RefreshToken = string.Empty;
        private string OtpCode = "963917";

        private ApiManager Create()
        {
            return new ApiManager("https://gateway.crouseco.com");
        }

        [TestMethod]
        public async Task Test_PostAsync_AutoRefresh()
        {
            Debug.WriteLine("--Test_PostAsync_AutoRefreshToken 1");
            ApiManager apiManager = Create();
            var res = await apiManager.PostAsync<LoginConfirmReq, AuthData>("/auth/auth/loginconfirm", new LoginConfirmReq(OtpCode));
            Assert.IsTrue(res.IsSuccess);
            Assert.IsNotNull(res.Result);
            Assert.IsNotNull(res.Result.AccessToken);
            Assert.IsNotNull(res.Result.RefreshToken);

            Debug.WriteLine("--Test_PostAsync_AutoRefreshToken 2");
            apiManager.SetTokens(res.Result.AccessToken, res.Result.RefreshToken, "/auth/auth/refresh", true, OnTokenRefreshed);
            await Task.Delay(TimeSpan.FromMinutes(7));

            Debug.WriteLine("--Test_PostAsync_AutoRefreshToken 3");
            var res2 = await apiManager.GetAsync<string>("/pb/Pb/GetMyManagersInfo", true, "", Tuple.Create("PrsCode", "114755"));
            Assert.IsTrue(res2.IsSuccess);
            Assert.IsNotNull(res2.Result);

            Debug.WriteLine("--Test_PostAsync_AutoRefreshToken 4");
            await Task.Delay(TimeSpan.FromSeconds(10));
            Assert.AreNotEqual(AccessToken, string.Empty);
            Assert.AreNotEqual(RefreshToken, string.Empty);
        }

        public void OnTokenRefreshed(string aToken, string rToken)
        {
            AccessToken = aToken;
            RefreshToken = rToken;
        }
    }
}
