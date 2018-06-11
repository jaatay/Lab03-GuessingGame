using System;
using System.IO;
using System.Text;

namespace GuessingGame
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateFile();
            StartGame();
        }

        /// <summary>
        /// Global string setting text file path
        /// </summary>
        public static string path = "MyFile.txt";

        /// <summary>
        /// Global strings to track right and wrong letter guesses
        /// </summary>
        public static string rightLetter, wrongLetter;

        /// <summary>
        /// Global boolean values to continue game while loops.
        /// </summary>
        public static bool keepPlayingMain = true;
        public static bool keepPlayingGuess = true;

        /// <summary>
        /// Presents the user with a set of menu options, receives user input
        /// </summary>
        public static void StartGame()
        {
            rightLetter = "";
            wrongLetter = "";

            while (keepPlayingMain == true)
            {
                Console.WriteLine("LET'S PLAY A GAME!");
                Console.WriteLine("The object is to guess a word, one letter at a time.");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1: Play Game");
                Console.WriteLine("2: Add New Word");
                Console.WriteLine("3: View Current Words");
                Console.WriteLine("4: Quit");

                Int32.TryParse(Console.ReadLine(), out int userNumber);
                if (userNumber == 0 || userNumber > 4 || userNumber < 0)
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
        /// Takes user input from StartGame() and calls method based on choice.
        /// </summary>
        /// <param name="userNumber"></param>
        /// <returns>Returns int 0 if the user does not select a valid option</returns>
        public static int UserChoice(int userNumber)
        {
            if (userNumber == 1)
            {
                NewGame();
            }
            if (userNumber == 2)
            {
                Console.Clear();
                Console.WriteLine("Please enter the word you would like to add below:");
                try
                {
                    string newWord = Console.ReadLine().ToLower();
                    if (newWord == "" || newWord == null)
                    {
                        throw new FormatException();
                    }

                    UpdateFile(newWord);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
            }
            if (userNumber == 3)
            {
                Console.Clear();
                ReadFile();
                
            }
            if (userNumber == 4)
            {
                keepPlayingMain = false;
                Console.WriteLine("Thanks for playing.");
            }

            return 0;
        }

        /// <summary>
        /// method to begin new game using randomly selected word from the list
        /// </summary>
        public static void NewGame()
        {
            Console.Clear();
            string guessThisWord = PickRandomWord();
            keepPlayingGuess = true;
            rightLetter = "";
            wrongLetter = "";
           
            while (keepPlayingGuess)
            {
                GuessLetter(guessThisWord);
               
            }
        }

        /// <summary>
        /// Method to pick random word from .txt file array
        /// </summary>
        /// <returns>returns string of picked word</returns>
        public static string PickRandomWord()
        {
            Random randomNumber = new Random();
            string[] allWords = File.ReadAllLines(path);
            int pickMe = randomNumber.Next(0, allWords.Length);
            string pickedWord = allWords[pickMe];

            return pickedWord;
        }

        /// <summary>
        /// method that evaluates the user's letter guess and handle exceptions for invalid input
        /// </summary>
        /// <param name="inputWord">input of the random word as a string</param>
        /// <returns>returns the user's guess</returns>
        public static string GuessLetter(string inputWord)
        {

            Console.WriteLine("Pick a SINGLE character to guess.");
           

            try
            {
                string guessedLetter = Console.ReadLine().ToLower();

                if (guessedLetter.Length > 1)
                {
                    throw new FormatException();
                }

                if (guessedLetter == null || guessedLetter == "")
                {
                    throw new FormatException();
                }

                CompareLetter(inputWord, guessedLetter);
     
                return guessedLetter;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Please provide a valid input.");
                return "";
            }

        }

        /// <summary>
        /// method to check whether user's letter guess is included in the random word
        /// </summary>
        /// <param name="inputWord">word input is the randomly generated word</param>
        /// <param name="guessedLetter">letter input is taken from the GuessLetter() method</param>
        public static void CompareLetter(string inputWord, string guessedLetter)
        {

            Console.Clear();

          
            Console.WriteLine($"Letters guessed right: {rightLetter}");
            Console.WriteLine($"Letters guessed wrong: {wrongLetter}");

            if (inputWord.Contains(guessedLetter))
            {
                rightLetter += guessedLetter;
                Console.WriteLine($"Correct Letter: {guessedLetter}");

            }
            else
            {
                wrongLetter += guessedLetter;
                Console.WriteLine($"Incorrect Letter: {guessedLetter}");
            }

            //if user guesses correct letter, compare total correct letters with random word
            CompareWord(inputWord, rightLetter);

            Console.WriteLine("");
        }

        /// <summary>
        /// method that compares the user's correct guesses with the random word, triggering end of game if all letters have been guessed
        /// </summary>
        /// <param name="guessWord">input random word string</param>
        /// <param name="inputGuessedLetters">total correctly guessed letter string</param>
        /// <returns></returns>
        public static void CompareWord(string guessWord, string inputGuessedLetters)
        {
           
            if (guessWord.Length == inputGuessedLetters.Length)
            {
                Console.WriteLine($"Congratulations you got all the letters in the word {guessWord}!");
                keepPlayingGuess = false;
            }
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
                    sw.WriteLine("cat");
                    sw.WriteLine("bat");
                    sw.WriteLine("hat");
                    sw.WriteLine("42");
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
                Console.Clear();
                Console.WriteLine("The current words are: ");
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
                Console.Clear();
                Console.WriteLine($"File updated with:{userInput}");
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
