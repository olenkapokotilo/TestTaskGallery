using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DataAccess.Models
{
    public class TestTaskGalleryDbInitializer : DropCreateDatabaseAlways<TestTaskGalleryContext>
    {
        protected override void Seed(TestTaskGalleryContext context)
        {
            var user = new User { Name = "Name1" , BirthDate = DateTime.Now};
            var user2 = new User { Name = "Name2", BirthDate = new DateTime(2015, 12, 5) };
            var user4 = new User { Name = "Name2", BirthDate = new DateTime(2012, 12, 5) };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user4);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
