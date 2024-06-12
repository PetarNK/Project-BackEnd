using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal class Reader : IReadable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Reader));



        public ICollection<MovieStar> Read(string filePath)
        {
            try
            {

                // Read all text from the file
                string json = File.ReadAllText(filePath);

                // Deserialize the JSON into the specified type
                ICollection<MovieStar> result = JsonConvert.DeserializeObject<List<MovieStar>>(json);

                //Returns the result in a List of Movie Stars
                return result;
            }
            catch (Exception ex)
            {
                log.Error($"An error occurred while reading the file: {ex.Message}", ex);
                throw;
            }
        }
    }
}
