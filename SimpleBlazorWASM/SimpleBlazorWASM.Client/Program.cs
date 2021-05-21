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
                Timeout = new TimeSpan(0, 60, 0),

            });
            builder.Services.AddBlazoredLocalStorage();

            var provider = builder.Services.BuildServiceProvider();

            DomainContext.DomainClientFactory = new OpenRiaServices.Client.PortableWeb.WebApiDomainClientFactory(provider.GetService<HttpClient>(), provider.GetService<ISyncLocalStorageService>())
            {
                ServerBaseUri = new Uri(host, UriKind.Absolute)
            };
            return builder.Build().RunAsync();
        }
    }
}
