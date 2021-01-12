using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaCONNY.Startup))]
namespace SistemaCONNY
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
