using NewsPortal.Business.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int Id);
    }
}
