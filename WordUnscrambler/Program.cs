using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
                    while (Option != Constant.ftype && Option != Constant.mType)
                    {
                        Console.WriteLine(Constant.askType);
                        Option = Console.ReadLine() ?? throw new Exception(Constant.emptyString);

                        switch (Option.ToUpper())
                        {
                            case Constant.ftype:
                                Console.WriteLine(Constant.askFilePath);
                                ExecuteScrambleWordInFileScenario();

                                break;

                            case Constant.mType:
                                Console.WriteLine(Constant.askManual);
                                ExecuteScrambleWordInManuelScenario();

                                break;

                            default:
                                Console.WriteLine(Constant.notRecognize);

                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The program will be terminated." + ex.Message);
                }
            }
        }

        private static void ExecuteScrambleWordInManuelScenario()
        {
            //get user's input - a comma seperated string containing scrambled words
            //string manualInput;
            string listOfWords = Console.ReadLine();
            string[] manualInput = listOfWords.Split(' ', ',');

            DisplayMatchedUnscrambledWords(manualInput);
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
            string[] wordList = _fileReader.Read(Constant.fileName);

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
                    Console.WriteLine("MATCH FOUND FOR " + matchedWord.ScrambledWord + " : " + matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constant.notMatchFound);
            }
            Console.WriteLine(Constant.askContinue);
            String response = Console.ReadLine();
            if (response.ToUpper() == Constant.yes)
            {
                isContinue = true;
            }
            else if (response.ToUpper() == Constant.no)
            {
                isContinue = false;
            }
        }
    }
}