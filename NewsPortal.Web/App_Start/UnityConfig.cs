using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Interfaces.Repositories;
using NewsPortal.Business.Logic.Models;
using System.Data.Entity;
using NewsPortal.Web.Mapping;
using NewsPortal.Business.Logic.Services;
using NewsPortal.Business.Logic.Repositories;

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

            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<INewsService, NewsService>();
            container.RegisterType<ITagService, TagService>();
            container.RegisterType<IPortalContext, PortalContext>();
            container.RegisterType<IMapperControl, MapperControl>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<INewsRepository, NewsRepository>();
            container.RegisterType<ITagRepository, TagRepository>();
            container.RegisterType<IUnitRepository, UnitRepository>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}