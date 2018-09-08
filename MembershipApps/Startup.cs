using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MembershipApps.Startup))]
namespace MembershipApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
