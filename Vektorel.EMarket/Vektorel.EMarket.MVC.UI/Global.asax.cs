using Ninject.Modules;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vektorel.EMarket.Datacore.Infrastructure;

namespace Vektorel.EMarket.MVC.UI
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override Ninject.IKernel CreateKernel()
        {
            throw new NotImplementedException();
        }
    }

    public class InstanceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
        }
    }
}
