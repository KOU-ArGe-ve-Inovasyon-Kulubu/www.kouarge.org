using Autofac;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Core.UnitOfWorks;
using KouArge.Repository;
using KouArge.Repository.Repositories;
using KouArge.Repository.UnitOfWork;
using KouArge.Service.Mapping;
using KouArge.Service.Services;
using KouArge.Service.Services.Tokens;
using System.Reflection;
using Module = Autofac.Module;

namespace KouArge.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>));

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<TokenHandler>().As<ITokenHandler>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppIdentityDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
