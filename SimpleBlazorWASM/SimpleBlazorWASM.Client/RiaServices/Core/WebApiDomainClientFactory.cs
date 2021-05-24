using System;
using System.Net.Http;
using Blazored.LocalStorage;
using SimpleBlazorWASM.Client.Model.Security;

namespace OpenRiaServices.Client.PortableWeb
{
    public class WebApiDomainClientFactory : DomainClientFactory
    {
        public ISyncLocalStorageService LocalStorageService { get; }
        public HttpClientHandler HttpClientHandler { get; }

        public WebApiDomainClientFactory(ISyncLocalStorageService localStorageService)
        {
            LocalStorageService = localStorageService;
            HttpClientHandler = new HttpClientHandler();

        }

        protected override DomainClient CreateDomainClientCore(Type serviceContract, Uri serviceUri, bool requiresSecureEndpoint)
        {
            var tokenResponse = LocalStorageService.GetItem<TokenResponse>(nameof(TokenResponse));
            string token = null;
            if (tokenResponse != null && !tokenResponse.IsExpired)
            {
                token = tokenResponse.AccessToken;
            }
            return new WebApiDomainClient(serviceContract, serviceUri, HttpClientHandler, token);
        }

        
    }
}
