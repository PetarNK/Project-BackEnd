using Backend.Models.Viewer;
using Backend.Models;
using System;
using log4net;

namespace Backend.Services
{
    public class BusinessLogic : IBusinessLogic
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BusinessLogic));
        private readonly IViewer _viewer;
        private readonly ISalaryCalculator _salaryCalculator;

        public BusinessLogic(IViewer viewer, ISalaryCalculator salaryCalculator)
        {
            _viewer = viewer;
            _salaryCalculator = salaryCalculator;
        }

        public void Execution()
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
                log.Error($"An error has occurred: {ex.Message}", ex);
                Console.WriteLine(ex.Message);
            }
            Execution();
        }

        public int DisplayMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("1. View Movie Stars List");
            Console.WriteLine("2. Calculate Net Salary");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            log.Info("Creating the menu");
            int input;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= 1 && input <= 3)
                        break;
                    else
                        log.Info("Invalid number input");
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                }
                else
                {
                    log.Info("Invalid data type input");
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return input;
        }
    }
}

