using Backend.Helpers;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    internal class MovieStarViewer
    {
        public void View()
        {
            //Reader for the data from the file
            IReadable reader = new Reader();

            string filePath = FileFinder.FindApplicationFile("input.txt").ToString();
            //Using try/catch for any errors with the data from the file.
            try
            {
                //Reading the data from the file path
                ICollection<MovieStar> data = reader.Read(filePath);

                DateTime today = DateTime.Now;
                //Logging all of the information for each movie star in the data.
                foreach (MovieStar person in data)
                {
                    StringBuilder sb = new StringBuilder();
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
        }
    }
}
