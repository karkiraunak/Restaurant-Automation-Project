using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantAutomationProject.Startup))]
namespace RestaurantAutomationProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
