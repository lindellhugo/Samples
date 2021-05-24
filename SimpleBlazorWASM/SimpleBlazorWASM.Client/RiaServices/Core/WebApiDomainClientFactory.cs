using OpenRiaServices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace OpenRiaServices.Client.PortableWeb
{
    public class WebApiDomainClientFactory : DomainClientFactory
    {
        public WebApiDomainClientFactory()
        {
            HttpClientHandler = new HttpClientHandler()
            {
#if Xamarin
                CookieContainer = new System.Net.CookieContainer(),
                UseCookies = true
#endif
            };
        }

        protected override DomainClient CreateDomainClientCore(Type serviceContract, Uri serviceUri, bool requiresSecureEndpoint)
        {
            return new WebApiDomainClient(serviceContract, serviceUri, HttpClientHandler);
        }

        public HttpMessageHandler HttpClientHandler { get; set; }
    }
}
