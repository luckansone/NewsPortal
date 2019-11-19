using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Repository
{
    public class NewsRepository
    {
        public static NewsRepository instance = new NewsRepository();
        PortalContext context { get; set; }

        public NewsRepository()
        {
            context = new PortalContext();
        }

        public List<News> GetAllByUserName(string UserName)
        {
            return this.context.News.Where(x => x.UserName == UserName).ToList();
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
