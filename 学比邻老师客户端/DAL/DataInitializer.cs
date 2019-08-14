using SQLite.CodeFirst;
using System;
using System.Data.Entity;

namespace 学比邻老师客户端.DAL
{
    internal class DataInitializer : SqliteDropCreateDatabaseWhenModelChanges<DataContext>
    {
        public DataInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public DataInitializer(DbModelBuilder modelBuilder, Type historyEntityType) : base(modelBuilder, historyEntityType)
        {
        }

        protected override void Seed(DataContext context)
        {
            base.Seed(context);


            context.SaveChanges();
        }
    }
}