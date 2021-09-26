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


            // For a production environment you probably want to use Microsoft.AspNetCore.Components.WebAssembly.Authentication
            // for Access control
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSingleton<IAccessTokenProvider, AuthenticationManager>();
            builder.Services.AddTransient<TokenBasedAuthenticationHandler>();

            builder.Services.AddHttpClient("openria")
                .AddHttpMessageHandler< TokenBasedAuthenticationHandler>();

            var provider = builder.Services.BuildServiceProvider();

            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();

            DomainContext.DomainClientFactory = new OpenRiaServices.Client.DomainClients.BinaryHttpDomainClientFactory(
                () => httpClientFactory.CreateClient("openria"))
            {
                ServerBaseUri = new Uri(host, UriKind.Absolute)
            };

            return builder.Build().RunAsync();
        }
    }
}
