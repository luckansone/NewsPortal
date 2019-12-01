using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Repository
{
    public class NewsRepository: INewsRepository
    {
        IPortalContext context { get; set; }

        public NewsRepository(IPortalContext portalContext)
        {
            context = portalContext;
        }

        public List<News> GetAllNews()
        {
            return this.context.News.ToList();
        }
        public List<News> GetAllByUserName(string UserName)
        {
            return this.context.News.Where(x => x.UserName == UserName).ToList();
        }

        public List<News>SearchByTag(string TagName)
        {
            List<News> News = new List<News>();
            var models = context.News.ToList();
            
            foreach(var model in models)
            {
                foreach(var tag in model.Tags)
                {
                    if(tag.Name.ToLower().Contains(TagName.ToLower()))
                    {
                        News.Add(model);
                    }
                }
            }
            return News;
        }

        public DateTime GetDateTimeById(int Id)
        {
            return this.context.News.Where(x=>x.Id ==Id).Select(x=>x.PublishTime).First();
        }

        public void CreateNews(News model)
        {
            model.PublishTime = DateTime.Now;
            this.context.News.Add(model);
            this.context.SaveChanges();
        }

        public News GetNewsById(int NewsId)
        {
            return this.context.News.ToList().Find(x => x.Id == NewsId);
        }

        public void UpdateNews(News newNews)
        {
            var oldNews = GetNewsById(newNews.Id);

            if(oldNews ==null)
            {
                return;
            }
         
            newNews.PublishTime = DateTime.Now;
            this.context.News.Remove(oldNews);
            this.context.SaveChanges();
            this.context.News.Add(newNews);
            this.context.SaveChanges();
        }

        public void DeleteNews(int newsId)
        {
            var model = GetNewsById(newsId);

            if(model == null)
            {
                return;
            }

            this.context.News.Remove(model);
            this.context.SaveChanges();
                
        }
    }
}
