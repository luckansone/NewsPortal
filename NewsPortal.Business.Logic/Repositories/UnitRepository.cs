using NewsPortal.Business.Logic.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Repositories
{
    public class UnitRepository:IUnitRepository
    {
        public ICategoryRepository categoryRepository { get; set; }
        public INewsRepository newsRepository { get; set; }
        public ITagRepository tagRepository { get; set; }

        public UnitRepository(ICategoryRepository categoryRepository, INewsRepository newsRepository, ITagRepository tagRepository)
        {
            this.categoryRepository = categoryRepository;
            this.newsRepository = newsRepository;
            this.tagRepository = tagRepository;
        }
    }
}
