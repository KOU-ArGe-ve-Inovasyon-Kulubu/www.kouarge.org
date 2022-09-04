using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace www.kouarge.org.Modules
{
    public class HttpModule : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            var webAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(webAssembly).Where(x => x.Name.EndsWith("ApiService"));
        }
    }
}
