using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Neemo.Web.Startup))]
namespace Neemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
