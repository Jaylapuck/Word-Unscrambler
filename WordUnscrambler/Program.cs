using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    internal class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private static bool isContinue = true;

        private static void Main(string[] args)
        {
            while (isContinue == true)
            {
                String Option = null;
                try
                {
                    while (Option != "F" && Option != "M")
                    {
                        Console.WriteLine("Enter scambled word(s) manually or as a file: F- file / M - Manual");
                        Option = Console.ReadLine() ?? throw new Exception("String is empty/null");

                        switch (Option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine("Please provide the path of the file");
                                ExecuteScrambleWordInFileScenario();

                                break;

                            case "M":
                                Console.WriteLine("Please enter the word(s) manually seperated by commas if multiple");
                                ExecuteScrambleWordInManuelScenario();

                                break;

                            default:
                                Console.WriteLine("The entered option was not recognized");

                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The program will be terminated." + ex.Message);
                }
                Console.ReadLine();
            }
        }

        private static void ExecuteScrambleWordInManuelScenario()
        {
            //get user's input - a comma seperated string containing scrambled words
            //string manualInput;
            //extract the wrods into a string[] - use Split()
            //char[] seperators = { ',', ' ' };
            //string[] scrambledWords = manualInput.Split();
        }

        private static void ExecuteScrambleWordInFileScenario()
        {
            //read the user's input - file with scramble words
            var filename = Console.ReadLine();
            //read words from file and store in string[] scrambleWords
            string[] scrambleWords = _fileReader.Read(filename);

            //display the matched words
            DisplayMatchedUnscrambledWords(scrambleWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            //read the list of words in the wordlist.txt file (unscrambled words)
            string[] wordList = _fileReader.Read("wordlist.txt");

            //call a word matcher method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);
            //display the match - print to console

            if (matchedWords.Any())
            {
                //loop throught matchedWords and print to console the content of the structs
                //foreach
                foreach (var matchedWord in matchedWords)
                {
                    //write to console
                    //MATCH FOUND FOR "ACT" = CAT
                    Console.WriteLine("MATCH FOUND FOR" + matchedWord.ScrambledWord + "= " + matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("MATCH HAS NOT BEEN FOUND");
            }
            Console.WriteLine("Would you like to continue? Y/N");
            String response = Console.ReadLine();
            if (response == "Y")
            {
                isContinue = true;
            }
            else if (response == "NO")
            {
                isContinue = false;
            }
        }
    }
}