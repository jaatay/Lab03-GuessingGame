using System;
using System.IO;
using System.Text;

namespace GuessingGame
{
    public class Program
    {
        /// <summary>
        /// Global string setting text file path
        /// </summary>
        public static string path = "MyFile.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateFile();
            ReadFile();
            UpdateFile("I just got updated");
        }



        //FILE METHODS BELOW

        /// <summary>
        /// A method for creating a text file if one does not already exist.
        /// </summary>
        /// <returns>Returns string "File created"</returns>
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

        /// <summary>
        /// A method for reading an existing text file
        /// </summary>
        /// <returns>Returns string "File read" or "File not found" if Exception</returns>
        public static string ReadFile()
        {
            try
            {
                string[] fileText = File.ReadAllLines(path);
                foreach (string value in fileText)
                {
                    Console.WriteLine(value);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("File not found");
            }

            return "File read";
        }

        /// <summary>
        /// Updates an existing file with an input user string.
        /// </summary>
        /// <param name="userInput">User-entered argument</param>
        /// <returns>Returns string "File deleted"</returns>
        public static string UpdateFile(string userInput)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(userInput);
                Console.WriteLine($"File updated with {userInput}");
            }

            return "File updated";
        }

        /// <summary>
        /// Method to delete a currently existing file.
        /// </summary>
        /// <returns>Returns string "File deleted"</returns>
        public static string DeleteFile()
        {
            File.Delete(path);

            return "File deleted";
        }
    }
}
