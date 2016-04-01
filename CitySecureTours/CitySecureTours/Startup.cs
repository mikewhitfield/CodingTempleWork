using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CityToursMVC.Startup))]
namespace CityToursMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
