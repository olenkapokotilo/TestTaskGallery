using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DataAccess.Models;
using TestTaskGallery.DataAccess.Startup;
using CoreEntities = TestTaskGallery.Core.Entities;

namespace TestTaskGallery.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<CoreEntities.User> GetAllUsers()
        {
            using (var context = new TestTaskGalleryContext())
            {
                var users = context.Users.ToList();
                var result = Mapper.Map<IEnumerable<CoreEntities.User>>(users);
                return result;
            }
        }

        public CoreEntities.User GetById(int id)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Id == id);
                var result = Mapper.Map<CoreEntities.User>(user);
                return result;
            }
        }

        public CoreEntities.User Add(CoreEntities.User user)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var res = context.Users.Add(Mapper.Map<User>(user));
                context.SaveChanges();
                return Mapper.Map<CoreEntities.User>(res);
            }
        }
    }
}
