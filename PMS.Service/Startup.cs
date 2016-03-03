using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Microsoft.Owin.Cors;
using System.Data.Entity;
using PMS.Common;
using Nelibur.ObjectMapper;

[assembly: OwinStartup(typeof(PMS.Service.Startup))]

namespace PMS.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PMSContext, PMS.Common.Migrations.Configuration>());

            UnityConfig.RegisterComponents(config);

            TinyMapper.Bind<PMS.Common.BookDemands, PMS.Service.PMSDemand>();
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            //Token Consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
            });
        }
    }
}
