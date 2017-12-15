using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBGames.Startup))]
namespace DBGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
