using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Junction_Box.Processors;
using static System.Net.Mime.MediaTypeNames;

namespace Music_Junction_Box
{
    internal class DialogueClient
    {
        private string FilesPath { get; set; }
        private string SplitedFilesPath { get; set; }
        private static readonly DialogueClient instance = new DialogueClient();
        private DialogueClient() 
        {
            var localPath = new DirectoryInfo(Directory.GetCurrentDirectory());
            FilesPath = localPath.FullName + "\\Music\\Original";
            SplitedFilesPath = localPath.FullName + "\\Music\\New split";
            Directory.CreateDirectory(FilesPath);
            Directory.CreateDirectory(SplitedFilesPath);
        }
        public void Run() 
        {
            
        }
        public static DialogueClient GetInstance()
        {
            return instance;
        }
    }
}
