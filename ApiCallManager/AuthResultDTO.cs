using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCallManager
{
    public class AuthResultDTO
    {
        public bool Result { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Errors { get; set; }
    }
}
