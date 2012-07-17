using AutoMapper;

namespace Web.Core
{
    public static class MappingExtensions
    {
        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}