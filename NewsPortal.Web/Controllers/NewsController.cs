using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NewsPortal.Business.Logic.Models;
using NewsPortal.Business.Logic.Repository;
using NewsPortal.Web.ViewModel;

namespace NewsPortal.Web.Controllers
{
    public class NewsController : Controller
    {
        NewsRepository repository { get; set; }

        public NewsController()
        {
            repository = new NewsRepository();
        }
        // GET: News
        public ActionResult GetNewsByUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<News, NewsModel>(); cfg.AllowNullCollections=true; });
                IMapper mapper = config.CreateMapper();
                string UserName = User.Identity.Name;
                var models = mapper.Map<List<News>, List<NewsModel>>(repository.GetAllByUserName(UserName));
                ViewBag.Author = UserName;
                return View(models);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Details(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            IMapper mapper = config.CreateMapper();
            var model = mapper.Map<News, NewsModel>(repository.GetNewsById(id));
            model.UserName = User.Identity.Name;
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new NewsModel());
        }

        [HttpPost]
        public ActionResult Create(NewsModel model)
        {
            if (!TryUpdateModel(model))
            {
                return View(model);
            }

            model.UserName = User.Identity.Name;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            IMapper mapper = config.CreateMapper();
            var newModel = mapper.Map<NewsModel, News>(model);
            repository.CreateNews(newModel);
            return View("Details", model);
        }

        public ActionResult Edit(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            IMapper mapper = config.CreateMapper();
            var model = mapper.Map<News, NewsModel>(repository.GetNewsById(id));
            model.UserName = User.Identity.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NewsModel model)
        {
            if (!TryUpdateModel(model))
            {
                return View(model);
            }

            model.UserName = User.Identity.Name;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, News>());
            IMapper mapper = config.CreateMapper();
            var newModel = mapper.Map<NewsModel, News>(model);
            repository.UpdateNews(newModel);
            return View("Details", model);
        }
        public ActionResult Delete(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            IMapper mapper = config.CreateMapper();
            var model = mapper.Map<News, NewsModel>(repository.GetNewsById(id));
            model.UserName = User.Identity.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            repository.DeleteNews(id);
            return RedirectToAction("GetNewsByUser");
        }
    }
}