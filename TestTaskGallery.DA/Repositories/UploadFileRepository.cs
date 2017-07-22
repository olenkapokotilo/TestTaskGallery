using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DA.Models;

namespace TestTaskGallery.DA.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
    {
        public object SaveFile(object file)
        {
            return "ok";
        }

        public object DeleteFile(object file)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Entities.User> Start()
        {
            //using (var context = new MyContext())
            //{
            //    var users = context.Users.ToList();
            //    var result = Mapper.Map<IEnumerable<Core.Entities.User>>(users);
            //    return result;
            //}
            
        }
    }
}
