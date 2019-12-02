using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Interfaces.Repositories;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Services
{
    public class NewsService: INewsService
    {
        IUnitRepository unitRepository;

        public NewsService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        } 

        public List<News> GetAllNews()
        {
            return this.unitRepository.newsRepository.GetAllNews();
        }
        public List<News> GetAllByUserName(string UserName)
        {
            return this.unitRepository.newsRepository.GetAllByUserName(UserName);
        }

        public List<News>SearchByTag(string TagName)
        {
            return this.unitRepository.newsRepository.SearchByTag(TagName);
        }


        public void CreateNews(News model)
        {
            this.unitRepository.newsRepository.CreateNews(model);
        }

        public News GetNewsById(int NewsId)
        {
            return this.unitRepository.newsRepository.GetNewsById(NewsId);
        }

        public void UpdateNews(News newNews)
        {
            this.unitRepository.newsRepository.UpdateNews(newNews);
        }

        public void DeleteNews(int newsId)
        {
            this.unitRepository.newsRepository.DeleteNews(newsId);       
        }
    }
}
