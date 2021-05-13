using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenRiaServices.Client;
using OpenRiaServices.Client.Authentication;
using SimpleApplication.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplication.Client.WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            DomainContext.DomainClientFactory = new OpenRiaServices.Client.PortableWeb.WebApiDomainClientFactory()
            {
                ServerBaseUri = new Uri("http://localhost:51359/ClientBin/", UriKind.Absolute)
            };

            WebContext webContext = new WebContext
            {
                Authentication = new FormsAuthentication()
                {
                    DomainContext = new AuthenticationDomainService1()
                }
            };

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:51359/ClientBin/") });

            await builder.Build().RunAsync();
        }
    }
}
