using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WillMvc.Startup))]
namespace WillMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
