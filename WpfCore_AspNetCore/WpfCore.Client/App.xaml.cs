using OpenRiaServices.Client;
using OpenRiaServices.Client.Authentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WpfCore.Client;

namespace WpfCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            DomainContext.DomainClientFactory = new OpenRiaServices.Client.DomainClients.BinaryHttpDomainClientFactory(new Uri("https://localhost:7046/", UriKind.Absolute), new System.Net.Http.HttpClientHandler());

            // Create a WebContext and add it to the ApplicationLifetimeObjects collection.
            // This will then be available as WebContext.Current.
            WebContext webContext = new WebContext();
            webContext.Authentication = new FormsAuthentication()
            {
                 DomainContext = new SimpleApplication.Web.AspNetIdentityAuthenticationDomainContext()
            };
        }
    }
}
