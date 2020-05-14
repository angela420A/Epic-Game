using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epic_Game.Startup))]
namespace Epic_Game
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
