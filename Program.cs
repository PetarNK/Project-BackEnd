using Autofac;
using Backend.Models;
using Backend.Services;

namespace Backend
{
    class Program
    {
        //This is your app entry point
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            //Get your application menu class
            var application = container.Resolve<ApplicationService>();

            //Run your application
            application.Run();
        }

        //You should configure DI container (Autofac) or other DI Framework
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //Here you should register Interfaces with their referent classes
            builder.RegisterType<ApplicationService>().SingleInstance();
            builder.RegisterType<Reader>().SingleInstance();

            return builder.Build();
        }
    }
}
