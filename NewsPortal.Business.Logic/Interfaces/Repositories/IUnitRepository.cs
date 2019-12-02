using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Interfaces.Repositories
{
    public interface IUnitRepository
    {
        ICategoryRepository categoryRepository { get; set; }
        INewsRepository newsRepository { get; set; }
        ITagRepository tagRepository { get; set; }
    }
}
