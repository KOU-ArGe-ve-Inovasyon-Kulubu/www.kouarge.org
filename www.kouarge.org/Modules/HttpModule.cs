using Autofac;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Core.UnitOfWorks;
using KouArge.Repository.UnitOfWork;
using KouArge.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace www.kouarge.org.Modules
{
    public class HttpModule : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            //***
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<RedirectService>().As<IRedirectService>();
            //***

            var webAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(webAssembly).Where(x => x.Name.EndsWith("ApiService"));
        }
    }
}
