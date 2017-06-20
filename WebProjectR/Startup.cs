using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProjectR.Startup))]
namespace WebProjectR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
