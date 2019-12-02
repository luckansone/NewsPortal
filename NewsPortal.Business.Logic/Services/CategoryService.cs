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
    public class CategoryService: ICategoryService
    {
        IUnitRepository unitRepository;

        public CategoryService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public List<Category> GetCategories()
        {
            return this.unitRepository.categoryRepository.GetCategories();
        }

        public Category GetCategoryById(int Id)
        {
            return this.unitRepository.categoryRepository.GetCategoryById(Id);
        }

    }
}
