using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCallManager
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public ValidationProblemDetails? Problem { get; set; }

        public override string ToString()
        {
            string result = JsonConvert.SerializeObject(this);
            return result;
        }
    }

    public class ApiResult<T> : ApiResult
    {
        public T Result { get; set; }

        public override string ToString()
        {
            string result = JsonConvert.SerializeObject(this);
            return result;
        }
    }
}