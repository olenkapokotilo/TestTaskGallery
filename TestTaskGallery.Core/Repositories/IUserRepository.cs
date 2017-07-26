using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskGallery.Core.Entities;

namespace TestTaskGallery.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        User GetById(int id);

        User Add(User user);
    }
}
