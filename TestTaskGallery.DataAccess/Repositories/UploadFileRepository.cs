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

        public Core.Entities.UploadFile GetNameById(int id)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var result = context.UploadFiles.Where(f => f.Id ==id).SingleOrDefault();
                return Mapper.Map<Core.Entities.UploadFile>(result);
            }
        }

        public object SaveFile(object file)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var result = context.UploadFiles.Add(Mapper.Map<DataAccess.Models.UploadFile>(file));
                context.SaveChanges();
                return Mapper.Map<TestTaskGallery.Core.Entities.UploadFile>(result);
            }
            
        }

        public object DeleteFile(object fileName)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var el = context.UploadFiles.SingleOrDefault(f => f.Name == (string)fileName);
                context.Entry(el).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return "ok"; //TODO: return 
        }
      }
}
