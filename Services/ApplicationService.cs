using Backend.Models;
using Backend.Models.Viewer;
using System;
using System.Text;


namespace Backend.Services
{
    public class ApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit
        private IReadable _reader;
        private IViewer _viewer;
        private string _source = "input.txt";

        public ApplicationService()
        {
            this._reader = new Reader();
            this._viewer = new Viewer(_reader, _source);
        }

        public void Run()
        {
            try
            {
                var userChoice = DisplayMenu();

                //If/else for different choices
                if (userChoice == 1)
                {
                    _viewer.View();


                }
                else if (userChoice == 2)
                {
                    SalaryCalculator calc = new SalaryCalculator(1000, 3000, 0.1M, 0.15M);
                    calc.Calculate();
                }
                else if (userChoice == 3)
                {
                    Environment.Exit(0);
                } else
                {
                    throw new ArgumentException("Please choose an option from 1 to 3");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                Run();
        }

        /// <summary>
        /// Method displaying the main menu. Awaits input!
        /// </summary>
        /// <returns></returns>
        private int DisplayMenu()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("Main Menu");
            sb.AppendLine("---------");
            sb.AppendLine("");
            sb.AppendLine("1. View Movie Stars List");
            sb.AppendLine("2. Calculate Net Salary");
            sb.AppendLine("3. Exit");

            Console.WriteLine(sb);
            
            int input = int.Parse(Console.ReadLine());

            return input;
            
        }

    }
}
