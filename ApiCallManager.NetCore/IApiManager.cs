namespace ApiCallManager
{
    public interface IApiManager
    {
        /// <summary>
        /// Send a Get request to specified address and get TResponse object as response.
        /// </summary>
        /// <remarks>
        /// this function call API with specified parameters and recieve json result. then convert recieved json to <typeparamref name="TResponse"/> output.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <param name="param">name and value of parameter</param>
        /// <returns>API response object in <typeparamref name="TResponse"/> type.</returns>
        Task<ApiResult<TResponse>> GetAsync<TResponse>(string address, bool sendAuthorizationHeader = false, string accesstoken = "", params Tuple<string, string>[] param);

        /// <summary>
        /// Send a TRequest object over the Post request to specified address and get TResponse object as response.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result. then convert recieved json to <typeparamref name="TResponse"/> output.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <returns>API response object in <typeparamref name="TResponse"/> type.</returns>
        Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string address, TRequest input, bool sendAuthorizationHeader = false, string accesstoken = "");

        /// <summary>
        /// Send a TRequest object over the Post request to specified address.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <returns>Call status object.</returns>
        Task<ApiResult> PostNoResultAsync<TRequest>(string address, TRequest input, bool sendAuthorizationHeader = false, string accesstoken = "");

        /// <summary>
        /// Send a TRequest object over the Put request to specified address and get TResponse object as response.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result. then convert recieved json to <typeparamref name="TResponse"/> output.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <returns>API response object in <typeparamref name="TResponse"/> type.</returns>
        Task<ApiResult<TResponse>> PutAsync<TRequest, TResponse>(string address, TRequest input, bool sendAuthorizationHeader = false, string accesstoken = "");

        /// <summary>
        /// Send a TRequest object over the Put request to specified address.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <returns>Call status object.</returns>
        Task<ApiResult> PutNoResultAsync<TRequest>(string address, TRequest input, bool sendAuthorizationHeader = false, string accesstoken = "");

        /// <summary>
        /// Send a TRequest object over the Put request to specified address and get TResponse object as response.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result. then convert recieved json to <typeparamref name="TResponse"/> output.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <returns>API response object in <typeparamref name="TResponse"/> type.</returns>
        Task<ApiResult<TResponse>> PatchAsync<TRequest, TResponse>(string address, TRequest input, bool sendAuthorizationHeader = false, string accesstoken = "");

        /// <summary>
        /// Send a TRequest object over the Put request to specified address.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <returns>Call status object.</returns>
        Task<ApiResult> PatchNoResultAsync<TRequest>(string address, TRequest input, bool sendAuthorizationHeader = false, string accesstoken = "");

        /// <summary>
        /// Send a Delete request to specified address and get TResponse object as response.
        /// </summary>
        /// <remarks>
        /// this function call API with specified parameters and recieve json result. then convert recieved json to <typeparamref name="TResponse"/> output.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <param name="param">name and value of parameter</param>
        /// <returns>API response object in <typeparamref name="TResponse"/> type.</returns>
        Task<ApiResult<TResponse>> DeleteAsync<TResponse>(string address, bool sendAuthorizationHeader = false, string accesstoken = "", params Tuple<string, string>[] param);

        /// <summary>
        /// Send a Delete request to specified address.
        /// </summary>
        /// <remarks>
        /// this function call API with specified parameters and recieve json result. then convert recieved json to <typeparamref name="TResponse"/> output.
        /// </remarks>
        /// <param name="address">API address. for example: "/pb/SearchPbPersonnels"</param>
        /// <param name="accesstoken">Access token. this parameter send in Authorization Header to API.</param>
        /// <param name="param">name and value of parameter</param>
        /// <returns>API response object in <typeparamref name="TResponse"/> type.</returns>
        Task<ApiResult> DeleteNoResultAsync(string address, bool sendAuthorizationHeader = false, string accesstoken = "", params Tuple<string, string>[] param);

        void SetTokens(string accessToken, string refreshToken, string refreshUrl, bool autoRefreshTokenIfExpired, Action<string, string>? onRefreshToken = null);
        void SetTokenProvider(Func<string> accessTokenProvider);
        void SetTokenProvider(Func<Task<string>> accessTokenProvider);
        void SetBasicCredential(string username, string password);
        void SetCustomAuthorizationHeader(string token);

        Task<bool> RefreshTokens();
        void SetTimeOut(int timeout);
    }
}