using System.Collections.Generic;

namespace Backend.Models
{
    internal interface IReadable
    {
        ICollection<MovieStar> Read(string filePath);
    }
}
