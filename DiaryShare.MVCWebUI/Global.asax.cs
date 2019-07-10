using DiaryShare.BLL.DependencyResolvers.Ninject;
using DiaryShare.Core.Utilities.Mvc.Infrasturucture.Ninject;
using DiaryShare.MVCWebUI.App_Start;
using DiaryShare.MVCWebUI.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DiaryShare.MVCWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
            AutoMapperConfiguration.Configure();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
