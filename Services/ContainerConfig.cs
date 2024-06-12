using Autofac;
using Backend.Models.Calculation;
using Backend.Models.Viewer;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    internal class ContainerConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Here you should register Interfaces with their referent classes
            builder.RegisterType<ApplicationService>().As<IApplicationService>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<Reader>().As<IReadable>();
            builder.RegisterType<MovieStar>().As<IMovieStar>();
            builder.RegisterType<TaxCalculation>().As<ITaxCalculation>();
            builder.RegisterType<Viewer>()
                .WithParameter("source", "input.txt")
                .As<IViewer>();
            builder.Register((c, p) =>
            {
                // Parameters for SalaryCalculator
                int minimumSalary = 1000;
                int maximumSalary = 3000;
                decimal incomeTaxPercentage = 0.1M;
                decimal socialTaxPercentage = 0.15M;

                // Resolve dependencies
                var taxCalculation = c.Resolve<ITaxCalculation>();

                // Instantiate SalaryCalculator
                return new SalaryCalculator(minimumSalary, maximumSalary, incomeTaxPercentage, socialTaxPercentage, taxCalculation);
            }).As<ISalaryCalculator>();

            // DEBUG: Checking if services are registered
            //Console.WriteLine("Services registered successfully.");

            return builder.Build();
        }
    }
}
