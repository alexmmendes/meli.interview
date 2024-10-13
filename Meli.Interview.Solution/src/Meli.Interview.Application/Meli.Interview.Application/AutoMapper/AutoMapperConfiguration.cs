using AutoMapper;

namespace Meli.Interview.Application.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile<MappingProfile>();
            });
        }
    }
}
