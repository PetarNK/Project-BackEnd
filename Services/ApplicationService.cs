using Backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Backend.Helpers;

namespace Backend.Services
{
    public class ApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit

        public ApplicationService()
        {
            
        }

        public void Run()
        {
            var userChoice = DisplayMenu();

            //If/else for different choices
            if (userChoice == 1)
            { 
                MovieStarViewer viewer = new MovieStarViewer();
                viewer.View();
                

            } else if(userChoice == 2)
            {

            }
            else if(userChoice == 3)
            {

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
