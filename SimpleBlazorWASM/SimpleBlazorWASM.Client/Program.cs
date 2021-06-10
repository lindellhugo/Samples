using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using OpenRiaServices.Client;

namespace SimpleBlazorWASM.Client
{

    public class Program
    {
        public static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var host = builder.Configuration["Host"];

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(host),
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSingleton<AuthenticationManager>(prov =>
                new AuthenticationManager(prov.GetRequiredService<ILocalStorageService>()));
            builder.Services.AddSingleton<IAccessTokenProvider>(prov =>
               prov.GetRequiredService<AuthenticationManager>());

            var provider = builder.Services.BuildServiceProvider();

            var tokenProver = provider.GetRequiredService<IAccessTokenProvider>();
            DomainContext.DomainClientFactory = new OpenRiaServices.Client.PortableWeb.WebApiDomainClientFactory(
                new TokenBasedAuthenticationHandler(
                    new HttpClientHandler()
                    {
                    }, tokenProver)
                )
            {
                ServerBaseUri = new Uri(host, UriKind.Absolute)
            };

            return builder.Build().RunAsync();
        }
    }
}
