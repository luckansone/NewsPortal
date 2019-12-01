using NewsPortal.Business.Logic.Models;
using NewsPortal.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Web.Mapping
{
    public interface IMapperControl
    {
        Tag GetTagByTagModel(TagModel model);
        TagModel GetTagModelByTag(Tag model);
        List<TagModel> GetTagModelsByNews(int id);
        List<NewsModel> GetNewModelsByUser(string UserName);
        List<NewsModel> GetNewModels();
        List<NewsModel> SearchByTagName(string TagName);
        NewsModel GetNewsModelById(int id);
        List<CategoryModel> GetCategoryModels();
        CategoryModel GetCategoryModelById(int id);
        News GetNewsByNewsModel(NewsModel model);
        NewsModel GetNewsModelByNews(News model);

    }
}
