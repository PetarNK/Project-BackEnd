using System;
using System.IO;
using System.Text;

namespace Backend.Services
{
    public class ApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit

        public ApplicationService()
        {
            DisplayMenu();
        }

        public void Run()
        {
            var userChoice = DisplayMenu();
        }

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
