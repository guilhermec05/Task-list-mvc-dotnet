using AutoMapper;
using task.Mappers;

namespace task.Configuration
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfiler>();
                cfg.AddProfile<TaskProfiller>();
            });
        }
    }
}