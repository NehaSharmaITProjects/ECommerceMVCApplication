using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineJwellery.Startup))]
namespace OnlineJwellery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
