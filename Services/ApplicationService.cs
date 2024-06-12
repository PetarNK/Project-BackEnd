using Backend.Models;
using Backend.Models.Viewer;
using log4net;
using System;
using System.Reflection;

namespace Backend.Services
{
    public class ApplicationService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IReadable _reader;
        private readonly IViewer _viewer;
        private readonly ISalaryCalculator _salaryCalculator;
        private readonly string _source = "input.txt";

        public ApplicationService()
        {
            _reader = new Reader();
            _viewer = new Viewer(_reader, _source);
            _salaryCalculator = new SalaryCalculator(1000, 3000, 0.1M, 0.15M);
        }

        public void Run()
        {
            try
            {
                int userChoice = DisplayMenu();

                switch (userChoice)
                {
                    case 1:
                        _viewer.View();
                        break;
                    case 2:
                        _salaryCalculator.Calculate();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentException("Please choose an option from 1 to 3");
                }
            }
            catch (ArgumentException ex)
            {
                log.Error($"An error has occurred: {ex.Message} ", ex);
                Console.WriteLine(ex.Message);
            }
            Run();
        }

        private int DisplayMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("1. View Movie Stars List");
            Console.WriteLine("2. Calculate Net Salary");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            int input;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= 1 && input <= 3)
                        break;
                    else
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return input;
        }
    }
}
