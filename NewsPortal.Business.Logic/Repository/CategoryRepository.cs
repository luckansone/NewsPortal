using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Business.Logic.Models;

namespace NewsPortal.Business.Logic.Repository
{
    public class CategoryRepository
    {
        public static CategoryRepository instance = new CategoryRepository();
        PortalContext context { get; set; }

        public CategoryRepository()
        {
            context = new PortalContext();
        }

        public List<Category> GetCategories()
        {
            return this.context.Categories.ToList();
        }

        //public Category GetCategoryByNewsId(int id)
        //{
        //    return this.context.Categories.ToList().Find(x=>x.)
        //}
    }
}
