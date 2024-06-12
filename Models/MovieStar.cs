using Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class MovieStar : IMovieStar
    {
		public DateTime DateOfBirth { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }

		public string Nationality { get; set; }


        //       {
        //	"dateOfBirth": "27-Oct-1995",
        //	"Name": "Adolf",
        //	"Surname": "Mayo",
        //	"Email": "amayo0@huffingtonpost.com",
        //	"Sex": "Male",
        //	"Nationality": "irish"
        //},

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