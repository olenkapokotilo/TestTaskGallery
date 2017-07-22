using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DA.SqlLite.Models;

namespace TestTaskGallery.DA.SqlLite.Repositories
{
    public class UploadFileRepository : IUploadFileRepository

    {
        public object SaveFile(UploadFile file)
        {
            return "ok";
        }

        public object DeleteFile(object file)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestTaskGallery.Core.Entities.User> Start()
        {
            using (var context = new MyContext())
            {
                var users = context.Users.ToList();
                var result = Mapper.Map<IEnumerable<Core.Entities.User>>(users);
                return result;
            }

        }
    }
}
