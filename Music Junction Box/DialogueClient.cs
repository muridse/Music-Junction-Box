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
        private int BucketsCount {  get; set; }
        private FilesDistributor FilesDistributor;
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

            Console.Write("Enter count of CD's to split files between: ");
            BucketsCount = Int32.Parse(Console.ReadLine());

            var grabber = new FilesGrubber(FilesPath);
            var mover = new FilesMover();

            Console.WriteLine("The list of files:");
            grabber.ShowFiles();

            FilesDistributor = new FilesDistributor(grabber,mover,BucketsCount, SplitedFilesPath);


        }
        public void Run() 
        {
            FilesDistributor.DestributeToDestinationPath();
        }
        public static DialogueClient GetInstance()
        {
            return instance;
        }
    }
}
