using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheForum.Startup))]
namespace TheForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
