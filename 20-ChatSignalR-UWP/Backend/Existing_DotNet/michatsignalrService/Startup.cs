using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(michatsignalrService.Startup))]

namespace michatsignalrService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
            app.MapSignalR();
        }
    }
}