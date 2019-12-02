using AutoMapper;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Models;
using NewsPortal.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Web.Mapping
{
    public class MapperControl: IMapperControl
    {
        INewsService NewsRepository { get; set; }
        ICategoryService CategoryRepository { get; set; }

        ITagService TagRepository { get; set; }
        MapperConfiguration config { get; set; }
        IMapper mapper { get; set; }

        public MapperControl(INewsService NewsRepository,ITagService TagRepository, ICategoryService CategoryRepository )
        {
            this.NewsRepository = NewsRepository;
            this.CategoryRepository = CategoryRepository;
            this.TagRepository = TagRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsModel>();
                cfg.CreateMap<NewsModel, News>();
                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<Tag, TagModel>();
                cfg.CreateMap<TagModel, Tag>();
                cfg.AllowNullCollections = true;
            });
            mapper = config.CreateMapper();
        }

        public Tag GetTagByTagModel(TagModel model)
        {
            return mapper.Map<TagModel, Tag>(model);
        }

        public TagModel GetTagModelByTag(Tag model)
        {
            return mapper.Map<Tag, TagModel>(model);
        }

        public List<TagModel> GetTagModelsByNews(int id)
        {
            return mapper.Map<List<Tag>, List<TagModel>>(TagRepository.GetTagsById(id));
        }
        public List<NewsModel> GetNewModelsByUser(string UserName)
        {
            return mapper.Map<List<News>, List<NewsModel>>(NewsRepository.GetAllByUserName(UserName));
        }

        public List<NewsModel> GetNewModels()
        {
            return mapper.Map<List<News>, List<NewsModel>>(NewsRepository.GetAllNews());
        }

         public List<NewsModel>SearchByTagName(string TagName)
        {
            return mapper.Map<List<News>, List<NewsModel>>(NewsRepository.SearchByTag(TagName));
        }

        public NewsModel GetNewsModelById(int id)
        {
            return mapper.Map<News, NewsModel>(NewsRepository.GetNewsById(id));
        }

        public List<CategoryModel> GetCategoryModels()
        {
            return mapper.Map<List<Category>, List<CategoryModel>>(CategoryRepository.GetCategories());
        }

        public CategoryModel GetCategoryModelById(int id)
        {
            return mapper.Map<Category, CategoryModel>(CategoryRepository.GetCategoryById(id));
        }

        public News GetNewsByNewsModel(NewsModel model)
        {
            return mapper.Map<NewsModel, News>(model);
        }

        public NewsModel GetNewsModelByNews(News model)
        {
            return mapper.Map<News, NewsModel>(model);
        }
    }
}