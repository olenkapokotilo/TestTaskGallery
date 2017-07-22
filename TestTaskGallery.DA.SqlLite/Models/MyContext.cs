using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;

namespace TestTaskGallery.DA.SqlLite.Models
{
    public class MyContext : DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyContext>(modelBuilder);
        //    Database.SetInitializer(sqliteConnectionInitializer);
        //}

        static MyContext()
        {
            Database.SetInitializer<MyContext>(new TestTaskGalleryDBInitializer());
        }
        public MyContext() : base("name=MyContext")
        {
            //Database.SetInitializer<>(new TestTaskGalleryDBInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
    }
}
