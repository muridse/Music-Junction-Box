using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Junction_Box.Processors
{
    internal class FilesGrubber
    {
        private string InputPath;
        private FileInfo[] Files;
        public List<string> SortedPaths { get; private set; }
        public FilesGrubber(string inputPath) 
        {
            InputPath = inputPath;
            ScanDirectory();
            FillSortedPaths();
        }
        private void ScanDirectory() 
        {
            DirectoryInfo di = new DirectoryInfo(InputPath);
            Files = di.GetFiles();
        }
        private void FillSortedPaths() 
        {
            var sortedFiles = Files.OrderBy(f => f.Length);
            foreach (FileInfo fi in sortedFiles) 
            {
                SortedPaths.Add(fi.ToString());
            }
        }
        public void ShowFiles() 
        {
            foreach (var fi in Files.OrderBy(f=>f.Length))
            {
                Console.WriteLine($"{fi} - {Math.Round((double)fi.Length / (1024 * 1024), 2)} MB");
            }
        }
    }
}
