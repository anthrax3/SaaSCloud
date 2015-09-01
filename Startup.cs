using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaaSCloud.Startup))]
namespace SaaSCloud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
