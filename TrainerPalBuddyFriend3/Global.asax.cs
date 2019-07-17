using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TrainerPalBuddyFriend3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static public ISessionFactory SF = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Call log4net
            log4net.Config.XmlConfigurator.Configure();

            SF = SessionFactory.GetSF();
        }

        public override void Init()
        {
            base.Init();

            this.BeginRequest += MvcApplication_BeginRequest;

            this.EndRequest += MvcApplication_EndRequest;
        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            ISession S = CurrentSessionContext.Unbind(SF);
            S.Dispose();
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Bind(SF.OpenSession());
        }
    }
}
