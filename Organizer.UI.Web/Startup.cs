using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Organizer.UI.Web.Startup))]
namespace Organizer.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
