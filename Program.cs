using Autofac;
using Backend.Services;


namespace Backend
{
    class Program
    {
        // This is your app entry point
        static void Main(string[] args)
        {
            var container = ContainerConfig.ConfigureContainer();
            // Get your application menu class
            
            var application = container.Resolve<IApplicationService>();

            // Run your application
            application.Run();
            
        }
    }
}
// To add new tax you need to go to Models/Taxes/Taxes class. Create a new field with the percentage of tax (in decimal).
// Create a property that returns the value of the field (good for encapsulation). Return the property in the already created GetNewTaxValue
// method. You can now assign the returned value from the method and use it with the method CalculateTax.

