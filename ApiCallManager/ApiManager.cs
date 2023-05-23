using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<ApiResult<TResponse>> PostAsync<TRequest, TResponse>(string address, TRequest input, bool sendAccessToken = false, string accesstoken = "")
        {
            ApiResult<TResponse> res = new ApiResult<TResponse>()
            {
                IsSuccess = false,
                Problem = null
            };

            try
            {
                using (var httpClient = CreateHttpClient())
                {
                    AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(ApiHostUrl + address, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        if (typeof(TResponse) != typeof(string))
                        {
                            var result = JsonConvert.DeserializeObject<TResponse>(responseContent);

                            res.IsSuccess = true;
                            res.Result = result;
                        }
                        else
                        {
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
                            Title = $"API Connection Error({address})",
                            Detail = string.Empty,
                            Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                        };
                    }
                    else if (sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired && (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.MethodNotAllowed))
                    {
                        bool refreshSuccess = await RefreshTokens();

                        return await PostAsync<TRequest, TResponse>(address, input, true, AccessToken);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
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
                                Title = $"API Error({address})",
                                Detail = string.Empty,
                                Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.server_unexpected_error,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = $"API Manager Error({address})",
                    Detail = ex.Message,
                    Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                };
            }

            return res;
        }

        public async Task<ApiResult> PostNoResultAsync<TRequest>(string address, TRequest input, bool sendAccessToken = false, string accesstoken = "")
        {
            ApiResult res = new ApiResult()
            {
                IsSuccess = false,
                Problem = null
            };

            try
            {
                using (var httpClient = CreateHttpClient())
                {
                    AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(ApiHostUrl + address, content);

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
                            Title = $"API Connection Error({address})",
                            Detail = string.Empty,
                            Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                        };
                    }
                    else if (sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired && (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.MethodNotAllowed))
                    {
                        bool refreshSuccess = await RefreshTokens();

                        return await PostNoResultAsync<TRequest>(address, input, true, AccessToken);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
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
                                Title = $"API Error({address})",
                                Detail = string.Empty,
                                Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.server_unexpected_error,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = $"API Manager Error({address})",
                    Detail = ex.Message,
                    Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                };
            }

            return res;
        }

        public async Task<ApiResult<TResponse>> GetAsync<TResponse>(string address, bool sendAccessToken = false, string accesstoken = "", params Tuple<string, string>[] param)
        {
            ApiResult<TResponse> res = new ApiResult<TResponse>()
            {
                IsSuccess = false,
                Problem = null
            };

            try
            {
                using (var httpClient = CreateHttpClient())
                {
                    AddAuthorizationHeader(httpClient, sendAccessToken, accesstoken);

                    string s = "";
                    if (param.Length > 0) s = "?" + string.Join("&", param.Select(x => x.Item1 + "=" + x.Item2));

                    var response = await httpClient.GetAsync(ApiHostUrl + address + s);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        if (typeof(TResponse) != typeof(string))
                        {
                            var result = JsonConvert.DeserializeObject<TResponse>(responseContent);

                            res.IsSuccess = true;
                            res.Result = result;
                        }
                        else
                        {
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
                            Title = $"API Connection Error({address})",
                            Detail = string.Empty,
                            Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                        };
                    }
                    else if (sendAccessToken && accesstoken == "" && AccessToken != "" && AutoRefreshTokenIfExpired && (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.MethodNotAllowed))
                    {
                        bool refreshSuccess = await RefreshTokens();

                        return await GetAsync<TResponse>(address, true, AccessToken, param);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
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
                                Title = $"API Error({address})",
                                Detail = string.Empty,
                                Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Problem = new ValidationProblemDetails()
                {
                    Type = ErrorTypes.server_unexpected_error,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = $"API Manager Error({address})",
                    Detail = ex.Message,
                    Instance = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name
                };
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
