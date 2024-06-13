using Backend.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backend.Models.Viewer
{
    public class Viewer : IViewer
    {
        private readonly IReadable _reader;
        private readonly ISource _source;
        private static readonly ILog log = LogManager.GetLogger(typeof(Viewer));

        public Viewer(IReadable reader, ISource source)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public void View()
        {
            try
            {
                string source = _source.GetSourceName();
                string filePath = FileFinder.FindApplicationFile(source)?.ToString();

                if (string.IsNullOrEmpty(filePath))
                {
                    log.Error($"File not found: {source}");
                    throw new FileNotFoundException();
                }

                log.Info($"Reading data from file: {filePath}");

                IEnumerable<MovieStar> data = _reader.Read(filePath);
                DateTime today = DateTime.Now;
                StringBuilder sb = new StringBuilder();

                foreach (var person in data)
                {
                    int year = YearCalculator.CalculateYearDifference(person.DateOfBirth, today);

                    sb.Clear();
                    sb.AppendLine($"{person.Name} {person.Surname}");
                    sb.AppendLine(person.Sex);
                    sb.AppendLine(person.Nationality);
                    sb.AppendLine($"{year} years old");
                    log.Info(sb.ToString());
                    Console.WriteLine(sb.ToString());
                }
            }
            catch (FileNotFoundException ex)
            {
                log.Error($"File was not found: {ex.Message}", ex);
                Console.WriteLine($"File was not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                log.Error($"An error has occured: {ex.Message}", ex);
                Console.WriteLine($"An error has occured: {ex.Message}");
            }
            
        }
    }
}
