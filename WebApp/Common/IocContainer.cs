using System;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WebApp.Common
{
    public class IocContainer
    {
        private static IWindsorContainer _container;
        public static void SetupIoc()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container.Kernel));
        }
    }
}