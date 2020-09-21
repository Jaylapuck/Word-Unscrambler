using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    internal class FileReader
    {
        public string[] Read(string filename)
        {
            //declare a string[] to hold the contents of the file
            //try/catch
            //ReadAllLines()
            string[] filecontent = null;
            try
            {
                filecontent = File.ReadAllLines(filename);

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File was not found" + ex.Message);
            }
            //return file contents, which is a string[]
            //Line of code should be around 9
            
            return filecontent;
        }
    }
}