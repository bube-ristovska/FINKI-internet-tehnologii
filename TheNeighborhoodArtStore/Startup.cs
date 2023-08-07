using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheNeighborhoodArtStore.Startup))]
namespace TheNeighborhoodArtStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
