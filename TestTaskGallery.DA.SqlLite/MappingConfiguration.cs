using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DA = TestTaskGallery.DA.SqlLite.Models;
using Core = TestTaskGallery.Core.Entities;

namespace TestTaskGallery.DA.SqlLite
{
    public class MappingConfiguration
    {
        public static void RegisterMapping()
        {
            RegisterFromDataAccessToCore();
            RegisterFromCoreToDataAccess();
            Mapper.AssertConfigurationIsValid();
        }
        private static void RegisterFromDataAccessToCore()
        {
            Mapper.CreateMap<Models.User, Core.Entities.User>();
            Mapper.CreateMap<Models.UploadFile, Core.Entities.UploadFile>();
        }

        private static void RegisterFromCoreToDataAccess()
        {
            Mapper.CreateMap<Core.Entities.User, Models.User>();
            Mapper.CreateMap<Core.Entities.UploadFile, Models.UploadFile>();
        }
    }
}
