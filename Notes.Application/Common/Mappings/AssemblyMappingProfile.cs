using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Notes.Domain;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile, IMapWith<Note>
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        //пришлось унаследовать интерфейс и реализовать метод, тк какая-та ошибка
        void IMapWith<Note>.Mapping(Profile profile)
        {
            profile.CreateMap(typeof(Note), GetType());
        }
        
    }
}
