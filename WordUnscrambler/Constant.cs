using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    internal static class Constant
    {
        public const string askType = "Enter scambled word(s) manually or as a file: F- file / M - Manual";
        public const string askFilePath = "Please provide the path of the file";

        public const string notRecognize = "The entered option was not recognized";
        public const string askManual = "Please enter the word(s) manually seperated by commas if multiple";
        public const string fileName = "wordlist.txt";
        public const string notMatchFound = "MATCH HAS NOT BEEN FOUND";
        public const string askContinue = "Would you like to continue? Y/N";
        public const string emptyString = "String is empty/null";
        public const string ftype = "F";
        public const string mType = "M";
        public const string yes = "Y";
        public const string no = "N";
        public const string terminate = "The program will be terminated.";
    }
}