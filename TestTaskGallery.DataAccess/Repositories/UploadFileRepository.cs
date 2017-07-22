using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DataAccess.Models;
using TestTaskGallery.DataAccess.Startup;

namespace TestTaskGallery.DataAccess.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
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
        public object SaveFile(TestTaskGallery.Core.Entities.UploadFile file)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var result = context.UploadFiles.Add(Mapper.Map<DataAccess.Models.UploadFile>(file));
                context.SaveChanges();
                return Mapper.Map<TestTaskGallery.Core.Entities.UploadFile>(result);
            }
            
        }

        public object DeleteFile(object file)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var el = context.UploadFiles.Where(f => f.Id == (int)file).SingleOrDefault();
                context.Entry(el).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return "ok"; //TODO: return 
        }
       public IEnumerable<TestTaskGallery.Core.Entities.User> Start()
        {
            using (var context = new TestTaskGalleryContext())
            {
                var users = context.Users.ToList();
                var files = context.UploadFiles.ToList();
                var result = Mapper.Map<IEnumerable<Core.Entities.User>>(users);
                return result;
            }

        }
    }
}
