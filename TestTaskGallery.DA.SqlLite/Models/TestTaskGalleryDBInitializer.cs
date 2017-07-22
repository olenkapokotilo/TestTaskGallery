using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DA.SqlLite.Models
{
    public class TestTaskGalleryDBInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            User user = new User { Name = "Name1" };
            User user2 = new User { Name = "Name2" };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
