using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using DA = TestTaskGallery.DataAccess.Models;
using Core = TestTaskGallery.Core.Entities;

namespace TestTaskGallery.DataAccess.Startup
{
    public static class MapperConfig
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
            CreateMap<DA.User, Core.Entities.User>().ReverseMap(); //если нужно в обе стороны
            CreateMap<DA.UploadFile, Core.Entities.UploadFile>().ReverseMap();
        }
    }
    //public class MappingConfiguration
    //{
    //    public static void RegisterMapping()
    //    {
    //        //var config = new MapperConfiguration();
    //        RegisterFromDataAccessToCore();
    //        RegisterFromCoreToDataAccess();
    //        Mapper.AssertConfigurationIsValid();
    //    }
    //    private static void RegisterFromDataAccessToCore()
    //    {
    //        Mapper.Initialize(cfg =>
    //        {
    //            cfg.CreateMap<DA.User, Core.Entities.User>();
    //            cfg.CreateMap<DA.UploadFile, Core.Entities.UploadFile>();
    //        });
    //    }

    //    private static void RegisterFromCoreToDataAccess()
    //    {
    //        Mapper.Initialize(cfg =>
    //        {
    //            cfg.CreateMap<Core.Entities.User, Models.User>();
    //            cfg.CreateMap<Core.Entities.UploadFile, Models.UploadFile>();
    //        });
    //    }
    //}
}
