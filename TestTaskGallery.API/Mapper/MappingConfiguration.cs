using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TestTaskGallery.API.Mapper
{
     public  class MapperConfig
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(_ =>
            {
                _.AddProfile(new MapperProfile());
            });
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //создаем маппинг к примеру           
            CreateMap<API.Models.UserModel, Core.Entities.User>().ReverseMap(); //если нужно в обе стороны
            CreateMap<API.Models.UploadFileModel, Core.Entities.UploadFile>().ReverseMap();
        }
    }
    public class MappingConfiguration
    {
    }
}