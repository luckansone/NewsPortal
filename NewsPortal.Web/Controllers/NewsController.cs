using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Models;
using NewsPortal.Business.Logic.Repository;
using NewsPortal.Web.Mapping;
using NewsPortal.Web.ViewModel;

namespace NewsPortal.Web.Controllers
{
    public class NewsController : Controller
    {
        INewsRepository NewsRepository { get; set; }
        ITagRepository TagRepository { get; set; }
    
        IMapperControl Mapper { get; set; }

        private static int NewsId { get; set; }

        public NewsController(ITagRepository TagRepository, INewsRepository NewsRepository,  IMapperControl mapperControl)
        {
            this.TagRepository = TagRepository;
            this.NewsRepository = NewsRepository;
            Mapper = mapperControl;
         
        }
        // GET: News
        public ActionResult GetNewsByUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                string UserName = User.Identity.Name;
                var models = Mapper.GetNewModelsByUser(UserName);
                ViewBag.Author = UserName;
                return View(models);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult GetTagsByNews(int id)
        {
            var newsModel = Mapper.GetNewsModelByNews(NewsRepository.GetNewsById(id));
            ViewBag.News = newsModel.Title;
            var tagsModel = Mapper.GetTagModelsByNews(id);
            NewsId = id;
            return View(tagsModel);
        }

        public ActionResult Details(int id)
        {
            var model = Mapper.GetNewsModelById(id);
            model.UserName = User.Identity.Name;
            return View(model);
        }

        public ActionResult CreateTag()
        {
            TagModel tag = new TagModel();
            tag.NewsId = NewsId;
            return View(tag);
        }
        
        [HttpPost]
        public ActionResult CreateTag(TagModel model)
        {
            if (!TryUpdateModel(model))
            {
                return View(model);
            }

            model.NewsId = NewsId;
            var newTag = Mapper.GetTagByTagModel(model);
            TagRepository.CreateTag(newTag);
            return View("GetTagsByNews", Mapper.GetTagModelsByNews(model.NewsId));
        }

        public ActionResult Create()
        {
            NewsModel model = new NewsModel();
            var categories = Mapper.GetCategoryModels();
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
            var categories = Mapper.GetCategoryModels();
            model.Categories = new SelectList(categories, "Id", "Name",1);
            model.Category = Mapper.GetCategoryModelById(model.Category.Id);
            var newModel = Mapper.GetNewsByNewsModel(model);
            NewsRepository.CreateNews(newModel);
            return View("Details", model);
        }

        public ActionResult Edit(int id)
        { 
            var model = Mapper.GetNewsModelById(id);
            model.UserName = User.Identity.Name;
            var categories = Mapper.GetCategoryModels();
            model.Categories = new SelectList(categories, "Id", "Name", 1);
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
  
            var categories = Mapper.GetCategoryModels();
            model.Categories = new SelectList(categories, "Id", "Name", 1);
            model.Category = Mapper.GetCategoryModelById(model.Category.Id);
            var newModel = Mapper.GetNewsByNewsModel(model);
            NewsRepository.UpdateNews(newModel);
            return View("Details", model);
        }

        [HttpDelete]
        [ActionName("Delete")]
        public void Delete(int id)
        {    
            NewsRepository.DeleteNews(id);
        }

        [HttpDelete]
        [ActionName("DeleteTag")]
        public void DeleteTag(int id)
        {
            TagRepository.DeleteTag(id);
        }
    }
}