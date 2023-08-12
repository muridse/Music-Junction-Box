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
            Console.WriteLine("Instruction:\r\nOpen the folder with the program and put your files in a folder named 'Original'\n");

            var localPath = new DirectoryInfo(Directory.GetCurrentDirectory());
            FilesPath = localPath.FullName + "\\Music\\Original";
            SplitedFilesPath = localPath.FullName + "\\Music\\New split";
            Directory.CreateDirectory(FilesPath);
            Directory.CreateDirectory(SplitedFilesPath);

            DirectoryInfo dic = new DirectoryInfo(FilesPath);
            if (dic.GetFiles().Length == 0) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Files in 'Original' path not found! Put your files into path.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                throw new ArgumentNullException();
            }

            Console.Write("Enter count of CD's to split files between: ");
            BucketsCount = Int32.Parse(Console.ReadLine());

            var grabber = new FilesGrubber(FilesPath);
            var mover = new FilesMover();

            Console.WriteLine("\n\nThe list of files:");
            Console.ForegroundColor = ConsoleColor.Green;
            grabber.ShowFiles();
            Console.ForegroundColor = ConsoleColor.White;

            FilesDistributor = new FilesDistributor(grabber,mover,BucketsCount, SplitedFilesPath);


            
            Console.WriteLine("\nSUCCESS! Press key to exit.");
            Console.ReadKey();

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
