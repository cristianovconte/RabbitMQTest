using Domain.ConsumerNavigation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Repositories.CollectNavigation
{
    public class Model
    {
        public class CollectNavigationContext : DbContext
        {
            public DbSet<Navigation> Navigations { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            }
        }
    }
}
