using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Example.EntyFramework.Startup))]
namespace Example.EntyFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
