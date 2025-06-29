using ApiCallManager.Tests.DTO;
using System.Reflection;

namespace ApiCallManager.Tests
{
    [TestClass]
    public class ApiManagerTests1
    {
        private ApiManager Create()
        {
            return new ApiManager("https://gateway.crouseco.com");
        }

        [TestMethod]
        public void Test_Create()
        {
            ApiManager apiManager = Create();
            Assert.IsNotNull(apiManager);
        }

        [TestMethod]
        public async Task Test_GetAsync1()
        {
            ApiManager apiManager = Create();
            var res = await apiManager.GetAsync<string>("/home");
            Assert.IsTrue(res.IsSuccess);
            Assert.IsNotNull(res.Result);
            StringAssert.StartsWith(res.Result.ToLower(), "welcom");
        }

        [TestMethod]
        public async Task Test_GetAsync2()
        {
            ApiManager apiManager = Create();
            var res = await apiManager.GetAsync<string>("/notfoundurl");
            Assert.IsFalse(res.IsSuccess);
            Assert.IsNotNull(res.Problem);
            Assert.IsNotNull(res.Problem.Status);
            Assert.AreEqual(404, res.Problem.Status.Value);
        }

        [TestMethod]
        public async Task Test_PostAsync_Login()
        {
            ApiManager apiManager = Create();
            var res = await apiManager.PostAsync<LoginReq, AuthData>("/auth/auth/login", new LoginReq());
            Assert.IsTrue(res.IsSuccess);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public async Task TestJellyfin()
        {
            string ServerAddress = "http://93.118.96.246:85/Users/AuthenticateByName";

            ApiManager apiManager = new ApiManager();

            string authHeader = "MediaBrowser Client=\"Jellyfin Web\", Device=\"Chrome\", DeviceId=\"TW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzEzNS4wLjAuMCBTYWZhcmkvNTM3LjM2fDE3NDYyNzQ5ODYyMDE1\", Version=\"10.10.7\"";
            apiManager.SetCustomAuthorizationHeader(authHeader);

            LoginRequestDto loginRequestDto = new LoginRequestDto() { Username = "farhad", Pw = "sadeghi*1366#" };
            var result = await apiManager.PostAsync<LoginRequestDto, string>(ServerAddress, loginRequestDto, true);

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task TestAuth()
        {
            string s = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIyMWQzZDU0ZC1lOGNmLTQ2MjYtYjI4YS03ZmNlMzBlODVjZjkiLCJhcHAiOiJjcm91c2Utc2VydmljZXMuY29tIiwiYXBwaWQiOiI0MTIwIiwicmVxIjoiMSIsInVuaXF1ZV9uYW1lIjoiMDkxMjUyMjU5NDkiLCJmYW1pbHlfbmFtZSI6IiIsImVtYWlsIjoiIiwiVmVuZG9yQ29kZSI6IjAwMDAzMDAxNDkiLCJuYmYiOjE3NDk2MjAzMTgsImV4cCI6MTc0OTYyMDQzOCwiaWF0IjoxNzQ5NjIwMzE4LCJpc3MiOiJodHRwczovL3NlcnZpY2UuY3JvdXNlLmlyIiwiYXVkIjoiQ3JvdXNlIFNlcnZpY2VzIn0.nBlhkdC9a-bz6yO6qf7_9WHAeL8YI-WUD32i5A_PmfTQrhVv-FD2Gr89om3HaQdD372TqfZZpFdTqfGXwqaKYpklZOnDj0mh8YdtLrQFbGry-wGKwtJ5p02ULT5NgFbXxD_oXKEpW6YPtpOMpcwjlnv0bywKf_J_O4V-gppFpm2PO9k4n1Gl7nR6NO59-mPUWmOCkn44k-WoW0C18uA5PqrEQ_n-sbRkoe3kbm_f2H_R1_XziLI32SyK7R0960Z_7YIiHTAT82VEZfdX3jvNMxbSq6e-inY3O-ExaNYRBBcheHKl_7Ad6oEZ43eeSFjAwMVhDpUkCMe2-Xui3w4U9kHdQC2qOJmgfWoEbUzcp-_2BKRka0iweQ8zmhZpRlrgzixPBbop0iw8LU92z7fiacZUMcpM2nUO8QfxHhdawBXqWU2aCJt6mtN_asNmLRdnu6YWz8F_7v1pT7gL2wHtXGKf22SydXM_VYIo15BPJnfk3x4CZ45THyJluIQfuAlBPWoYiKzls1NwZx3n8SENFUwRsjfMTb0tR6GnYdJIgaZ1G2snMagXWtHaIMUqbHFfDJQD6l1fAmxSNlqZ6K7bpYR8_ktaOqDbFOaHpAB98sWlvJPoTQWaC4DDbZeIl1f97dPKu2pXMfBgEjLxwWy6GXz53SxXlGwzhMHMMyxoIfU";
            string ServerAddress = "https://gateway2.crouse.ir";
            ApiManager apiManager = new ApiManager();

            var msg_Admin = await apiManager.GetAsync<AdminInfo>("https://gateway2.crouse.ir" + "/Auth/Users/UserInfoByMobile", true, s ?? "", Tuple.Create("mobile", "09125225949"));

            if(msg_Admin.IsSuccess)
            {
                var ss = msg_Admin.Result.Fname;
            }
        }
    }

    public class AdminInfo
    {

        public string? Prs_no { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
    }


    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Pw { get; set; } = string.Empty;
    }
}