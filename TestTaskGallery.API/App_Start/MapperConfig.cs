using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TestTaskGallery.API
{
    public class MapperConfig
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(_ => _.AddProfile(new MapperProfile()));
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Models.UserModel, Core.Entities.User>().ReverseMap();
            CreateMap<Models.UploadFileModel, Core.Entities.UploadFile>().ReverseMap();
        }
    }
}