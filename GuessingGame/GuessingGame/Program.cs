using System;
using System.IO;
using System.Text;

namespace GuessingGame
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
             StartGame();
           
        }

        /// <summary>
        /// Global string setting text file path
        /// </summary>
        public static string path = "MyFile.txt";

        /// <summary>
        /// Global boolean value to continue game while loop.
        /// </summary>
        public static bool keepPlaying = true;

        /// <summary>
        /// Presents the user with a set of menu options
        /// </summary>
        public static void StartGame(){

            while(keepPlaying == true)
            {
                Console.WriteLine("LET'S PLAY A GAME!");
                Console.WriteLine("The object is to guess a word, one letter at a time.");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1: Play Game");
                Console.WriteLine("2: Add new word");
                Console.WriteLine("3: Admin");
                Console.WriteLine("4: Quit");

                Int32.TryParse(Console.ReadLine(), out int userNumber);
                if (userNumber == 0 || userNumber > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid option.");
                }

                UserChoice(userNumber);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Method that p
        /// </summary>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        public static int UserChoice(int userNumber)
        {
            if (userNumber == 1)
            {
                CreateFile();
            }
            if (userNumber == 2)
            {

            }
            if (userNumber == 3)
            {

            }
            if (userNumber == 4)
            {
                keepPlaying = false;
                Console.WriteLine("Thanks for playing.");
            }

            return 0;
        }
        
        //new game method
        public static void NewGame()
        {

        }

        //add word method

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
                    sw.WriteLine("onomatopoeia");
                    sw.WriteLine("cat");
                    sw.WriteLine("bat");
                    sw.WriteLine("hat");
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
                Console.WriteLine($"File updated with :{userInput}");
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
