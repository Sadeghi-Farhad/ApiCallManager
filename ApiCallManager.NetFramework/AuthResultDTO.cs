namespace ApiCallManager.NetFramework
{
    public class AuthResultDTO
    {
        public bool Result { get; set; }
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public string Errors { get; set; } = "";
    }
}
