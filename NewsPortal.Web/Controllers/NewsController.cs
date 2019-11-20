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
        NewsRepository NewsRepository { get; set; }
        CategoryRepository CategoryRepository { get; set; }

        public NewsController()
        {
            NewsRepository = new NewsRepository();
            CategoryRepository = new CategoryRepository();
            
        }
        // GET: News
        public ActionResult GetNewsByUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<News, NewsModel>(); cfg.AllowNullCollections=true; });
                IMapper mapper = config.CreateMapper();
                string UserName = User.Identity.Name;
                var models = mapper.Map<List<News>, List<NewsModel>>(NewsRepository.GetAllByUserName(UserName));
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
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<News, NewsModel>();});
            IMapper mapper = config.CreateMapper();
            var model = mapper.Map<News, NewsModel>(NewsRepository.GetNewsById(id));
            model.UserName = User.Identity.Name;
            return View(model);
        }

        public ActionResult Create()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryModel>();
            });
            IMapper mapper = config.CreateMapper();
            NewsModel model = new NewsModel();
            List<CategoryModel> categories = mapper.Map<List<Category>, List<CategoryModel>>(CategoryRepository.GetCategories());
            model.Categories = new SelectList(categories, "Id", "Name", 1);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NewsModel model)
        {
            if (!TryUpdateModel(model))
            {
                return View(model);
            }
            model.UserName = User.Identity.Name;
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewsModel, News>();
                                                          cfg.CreateMap<CategoryModel, Category>();
                                                          cfg.CreateMap<Category, CategoryModel>();
                                                         });
            IMapper mapper = config.CreateMapper();
            List<CategoryModel> categories = mapper.Map<List<Category>, List<CategoryModel>>(CategoryRepository.GetCategories());
            model.Categories = new SelectList(categories, "Id", "Name",1);
            var newModel = mapper.Map<NewsModel, News>(model);
            NewsRepository.CreateNews(newModel);
            return View("Details", model);
        }

        public ActionResult Edit(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            IMapper mapper = config.CreateMapper();
            var model = mapper.Map<News, NewsModel>(NewsRepository.GetNewsById(id));
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
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewsModel, News>();
                                                          cfg.CreateMap<Category, CategoryModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<CategoryModel> categories = mapper.Map<List<Category>, List<CategoryModel>>(CategoryRepository.GetCategories());
            model.Categories = new SelectList(categories, "Id", "Name", 1);
            var newModel = mapper.Map<NewsModel, News>(model);
            NewsRepository.UpdateNews(newModel);
            return View("Details", model);
        }
        public ActionResult Delete(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            IMapper mapper = config.CreateMapper();
            var model = mapper.Map<News, NewsModel>(NewsRepository.GetNewsById(id));
            model.UserName = User.Identity.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            NewsRepository.DeleteNews(id);
            return RedirectToAction("GetNewsByUser");
        }
    }
}