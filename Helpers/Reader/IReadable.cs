using System.Collections.Generic;

namespace Backend.Models
{
    public interface IReadable
    {
        IEnumerable<MovieStar> Read(string s);
    }
}
