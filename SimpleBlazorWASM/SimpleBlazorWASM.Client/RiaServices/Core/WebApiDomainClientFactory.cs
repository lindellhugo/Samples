using System;
using System.Net.Http;
using Blazored.LocalStorage;
using SimpleBlazorWASM.Client.Model.Security;

namespace OpenRiaServices.Client.PortableWeb
{
    public class WebApiDomainClientFactory : DomainClientFactory
    {
        HttpMessageHandler HttpMessageHandler { get; }

        public WebApiDomainClientFactory(HttpMessageHandler httpMessageHandler)
        {
            HttpMessageHandler = httpMessageHandler;
        }

        protected override DomainClient CreateDomainClientCore(Type serviceContract, Uri serviceUri, bool requiresSecureEndpoint)
        {
           
            return new WebApiDomainClient(serviceContract, serviceUri, HttpMessageHandler);
        }

        
    }
}
