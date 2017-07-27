using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskGallery.Core;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DataAccess.Models;
using CoreEntities = TestTaskGallery.Core.Entities;

namespace TestTaskGallery.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<CoreEntities.User> GetAll()
        {
            var users = _context.Set<User>().ToList();
            var result = Map.Mapper.Map<IEnumerable<CoreEntities.User>>(users);
            return result;
        }

        public CoreEntities.User GetById(int id)
        {
            var user = _context.Set<User>().SingleOrDefault(u => u.Id == id);
            var result = Map.Mapper.Map<CoreEntities.User>(user);
            return result;
        }

        public CoreEntities.User Add(CoreEntities.User user)
        {
            var res = _context.Set<User>().Add(Map.Mapper.Map<User>(user));
            _context.SaveChanges();
            return Map.Mapper.Map<CoreEntities.User>(res);
        }
    }
}
