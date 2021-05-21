using OpenRiaServices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using SimpleBlazorWASM.Client.Model.Security;

namespace OpenRiaServices.Client.PortableWeb
{
    public class WebApiDomainClientFactory : DomainClientFactory
    {
        public WebApiDomainClientFactory(HttpClient httpClient, Blazored.LocalStorage.ISyncLocalStorageService localStorageService)
        {
            HttpClient = httpClient;
            var tokenResponse = localStorageService.GetItem<TokenResponse>(nameof(TokenResponse));
            if (tokenResponse != null && !tokenResponse.IsExpired)
            {

                HttpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                        tokenResponse.AccessToken);
            }
        }

        protected override DomainClient CreateDomainClientCore(Type serviceContract, Uri serviceUri, bool requiresSecureEndpoint)
        {
            return new WebApiDomainClient(serviceContract, serviceUri, HttpClient);
        }

        public HttpClient HttpClient { get; }
    }
}