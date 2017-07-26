using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DataAccess.Models
{
    public class TestTaskGalleryContext : DbContext
    {
        static TestTaskGalleryContext()
        {
            Database.SetInitializer<TestTaskGalleryContext>(new TestTaskGalleryDBInitializer());
        }
        public TestTaskGalleryContext() : base("name=TestTaskGalleryContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
    }
}
