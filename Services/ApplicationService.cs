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
            if (userChoice == 1)
            {
                //log4net.Config.XmlConfigurator.Configure(); 
                IReadable reader = new Reader();
                
                string filePath = FileFinder.FindApplicationFile("input.txt").ToString();

                try
                {
                    // Assuming you have a class named MyData that matches the JSON structure
                    List<Person> data = reader.Read(filePath);

                    //Console.WriteLine("Data successfully read:");
                    //Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
                    foreach (Person person in data)
                    {
                        StringBuilder sb = new StringBuilder();
                        DateTime today = DateTime.Now;
                        int year = YearCalculator.CalculateYearDifference(person.DateOfBirth, today);



                        sb.AppendLine($"{person.Name} {person.Surname}");
                        sb.AppendLine(person.Sex);
                        sb.AppendLine(person.Nationality);
                        sb.AppendLine($"{year} years old");
                        Console.WriteLine(sb);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            } else if(userChoice == 2)
            {

            }
            else if(userChoice == 3)
            {

            }

            Run();
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
