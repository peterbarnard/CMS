using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Competenct_Management.Startup))]
namespace Competenct_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
