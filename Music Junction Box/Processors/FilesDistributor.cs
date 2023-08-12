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
        private FilesGrubber _filesGrubber;
        private FilesMover _filesMover;

        public FilesDistributor(FilesGrubber filesGrubber, FilesMover filesMover)
        {
            _filesGrubber = filesGrubber;
            _filesMover = filesMover;
        }


    }
}
