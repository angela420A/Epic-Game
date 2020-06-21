using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epic_Game_Backend.Startup))]
namespace Epic_Game_Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
