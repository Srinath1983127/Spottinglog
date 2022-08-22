using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spottinglog.Startup))]
namespace Spottinglog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
