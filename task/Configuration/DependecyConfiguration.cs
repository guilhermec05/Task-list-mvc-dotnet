using System.Web.Mvc;
using task.Infrastruct.Data.Context;
using task.Repositories;
using task.Repositories.Impl;
using task.Services;
using task.Services.Impl;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;


namespace task.Configuration
{
    public class DependecyConfiguration
    {
        public static void Register()
        {

            var mapperConfig =
           AutoMapperConfig.Register();

            var mapper =
                mapperConfig.CreateMapper();

            var container = new UnityContainer();

            container.RegisterInstance(mapper);
            container.RegisterType<IUnityOfWork, UnitOfWork>();



            // REPOSITORY
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();


            // SERVICE
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IUserServices, UserServices>();
            container.RegisterType<ITaskService, TaskService>();

            container.RegisterType<AppDbContext>(
    new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}