using System;
using System.Linq;
using Autofac;
using Backend.Models;
using Backend.Services;

namespace Backend
{
    class Program
    {
        // This is your app entry point
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            // Check registered components count
            // Console.WriteLine($"Number of registered components: {container.ComponentRegistry.Registrations.Count()}");

            // Get your application menu class
            var application = container.Resolve<ApplicationService>();

            // Run your application
            application.Run();
        }

        // You should configure DI container (Autofac) or other DI Framework
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Here you should register Interfaces with their referent classes
            builder.RegisterType<ApplicationService>().SingleInstance();
            builder.RegisterType<Reader>().As<IReadable>();
            builder.RegisterType<MovieStar>().As<IMovieStar>();

            // DEBUG: Checking if services are registered
            //Console.WriteLine("Services registered successfully.");

            return builder.Build();
        }
    }
}