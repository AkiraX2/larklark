using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学比邻老师客户端.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        public ObjectContext Context { get { return ((IObjectContextAdapter)this).ObjectContext; } }

        //public DbSet<Character> characters { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Character>();
            //modelBuilder.Entity<CharForm>();
            //modelBuilder.Entity<CharAttributes>();
            //modelBuilder.Entity<CombatDetails>();
            //modelBuilder.Entity<Skill>();

            var initializer = new DataInitializer(modelBuilder);


            Database.SetInitializer(initializer);
        }
    }
}
