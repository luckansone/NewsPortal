﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsPortal.Web.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("DevConnection") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public System.Data.Entity.DbSet<NewsPortal.Web.ViewModel.NewsModel> NewsModels { get; set; }
    }
}