using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Interfaces;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        IPortalContext context { get; set; }

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
