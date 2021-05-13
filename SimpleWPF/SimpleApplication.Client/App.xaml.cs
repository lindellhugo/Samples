using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Windows;
using OpenRiaServices.Client;
using OpenRiaServices.Client.Authentication;
using OpenRiaServices.Client.Web;
using SimpleApplication.Web;

namespace SimpleApplication.Client
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
            // Setup communication to use default "/binary" endpoint
            DomainContext.DomainClientFactory = new WebDomainClientFactory()
            {
                // Uncomment this to debug in fiddler
                // ServerBaseUri = new Uri("http://localhost.fiddler:51359/ClientBin/", UriKind.Absolute)
                //ServerBaseUri = new Uri("https://localhost:44373/", UriKind.Absolute)
                ServerBaseUri = new Uri("http://localhost:51359/", UriKind.Absolute)
            };

            // Setup communication to use portable "/soap" endpoint
            /*
            DomainContext.DomainClientFactory = new SoapDomainClientFactory()
            {
                // Uncomment this to debug in fiddler
                // ServerBaseUri = new Uri("http://localhost.fiddler:51359/ClientBin/", UriKind.Absolute)
                ServerBaseUri = new Uri("https://localhost:44373/", UriKind.Absolute)
            };
            */

            // Create a WebContext
            // This will then be available as WebContext.Current.
            WebContext webContext = new WebContext
            {
                Authentication = new FormsAuthentication()
                {
                    DomainContext = new AuthenticationDomainService1()
                }
            };
            this.Resources["WebContext"] = webContext;

            var main = new MainWindow();
            main.Show();
        }
    }
}
