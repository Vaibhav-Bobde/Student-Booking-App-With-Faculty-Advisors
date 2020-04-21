using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Web.Mvc;
using ServiceLayer.Interface;
using ServiceLayer.Services;
using AutoMapper;
namespace WebApp.Common
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore configStore)
        {
            //Injecting AutoMapper Dependency-----------------------------------------------

            // Register all mapper profiles
            container.Register(
                Classes.FromAssemblyInThisApplication(GetType().Assembly)
                .BasedOn<Profile>().WithServiceBase());

            // Register IConfigurationProvider with all registered profiles
            container.Register(Component.For<IConfigurationProvider>().UsingFactoryMethod(kernel =>
            {
                return new MapperConfiguration(configuration =>
                {
                    kernel.ResolveAll<Profile>().ToList().ForEach(configuration.AddProfile);
                });
            }).LifestyleSingleton());

            // Register IMapper with registered IConfigurationProvider
            container.Register(
                Component.For<IMapper>().UsingFactoryMethod(kernel =>
                    new Mapper(kernel.Resolve<IConfigurationProvider>(), kernel.Resolve)));

            //Injecting Service Dependency---------------------------------------------------

            //Registering all the controllers of this Assembly
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>());
            container.Register(Component.For<IFacultyService>().ImplementedBy<FacultyService>());
        }
    }
}