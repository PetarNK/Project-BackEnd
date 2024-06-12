using System.Collections.Generic;

namespace Backend.Models
{
    public interface IReadable
    {
        ICollection<MovieStar> Read(string filePath);
    }
}
