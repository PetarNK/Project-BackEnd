using System;

namespace Backend.Models
{
    public interface IMovieStar
    {
         DateTime DateOfBirth { get; set; }
         string Name { get; set; }
         string Surname { get; set; }
         string Email { get; set; }
         string Sex { get; set; }

         string Nationality { get; set; }
    }
}
