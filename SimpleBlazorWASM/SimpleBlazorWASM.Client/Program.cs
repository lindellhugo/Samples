using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenRiaServices.Client;
using OpenRiaServices.Client.Authentication;
using SimpleBlazorWASM.Web.Services;

namespace SimpleBlazorWASM.Client
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            DomainContext.DomainClientFactory = new OpenRiaServices.Client.PortableWeb.WebApiDomainClientFactory()
            {
                
                ServerBaseUri = new Uri("https://localhost:44395/", UriKind.Absolute)
            };

            WebContext webContext = new WebContext
            {
                Authentication = new FormsAuthentication()
                {
                    DomainContext = new AuthenticationDomainService1()
                }
            };

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44395/") });

            return builder.Build().RunAsync();
        }
    }
}
