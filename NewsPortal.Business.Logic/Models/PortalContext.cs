using NewsPortal.Business.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NewsPortal.Business.Logic.Models
{
    public class PortalContext : DbContext, IPortalContext
    {
        public PortalContext() : base("DevConnection")
        {
          
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<News> News { get; set; }

        void IPortalContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
