using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibreriaFJDR.Startup))]
namespace LibreriaFJDR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
