using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NewsPortal.Business.Logic.Models
{
    class PortalContext : DbContext
    {
        public PortalContext() : base("DevConnection")
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}
