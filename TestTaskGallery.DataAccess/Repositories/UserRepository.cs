using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DataAccess.Models;
using TestTaskGallery.DataAccess.Startup;
using User = TestTaskGallery.Core.Entities.User;

namespace TestTaskGallery.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMapper _mapper = null;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null) _mapper = MapperConfig.GetConfiguration().CreateMapper();
                return _mapper;
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new TestTaskGalleryContext())
            {
                var users = context.Users.ToList();
                var result = Mapper.Map<IEnumerable<User>>(users);
                return result;
            }
        }

        public User GetById(int id)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var user = context.Users.Where(u=>u.Id == id).SingleOrDefault();
                var result = Mapper.Map<User>(user);
                return result;
            }
        }

        public User Add(User user)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var res = context.Users.Add(Mapper.Map<Models.User>(user));
                context.SaveChanges();
                return Mapper.Map<Core.Entities.User>(res);
            }
        }
    }
}
