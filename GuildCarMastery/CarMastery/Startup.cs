using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMastery.Startup))]
namespace CarMastery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
