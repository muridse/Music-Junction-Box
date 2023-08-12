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
            
            int maxCount = 0;
            foreach (var fileList in filesSplitedList) 
                if (fileList.Count >= maxCount) maxCount = fileList.Count;

            int counter = 0;
            for (int j = 0; j < filesSplitedList.Count; j++)
            {
                for (int i = 0; i < maxCount; i++)
                {
                    if (filesSplitedList[j].Count > i) 
                    {
                        var bucketPath = _destinationPath + $"\\CD_{counter + 1}";
                        if (!Directory.Exists(bucketPath))
                            Directory.CreateDirectory(bucketPath);

                        var arrayOfFilePath = filesSplitedList[j][i].Split('\\', StringSplitOptions.RemoveEmptyEntries);
                        _filesMover.MoveFile(filesSplitedList[j][i],
                            bucketPath + "\\" + arrayOfFilePath[arrayOfFilePath.Length - 1]);
                        
                        counter++;
                        if (counter >= _bucketsCount) counter = 0;
                    }
                }
            }
        }
        private List<List<string>> GetBucketedFiles() 
        {
            var buckets = new List<List<string>>();
            var filesLen = SortedFiles.Count;
            int margin;
            var splitPoints = GetSplitPoints(out margin);
            for (int i = 0; i < splitPoints.Length - 1; i++)
            {
                buckets.Add(SortedFiles.GetRange(splitPoints[i], splitPoints[i+1] - splitPoints[i]));
            }
            //for (int i = 0; i < margin; i++)
            //{
            //    buckets[buckets.Count - 1].Add(SortedFiles[SortedFiles.Count - i]);
            //}
            return buckets;
        }
        private int[] GetSplitPoints(out int margin) 
        {
            margin = SortedFiles.Count % _bucketsCount;
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
