using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity_Katana_Example.Startup))]
namespace Identity_Katana_Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
