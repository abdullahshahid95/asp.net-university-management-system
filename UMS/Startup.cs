using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMS.Startup))]
namespace UMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
