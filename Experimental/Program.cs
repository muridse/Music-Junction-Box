namespace Experimental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Games\\Forza Horizon 5\\Content";
            var arr = Directory.GetFiles(path);
            foreach ( var item in arr ) 
            {
                //Console.WriteLine(item);
            }

            // Make a reference to a directory.
            DirectoryInfo di = new DirectoryInfo(path);
            // Get a reference to each file in that directory.
            FileInfo[] fiArr = di.GetFiles();
            var fiArrSorted = fiArr.OrderBy(p => p.Length);
            foreach ( FileInfo fi in fiArrSorted ) 
            {
                Console.WriteLine($"{fi.ToString()} - {Math.Round((double)fi.Length / (1024 * 1024),2)} MB");
            }
        }
    }
}