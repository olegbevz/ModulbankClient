using System.Net;

namespace ModulbankClient
{
    internal interface IAuthorizationStategy
    {
        void SetAuthorizationHeaders(WebRequest webRequest);
    }
}
