using AutoMapper;
using TestTaskGallery.Core;

namespace TestTaskGallery.API
{
    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MapperProfile());
                c.AddProfile(new DataAccess.MapperProfile());
            });
            config.AssertConfigurationIsValid();
            Map.UseConfiguration(config);
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