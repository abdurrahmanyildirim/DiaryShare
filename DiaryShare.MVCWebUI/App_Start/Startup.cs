using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DiaryShare.MVCWebUI.App_Start.Startup))]
namespace DiaryShare.MVCWebUI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}