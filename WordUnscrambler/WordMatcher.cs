using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    internal class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    //scrambleWord already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        //convert string into character arrays
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] unscrambledWordArray = word.ToCharArray();

                        //sort both chracter arrays
                        Array.Sort(scrambledWordArray);
                        Array.Sort(unscrambledWordArray);

                        //convert back to a string
                        string scramble = getString(scrambledWordArray);
                        string unscramble = getString(unscrambledWordArray);

                        //compare the two strings
                        if (scramble == unscramble)
                        {
                            // if they are equal, add to matchedWord list
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }
            }
            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }

        public string getString(char[] arr)
        {
            string word = string.Concat(arr);
            return word;
        }
    }
}