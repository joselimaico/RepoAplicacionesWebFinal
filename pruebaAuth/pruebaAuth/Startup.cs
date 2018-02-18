using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pruebaAuth.Startup))]
namespace pruebaAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
