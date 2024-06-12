using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Models
{
    internal class Reader : IReadable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Reader));

        public IEnumerable<MovieStar> Read(string filePath)
        {
            try
            {
                // Read all text from the file
                string json = File.ReadAllText(filePath);

                // Logging the JSON content
                log.Debug($"Read JSON content: {json}");

                // Deserialize
                ICollection<MovieStar> result = JsonConvert.DeserializeObject<List<MovieStar>>(json);

                if (result == null)
                {
                    log.Error("Deserialization returned null.");
                    throw new InvalidOperationException("Deserialization returned null.");
                }

                // Return the result in a list of Movie Stars
                return result;
            }
            catch (InvalidOperationException ex)
            {
                log.Error($"An error occurred while reading the file: {ex.Message}", ex);
                throw;
            }
        }
    }
}

