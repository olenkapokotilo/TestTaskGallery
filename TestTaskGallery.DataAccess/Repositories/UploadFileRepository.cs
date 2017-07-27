using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskGallery.Core;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DataAccess.Models;

namespace TestTaskGallery.DataAccess.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
    {
        private readonly DbContext _context; 
        public UploadFileRepository(DbContext context)
        {
            _context = context;
        }

        public Core.Entities.UploadFile Get(int id)
        {
            var result = _context.Set<UploadFile>().SingleOrDefault(f => f.Id == id);
            return Map.Mapper.Map<Core.Entities.UploadFile>(result);
        }

        public Core.Entities.UploadFile SaveFile(Core.Entities.UploadFile file)
        {
            var result = _context.Set<UploadFile>().Add(Map.Mapper.Map<UploadFile>(file));
            _context.SaveChanges();
            return Map.Mapper.Map<Core.Entities.UploadFile>(result);
        }

        public void DeleteFile(int id)
        {
            var file = _context.Set<UploadFile>().SingleOrDefault(f => f.Id == id);
            _context.Set<UploadFile>().Remove(file);
            _context.SaveChanges();
        }
    }
}
