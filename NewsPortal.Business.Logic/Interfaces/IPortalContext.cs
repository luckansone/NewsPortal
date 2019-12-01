using NewsPortal.Business.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Logic.Interfaces
{
    public interface IPortalContext
    {
         DbSet<Tag> Tags { get; set; }
         DbSet<Category> Categories { get; set; }
         DbSet<News> News { get; set; }
        void SaveChanges();
    }
}
