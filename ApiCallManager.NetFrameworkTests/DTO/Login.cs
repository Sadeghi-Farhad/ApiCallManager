namespace ApiCallManager.NetFramework.Tests.DTO
{
    public class LoginReq
    {
        public string ClientIP { get; set; }
        public string AppId { get; set; }
        public string UserName { get; set; }

        public LoginReq()
        {
            ClientIP = string.Empty;
            AppId = "c8ddcf8c-6d37-4cf1-9184-80043ddfb808";
            UserName = "114755";
        }
    }

    public class LoginConfirmReq
    {
        public string AppId { get; set; }
        public string UserName { get; set; }
        public string ConfirmToken { get; set; }

        public LoginConfirmReq(string confirmToken)
        {
            AppId = "c8ddcf8c-6d37-4cf1-9184-80043ddfb808";
            UserName = "114755";
            ConfirmToken = confirmToken;
        }
    }

    public class AuthData
    {
        public bool result { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Errors { get; set; }
    }
}
