using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC = TestTaskGallery.MVC.Models;
//using Core = TestTaskGallery.Core.Entities;

namespace TestTaskGallery.MVC
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
            //CreateMap<MVC.Models.UserModel, Core.Entities.User>().ReverseMap(); //если нужно в обе стороны
            //CreateMap<MVC.Models.UploadFileModel, Core.Entities.UploadFile>().ReverseMap();
        }
    }
    public class MappingConfiguration
    {
        //public static void RegisterMapping()
        //{
        //    RegisterFromMVCModelsToCore();
        //    RegisterFromCoreToMvcModels();
        //    Mapper.AssertConfigurationIsValid();
        //}

        //private static void RegisterFromMVCModelsToCore()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<MVC.Models.UserModel, Core.Entities.User>();
        //        cfg.CreateMap<MVC.Models.UploadFileModel, Core.Entities.UploadFile>();
        //        });
        //}

        //private static void RegisterFromCoreToMvcModels()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Core.Entities.User, MVC.Models.UserModel>();
        //        cfg.CreateMap<Core.Entities.UploadFile, MVC.Models.UploadFileModel>();
        //    });
        //}
    }
}