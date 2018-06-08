using System;
using System.IO;
using System.Text;

namespace GuessingGame
{
   public class Program
    {
        public static string path = "MyFile.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateFile();
        }

        public static string CreateFile()
        {
            if (!File.Exists((path)))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("This is my file");
                }
            }

            return "File created";
        }

        public static int TestMethod()
        {
            return 1;
        }

    }
}
