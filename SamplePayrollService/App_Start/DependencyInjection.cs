using Autofac;
using Autofac.Integration.WebApi;
using PayrollService;
using PayrollService.Contracts;
using PayrollService.Persistence;
using System.Reflection;
using System.Web.Http;

namespace SamplePayrollService.App_Start
{
    public static class DependencyInjection
    {
        public static void UseAutofac()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<InMemoryPayrollDetailsRepository>().As<IPayrollDetailsRepository>();
            builder.RegisterType<CalculatorFactory>().As<ICalculatorFactory>();

            var container = builder.Build();

            var regs = container.ComponentRegistry.Registrations;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            
        }
    }
}