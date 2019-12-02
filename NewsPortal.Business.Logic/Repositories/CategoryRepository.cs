using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Interfaces.Repositories;
using NewsPortal.Business.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        IPortalContext context;
        public CategoryRepository(IPortalContext portalContext)
        {
            context = portalContext;
        }

        public List<Category> GetCategories()
        {
            return this.context.Categories.ToList();
        }

        public Category GetCategoryById(int Id)
        {
            return this.context.Categories.ToList().Find(x => x.Id == Id);
        }
    }
}
