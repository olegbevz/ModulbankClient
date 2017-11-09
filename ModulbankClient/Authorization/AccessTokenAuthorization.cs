using System.Net;

namespace ModulbankClient
{
    internal class AccessTokenAuthorization : IAuthorizationStategy
    {
        private readonly string accessToken;

        public AccessTokenAuthorization(string token)
        {
            this.accessToken = token;
        }

        public void SetAuthorizationHeaders(WebRequest webRequest)
        {
            webRequest.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {accessToken}");
        }
    }
}
