namespace Backend.Models.Viewer
{
    public class Source : ISource
    {
        private readonly string sourceName = "input.txt";

        public string SourceName
        {
            get { return sourceName; }
        }

        public string GetSourceName()
        {
            return SourceName;
        }
    }
}
