using ApiCallManager.NetFramework.Tests.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ApiCallManager.NetFramework.Tests
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
    }
}