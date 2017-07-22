using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DataAccess.Models
{
    public class TestTaskGalleryDBInitializer : DropCreateDatabaseAlways<TestTaskGalleryContext>
    {
        protected override void Seed(TestTaskGalleryContext context)
        {
            User user = new User { Name = "Name1" , BirthDate = DateTime.Now};
            User user2 = new User { Name = "Name2", BirthDate = new DateTime(2015, 12, 5) };
            User user4 = new User { Name = "Name2", BirthDate = new DateTime(2012, 12, 5) };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user4);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
