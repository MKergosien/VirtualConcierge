using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualConcierge.Startup))]
namespace VirtualConcierge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
