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
                        scrambledWordArray.Sort();

                        //act -> sort -> act
                        //cat -> sort -> act

                        //convert back to a string

                        //compare the two strings
                        // if they are equal, add to matchedWord list
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
    }
}