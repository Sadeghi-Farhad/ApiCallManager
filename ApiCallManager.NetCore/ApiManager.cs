using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace ApiCallManager
{
    public class ApiManager : IApiManager
    {
        private readonly string ApiHostUrl;
        private readonly IHttpClientFactory? HttpClientFactory;

        public string AccessToken = "";
        private string RefreshToken = "";
        private string RefreshUrl = "";
        private bool AutoRefreshTokenIfExpired = false;

        public ApiManager(string apiHostUrl = "", IHttpClientFactory? httpClientFactory = null)
        {
            ApiHostUrl = apiHostUrl;
            HttpClientFactory = httpClientFactory;
        }


        private bool TokenIsValid(string token)
        {
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
            }
            catch (Exception)
            {
                return false;
            }

            return jwtSecurityToken.ValidTo > DateTime.UtcNow;
        }

        private void AddAuthorizationHeader(HttpClient request, bool sendAccessToken, string token)
        {
            if (sendAccessToken)
            {
                if (!string.IsNullOrWhiteSpace(token))
                    request.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                else
                    request.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
            }
        }

        private HttpClient CreateHttpClient()
        {
            if (HttpClientFactory == null) return new HttpClient();
            else return HttpClientFactory.CreateClient();
        }


        public async Task<ApiResult<TResponse>> GetAsync<TResponse>(string address, bool sendAccessToken = false, string accesstoken = "", params Tuple<string, string>[] param)
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                string s = "";
                if (param.Length > 0) s = "?" + string.Join("&", param.Select(x => x.Item1 + "=" + x.Item2));

                var response = await httpClient.GetAsync(ApiHostUrl + address + s);
                ApiResult<TResponse> res = await CheckResponse<TResponse>(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await GetAsync<TResponse>(address, true, AccessToken, param);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult<TResponse>()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/GetAsync"
                    }
                };
            }
        }


        public async Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string address, TRequest input, bool sendAccessToken = false, string accesstoken = "")
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                HttpResponseMessage response;

                if (input?.GetType() == typeof(MultipartFormDataContent))
                {
                    response = await httpClient.PostAsync(ApiHostUrl + address, input as MultipartFormDataContent);
                }
                else
                {
                    StringContent content = new(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(ApiHostUrl + address, content);
                }

                ApiResult<TResponse> res = await CheckResponse<TResponse>(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await PostAsync<TRequest, TResponse>(address, input, true, AccessToken);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult<TResponse>()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/PostAsync"
                    }
                };
            }
        }

        public async Task<ApiResult> PostNoResultAsync<TRequest>(string address, TRequest input, bool sendAccessToken = false, string accesstoken = "")
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                HttpResponseMessage response;

                if (input?.GetType() == typeof(MultipartFormDataContent))
                {
                    response = await httpClient.PostAsync(ApiHostUrl + address, input as MultipartFormDataContent);
                }
                else
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(ApiHostUrl + address, content);
                }

                ApiResult res = await CheckResponse(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await PostNoResultAsync<TRequest>(address, input, true, AccessToken);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/PostNoResultAsync"
                    }
                };
            }
        }


        public async Task<ApiResult<TResponse>> PutAsync<TRequest, TResponse>(string address, TRequest input, bool sendAccessToken = false, string accesstoken = "")
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                HttpResponseMessage response;

                if (input?.GetType() == typeof(MultipartFormDataContent))
                {
                    response = await httpClient.PutAsync(ApiHostUrl + address, input as MultipartFormDataContent);
                }
                else
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    response = await httpClient.PutAsync(ApiHostUrl + address, content);
                }

                ApiResult<TResponse> res = await CheckResponse<TResponse>(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await PutAsync<TRequest, TResponse>(address, input, true, AccessToken);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult<TResponse>()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/PutAsync"
                    }
                };
            }
        }

        public async Task<ApiResult> PutNoResultAsync<TRequest>(string address, TRequest input, bool sendAccessToken = false, string accesstoken = "")
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                HttpResponseMessage response;

                if (input?.GetType() == typeof(MultipartFormDataContent))
                {
                    response = await httpClient.PutAsync(ApiHostUrl + address, input as MultipartFormDataContent);
                }
                else
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    response = await httpClient.PutAsync(ApiHostUrl + address, content);
                }

                ApiResult res = await CheckResponse(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await PutNoResultAsync<TRequest>(address, input, true, AccessToken);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/PutNoResultAsync"
                    }
                };
            }
        }


        public async Task<ApiResult<TResponse>> DeleteAsync<TResponse>(string address, bool sendAccessToken = false, string accesstoken = "", params Tuple<string, string>[] param)
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                string s = "";
                if (param.Length > 0) s = "?" + string.Join("&", param.Select(x => x.Item1 + "=" + x.Item2));

                var response = await httpClient.DeleteAsync(ApiHostUrl + address + s);

                ApiResult<TResponse> res = await CheckResponse<TResponse>(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await DeleteAsync<TResponse>(address, true, AccessToken, param);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult<TResponse>()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/DeleteAsync"
                    }
                };
            }
        }

        public async Task<ApiResult> DeleteNoResultAsync(string address, bool sendAccessToken = false, string accesstoken = "", params Tuple<string, string>[] param)
        {
            try
            {
                using var httpClient = CreateHttpClient();
                AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                string s = "";
                if (param.Length > 0) s = "?" + string.Join("&", param.Select(x => x.Item1 + "=" + x.Item2));

                var response = await httpClient.DeleteAsync(ApiHostUrl + address + s);

                ApiResult res = await CheckResponse(response);

                if (res.IsSuccess == false && res?.Problem?.Type == ErrorTypes.unauthorized && sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired)
                {
                    bool refreshSuccess = await RefreshTokens();

                    return await DeleteNoResultAsync(address, true, AccessToken, param);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = $"API Manager Error({address})",
                        Detail = ex.Message,
                        Instance = "ApiManager/DeleteNoResultAsync"
                    }
                };
            }
        }


        private static async Task<ApiResult<TResponse>> CheckResponse<TResponse>(HttpResponseMessage response)
        {
            ApiResult<TResponse> res = new()
            {
                IsSuccess = false,
                Problem = null
            };

            if (response.IsSuccessStatusCode)
            {
                if (typeof(TResponse) == typeof(FileContentResult))
                {
                    byte[] tmp = await response.Content.ReadAsByteArrayAsync();

                    object result = new FileContentResult(tmp, response.Content.Headers.ContentType.MediaType);

                    res.IsSuccess = true;
                    res.Result = (TResponse)result;
                }
                else if (typeof(TResponse) != typeof(string))
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResponse>(responseContent);

                    res.IsSuccess = true;
                    res.Result = result;
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    object result = responseContent;

                    res.IsSuccess = true;
                    res.Result = (TResponse)result;
                }
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.connection_error,
                    Status = (int)HttpStatusCode.BadGateway,
                    Title = $"API Connection Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                    Detail = string.Empty,
                    Instance = "ApiManager"
                };
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.unauthorized,
                    Status = (int)response.StatusCode,
                    Title = $"API Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                    Detail = string.Empty,
                    Instance = "ApiManager"
                };
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var data = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);

                    if (data != null)
                    {
                        res.IsSuccess = false;
                        res.Problem = data;
                    }
                    else
                    {
                        res.IsSuccess = false;
                        res.Problem = new ValidationProblemDetails()
                        {
                            Type = ErrorTypes.server_error,
                            Status = (int)response.StatusCode,
                            Title = $"API Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                            Detail = string.Empty,
                            Instance = "ApiManager"
                        };
                    }
                }
                catch (Exception ex)
                {
                    res.IsSuccess = false;
                    res.Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)response.StatusCode,
                        Title = $"API Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                        Detail = ex.Message,
                        Instance = "ApiManager"
                    };
                }
            }

            return res;
        }

        private static async Task<ApiResult> CheckResponse(HttpResponseMessage response)
        {
            ApiResult res = new()
            {
                IsSuccess = false,
                Problem = null
            };

            if (response.IsSuccessStatusCode)
            {
                res.IsSuccess = true;
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.connection_error,
                    Status = (int)HttpStatusCode.BadGateway,
                    Title = $"API Connection Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                    Detail = string.Empty,
                    Instance = "ApiManager"
                };
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.unauthorized,
                    Status = (int)response.StatusCode,
                    Title = $"API Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                    Detail = string.Empty,
                    Instance = "ApiManager"
                };
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var data = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);

                    if (data != null)
                    {
                        res.IsSuccess = false;
                        res.Problem = data;
                    }
                    else
                    {
                        res.IsSuccess = false;
                        res.Problem = new ValidationProblemDetails()
                        {
                            Type = ErrorTypes.server_error,
                            Status = (int)response.StatusCode,
                            Title = $"API Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                            Detail = string.Empty,
                            Instance = "ApiManager"
                        };
                    }
                }
                catch (Exception ex)
                {
                    res.IsSuccess = false;
                    res.Problem = new ValidationProblemDetails()
                    {
                        Type = ErrorTypes.server_unexpected_error,
                        Status = (int)response.StatusCode,
                        Title = $"API Error({response.RequestMessage?.RequestUri?.ToString() ?? ""})",
                        Detail = ex.Message,
                        Instance = "ApiManager"
                    };
                }
            }

            return res;
        }

        public void SetTokens(string accessToken, string refreshToken, string refreshUrl, bool autoRefreshTokenIfExpired)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            RefreshUrl = refreshUrl;
            AutoRefreshTokenIfExpired = autoRefreshTokenIfExpired;
        }

        public async Task<bool> RefreshTokens()
        {
            try
            {
                RefreshTokenDTO data = new RefreshTokenDTO()
                {
                    AccessToken = this.AccessToken,
                    RefreshToken = this.RefreshToken
                };

                var res = await PostAsync<RefreshTokenDTO, AuthResultDTO>(RefreshUrl, data);

                if (res.IsSuccess)
                {
                    this.AccessToken = res.Result.AccessToken;
                    this.RefreshToken = res.Result.RefreshToken;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
