using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultiTenantWebApp.Startup))]
namespace MultiTenantWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
