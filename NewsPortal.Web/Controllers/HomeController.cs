using NewsPortal.Business.Logic.Repository;
using NewsPortal.Web.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsPortal.Web.ViewModel;
using NewsPortal.Business.Logic.Models;
using NewsPortal.Business.Logic.Interfaces;

namespace NewsPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        IMapperControl Mapper { get; set; }
        INewsRepository NewsRepository { get; set; }

        public HomeController(INewsRepository NewsRepository, IMapperControl mapperControl)
        {
            this.NewsRepository = NewsRepository;
          
            Mapper = mapperControl;
        }
        public ActionResult Index()
        {
            var news = Mapper.GetNewModels();
            return View(news);
        }

        public ActionResult Details(int id)
        {
            var model = Mapper.GetNewsModelById(id);
            model.UserName = User.Identity.Name;
            return View(model);
        }

        public ActionResult NewsSearch(string TagName)
        {
            var News = Mapper.SearchByTagName(TagName);
            if(News.Count<=0)
            { 
                return HttpNotFound();
            }

            return PartialView(News);

        }
    }
}