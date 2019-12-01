using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Repository;
using NewsPortal.Business.Logic.Models;
using System.Data.Entity;
using NewsPortal.Web.Mapping;

namespace NewsPortal.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<INewsRepository, NewsRepository>();
            container.RegisterType<ITagRepository, TagRepository>();
            container.RegisterType<IPortalContext, PortalContext>();
            container.RegisterType<IMapperControl, MapperControl>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}