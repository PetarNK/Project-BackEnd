using Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Viewer : IViewer
    {
        private string source = "input.txt";


        public Viewer(IReadable reader)
        {
            this.Reader = reader;
        }

        public IReadable Reader { get; set; }
        public void View()
        {
            //Reader for the data from the file

            string filePath = FileFinder.FindApplicationFile(source).ToString();
            //Using try/catch for any errors with the data from the file.
            try
            {
                //Reading the data from the file path
                ICollection<MovieStar> data = Reader.Read(filePath);

                DateTime today = DateTime.Now;

                //Logging all of the information for each movie star in the data.
                foreach (MovieStar person in data)
                {
                    int year = YearCalculator.CalculateYearDifference(person.DateOfBirth, today);
                    StringBuilder sb = new StringBuilder();
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
