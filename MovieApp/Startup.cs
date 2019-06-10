using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieApp.Startup))]
namespace MovieApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
