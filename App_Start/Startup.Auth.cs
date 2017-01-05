using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace smoc
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            if (ConfigurationManager.AppSettings["ida:Audience"] == String.Empty
                || ConfigurationManager.AppSettings["ida:Tenant"] == String.Empty) return;

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
               new WindowsAzureActiveDirectoryBearerAuthenticationOptions
               {
                   Audience = ConfigurationManager.AppSettings["ida:Audience"],
                   Tenant = ConfigurationManager.AppSettings["ida:Tenant"]
               }
           );
        }
    }
}
