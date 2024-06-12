using System;


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

        
    }
}

