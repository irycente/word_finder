using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.WordStreamProviders.Implementations
{
    public class FileWordStreamProvider : IWordStreamProvider
    {
        private readonly string filePath;

        public FileWordStreamProvider(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<string> GetValidWordStream()
        {
            var fileLines = File.ReadAllLines(filePath, Encoding.UTF8);

            return fileLines;
        }
    }
}
