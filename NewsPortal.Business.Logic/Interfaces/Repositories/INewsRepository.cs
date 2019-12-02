using NewsPortal.Business.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Interfaces.Repositories
{
    public interface INewsRepository
    {
        List<News> GetAllNews();
        List<News> GetAllByUserName(string UserName);
        List<News> SearchByTag(string TagName);
        void CreateNews(News model);
        News GetNewsById(int NewsId);
        void UpdateNews(News newNews);
        void DeleteNews(int newsId);
    }
}
