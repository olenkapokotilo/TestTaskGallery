using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core.Repositories;
using TestTaskGallery.DataAccess.Models;

namespace TestTaskGallery.DataAccess.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
    {
        public Core.Entities.UploadFile GetNameById(int id)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var result = context.UploadFiles.SingleOrDefault(f => f.Id ==id);
                return Mapper.Map<Core.Entities.UploadFile>(result);
            }
        }

        public object SaveFile(object file)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var result = context.UploadFiles.Add(Mapper.Map<UploadFile>(file));
                context.SaveChanges();
                return Mapper.Map<Core.Entities.UploadFile>(result);
            }
            
        }

        public object DeleteFile(object fileName)
        {
            using (var context = new TestTaskGalleryContext())
            {
                var el = context.UploadFiles.SingleOrDefault(f => f.Name == fileName.ToString());
                context.Entry(el).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return "ok"; //TODO: ???return 
        }
      }
}
