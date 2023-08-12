using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Junction_Box.Processors
{
    internal class FilesDistributor
    {
        private List<string> SortedFiles;
        private string _destinationPath;
        private int _bucketsCount;
        private FilesGrubber _filesGrubber;
        private FilesMover _filesMover;

        public FilesDistributor(FilesGrubber filesGrubber, FilesMover filesMover, int bucketsCount, string destinationPath)
        {
            _filesGrubber = filesGrubber;
            _filesMover = filesMover;
            _bucketsCount = bucketsCount;
            _destinationPath = destinationPath;
            SortedFiles = _filesGrubber.SortedPaths;
        }
        public void DestributeToDestinationPath() 
        {
            var filesSplitedList = GetBucketedFiles();
            for (int i = 0; i < filesSplitedList.Count; i++)
            {
                var bucketPath = _destinationPath + $"\\CD_{i + 1}";
                Directory.CreateDirectory(bucketPath);
                for (int j = 0; j < filesSplitedList[i].Count; j++)
                {
                    var arrayOfFilePath = filesSplitedList[i][j].Split('\\', StringSplitOptions.RemoveEmptyEntries);
                    _filesMover.MoveFile(filesSplitedList[i][j], 
                        bucketPath + arrayOfFilePath[arrayOfFilePath.Length - 1]);

                }
            }
        }
        private List<List<string>> GetBucketedFiles() 
        {
            var buckets = new List<List<string>>();
            var filesLen = SortedFiles.Count;
            var splitPoints = GetSplitPoints();
            for (int i = 0; i < splitPoints.Length - 1; i++)
            {
                buckets.Add(SortedFiles.GetRange(splitPoints[i], splitPoints[i+1] - splitPoints[i]));
            }
            return buckets;
        }
        private int[] GetSplitPoints() 
        {
            var bucketsPoints = new int[_bucketsCount + 1];
            for (int i = 0; i < bucketsPoints.Length; i++)
            {
                bucketsPoints[i] = (SortedFiles.Count / _bucketsCount) * i;
            }
            bucketsPoints[bucketsPoints.Length - 1] = SortedFiles.Count - 1;
            return bucketsPoints;
        }


    }
}
