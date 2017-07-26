using System;
using AutoMapper;

namespace TestTaskGallery.Core
{
    public static class Map
    {
        private static MapperConfiguration _config;
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() => _config.CreateMapper());

        public static IMapper Mapper
        {
            get
            {
                return _mapper.Value;
            }
        }

        public static void UseConfiguration(MapperConfiguration config)
        {
            _config = config;
        }
    }
}