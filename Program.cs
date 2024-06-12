using Autofac;
using Backend.Models;
using Backend.Models.Calculation;
using Backend.Models.Viewer;
using Backend.Services;
using log4net;


namespace Backend
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        // This is your app entry point
        static void Main(string[] args)
        {
            var container = ContainerConfig.ConfigureContainer();

            // Check registered components count
            // Console.WriteLine($"Number of registered components: {container.ComponentRegistry.Registrations.Count()}");

            // Get your application menu class
            using (var scope = container.BeginLifetimeScope())
            {
                var application = container.Resolve<IApplicationService>();

                // Run your application
                application.Run();
            }
        }

        // You should configure DI container (Autofac) or other DI Framework
       
    }
}
//using Autofac;
//using Backend.Models;
//using Backend.Models.Calculation;
//using Backend.Models.Viewer;
//using Backend.Services;
//using log4net;
//using System;
//using System.Reflection;

//namespace Backend
//{
//    class Program
//    {
//        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

//        static void Main(string[] args)
//        {
//            var container = ConfigureContainer();

//            // Get your application service class
//            var application = container.Resolve<ApplicationService>();

//            // Run your application
//            application.Run();
//        }

//        //private static IContainer ConfigureContainer()
//        //{
//        //    var builder = new ContainerBuilder();

//        //    // Register types with Autofac
//        //    builder.RegisterType<ApplicationService>().SingleInstance(); ;

//        //    builder.RegisterType<Reader>().As<IReadable>();
//        //    builder.RegisterType<Viewer>().As<IViewer>();

//        //    // Register SalaryCalculator with parameters
//        //    builder.Register((c, p) => new TaxCalculation(p.TypedAs<decimal>())).As<ITaxCalculation>();
//        //    builder.Register((c, p) =>
//        //    {
//        //        // Parameters for SalaryCalculator
//        //        int minimumSalary = 1000;
//        //        int maximumSalary = 3000;
//        //        decimal incomeTaxPercentage = 0.1M;
//        //        decimal socialTaxPercentage = 0.15M;

//        //        // Resolve dependencies
//        //        var taxCalculation = c.Resolve<ITaxCalculation>();

//        //        // Instantiate SalaryCalculator
//        //        return new SalaryCalculator(minimumSalary, maximumSalary, incomeTaxPercentage, socialTaxPercentage, taxCalculation);
//        //    }).As<ISalaryCalculator>();
//        //    // Assuming _source is a constant, register it as such
//        //    builder.RegisterInstance("input.txt").As<string>();


//        //    // DEBUG: Checking if services are registered
//        //    Console.WriteLine("Services registered successfully.");

//        //    return builder.Build();
//        //}
//        private static IContainer ConfigureContainer()
//        {
//            var builder = new ContainerBuilder();

//            // Register your services
//            builder.RegisterType<ApplicationService>().SingleInstance();
//            builder.RegisterType<Reader>().As<IReadable>();
//            builder.RegisterType<Viewer>().As<IViewer>();
//            builder.RegisterType<SalaryCalculator>().As<ISalaryCalculator>();

//            // Register ITaxCalculation with parameters
//            builder.Register((c, p) => new TaxCalculation(p.TypedAs<decimal>())).As<ITaxCalculation>();

//            // Register the constant for the source
//            builder.RegisterInstance("input.txt").As<string>();

//            return builder.Build();
//        }

//    }
//}
