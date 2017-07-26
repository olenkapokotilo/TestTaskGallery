using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskGallery.Core;

namespace TestTaskGallery.DataAccess
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Models.User, Core.Entities.User>().ReverseMap();
            CreateMap<Models.UploadFile, Core.Entities.UploadFile>().ReverseMap();
        }
    }
}
