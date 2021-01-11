using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TK_Project.Startup))]
namespace TK_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
