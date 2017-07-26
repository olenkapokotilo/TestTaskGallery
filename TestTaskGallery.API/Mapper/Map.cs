using AutoMapper;

namespace TestTaskGallery.API.Mapper
{
     public static class Map
    {
        private static IMapper _mapper = null;
        public static IMapper Mapper
        {
            get { return _mapper ?? (_mapper = MapperConfig.GetConfiguration().CreateMapper()); }
        }
    }
}