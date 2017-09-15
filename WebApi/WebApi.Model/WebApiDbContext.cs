using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Model.Test;

namespace WebApi.Model
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext()
            : base("name=WebApiEntitity")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Test> Test { get; set; }

    }
}
