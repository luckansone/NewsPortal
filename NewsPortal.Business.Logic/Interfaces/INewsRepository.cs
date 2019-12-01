using NewsPortal.Business.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Interfaces
{
    public interface INewsRepository
    {
        List<News> GetAllNews();
        List<News> GetAllByUserName(string UserName);
        List<News> SearchByTag(string TagName);
        DateTime GetDateTimeById(int Id);
        void CreateNews(News model);
        News GetNewsById(int NewsId);
        void UpdateNews(News newNews);
        void DeleteNews(int newsId);
    }
}
