using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RideshareAdmin.Console.Startup))]
namespace RideshareAdmin.Console
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
