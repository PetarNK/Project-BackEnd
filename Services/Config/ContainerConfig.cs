using Autofac;
using Backend.Models.Calculation;
using Backend.Models.Viewer;
using Backend.Models;

namespace Backend.Services
{
    internal class ContainerConfig
    {
        public static IContainer ConfigureContainer()
        {


            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationService>().As<IApplicationService>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<Reader>().As<IReadable>();
            builder.RegisterType<MovieStar>().As<IMovieStar>();
            builder.RegisterType<TaxCalculation>().As<ITaxCalculation>();
            builder.RegisterType<Viewer>().As<IViewer>();
            builder.RegisterType<SalaryCalculator>().As<ISalaryCalculator>();
            builder.RegisterType<Taxes>().As<ITaxes>();
            builder.RegisterType<Salary>().As<ISalary>();
            builder.RegisterType<Source>().As<ISource>();   

            return builder.Build();
        }
    }
}
