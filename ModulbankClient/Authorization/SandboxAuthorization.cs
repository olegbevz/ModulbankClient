using System.Net;

namespace ModulbankClient
{
    internal class SandboxAuthorization : IAuthorizationStategy
    {
        public void SetAuthorizationHeaders(WebRequest webRequest)
        {
            webRequest.Headers.Add("sandbox", "on");
            webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer sandboxtoken");
        }
    }
}
