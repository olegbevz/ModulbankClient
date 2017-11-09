using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ModulbankClient
{
    public class ModulbankClient : IModulbankClient
    {
        private const string accountInfoUrl = "account-info";
        private const string operationHistoryUrl = "operation-history";
        private const string balanceUrl = "account-info/balance";
        private const string apiVersion = "v1";
        private const string contentType = "application/json";

        private static readonly JsonSerializer jsonSerializer = new JsonSerializer();
        private readonly IAuthorizationStategy authorization;
        private string apiHost = "api.modulbank.ru";        

        static ModulbankClient()
        {
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public static ModulbankClient CreateSandboxClient()
        {
            return new ModulbankClient(new SandboxAuthorization());
        }

        public ModulbankClient(string accessToken) : this(new AccessTokenAuthorization(accessToken))
        {
        }

        private ModulbankClient(IAuthorizationStategy authorization)
        {
            this.authorization = authorization;
        }

        public void SetApiHost(string apiHost)
        {
            this.apiHost = apiHost;
        }

        public IEnumerable<Company> GetAccountInfo()
        {
            return ExecuteRequest<IEnumerable<Company>>(accountInfoUrl);
        }

        public double GetBalance(Guid bankAccountId)
        {
            return ExecuteRequest<double>($"{balanceUrl}/{bankAccountId}");
        }

        public IEnumerable<Operation> GetOperationHistory(Guid bankAccountId, OperationCondition condition)
        {
            return ExecuteRequest<IEnumerable<Operation>>($"{operationHistoryUrl}/{bankAccountId}", condition);
        }

        #region Async public methods

        public async Task<IEnumerable<Company>> GetAccountInfoAsync()
        {
            return await ExecuteRequestAsync<IEnumerable<Company>>(accountInfoUrl);
        }

        public async Task<double> GetBalanceAsync(Guid bankAccountId)
        {
            return await ExecuteRequestAsync<double>($"{balanceUrl}/{bankAccountId}");
        }

        public async Task<IEnumerable<Operation>> GetOperationHistoryAsync(Guid bankAccountId, OperationCondition condition)
        {
            return await ExecuteRequestAsync<IEnumerable<Operation>>($"{operationHistoryUrl}/{bankAccountId}", condition);
        }

        #endregion

        #region Private methods

        private T ExecuteRequest<T>(string requestUrl, object requestBody = null)
        {
            WebRequest webRequest = CreateWebRequest(requestUrl);
            if (requestBody != null)
                WriteWebRequestBody(webRequest, requestBody);

            var webResponse = webRequest.GetResponse();
            return ParseResponseStream<T>(webResponse);
        }

        private async Task<T> ExecuteRequestAsync<T>(string requestUrl, object requestBody = null)
        {
            WebRequest webRequest = CreateWebRequest(requestUrl);
            if (requestBody != null)
                WriteWebRequestBody(webRequest, requestBody);

            var webResponse = await webRequest.GetResponseAsync();
            return ParseResponseStream<T>(webResponse);
        }

        private void WriteWebRequestBody(WebRequest webRequest, object requestBody)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    using (var jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonSerializer.Serialize(jsonWriter, requestBody);
                        streamWriter.Flush();

                        webRequest.ContentLength = memoryStream.Length;
                        memoryStream.Position = 0;

                        using (var requestStream = webRequest.GetRequestStream())
                        {
                            memoryStream.CopyTo(requestStream);
                        }
                    }
                }
            }
        }

        private T ParseResponseStream<T>(WebResponse webResponse)
        {
            using (var responseStream = webResponse.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return jsonSerializer.Deserialize<T>(jsonReader);
                    }
                }
            }
        }

        private WebRequest CreateWebRequest(string requestUrl)
        {
            var webRequest = WebRequest.Create($"https://{apiHost}/{apiVersion}/{requestUrl}");
            webRequest.Method = WebRequestMethods.Http.Post;
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = 0;
            authorization.SetAuthorizationHeaders(webRequest);
            return webRequest;
        }

        #endregion
    }
}
