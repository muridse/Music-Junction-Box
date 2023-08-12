using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Junction_Box.Processors
{
    internal class FilesMover
    {
        public FilesMover() { }
        public void MoveFile(string path, string destinationPath) 
        {
            try
            {
                if (!File.Exists(destinationPath))
                {
                    // This statement ensures that the file is created,
                    // but the handle is not kept.
                    using (FileStream fs = File.Create(destinationPath)) { }
                }

                // Ensure that the target does not exist.
                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);

                // Move the file.
                File.Move(path, destinationPath);


                // See if the original exists now.
                if (File.Exists(path))
                {
                    Console.WriteLine($"The original file still exists, which is unexpected.(error on: {path})");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
