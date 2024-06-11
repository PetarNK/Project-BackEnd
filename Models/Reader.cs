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
        public List<Person> Read(string filePath)
        {
            try
            {
                //log.Info($"Reading JSON file from path: {filePath}");

                // Read all text from the file
                string json = File.ReadAllText(filePath);

                //log.Debug($"File content: {json}");

                // Deserialize the JSON into the specified type
                List<Person> result = JsonConvert.DeserializeObject<List<Person>>(json);

                

                //log.Info("Successfully deserialized JSON content.");

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
