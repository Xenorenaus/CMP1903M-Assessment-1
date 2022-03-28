using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Handles the reporting of the analysis
    class Report
    {
        string inputText;
        string[] resultTitles;
        List<int> parameters;
        string[] fileOutputStrings;

        //Constructor
        public Report(string txt, List<int> par, string[] fOutputStrings)
        {
            inputText = txt;
            resultTitles = new string[] { "Number of Sentences", "Number of Vowels", "Number of consonants", "Number of Upper-Cases", "Number of Lower-Cases", "Number of Long Words" };
            parameters = par;
            fileOutputStrings = fOutputStrings;
        }


        //Method not in base code
        //Method: DisplayMainStatistics
        //Displays the number of sentences, vowels, consonants, upper-case & lower-case letters and the number of long words
        //Also calls CreateLongWordsFile if there are any long words
        public void DisplayMainStatistics()
        {
            string spaces;

            Console.WriteLine("\n\nThe inputted text is: " + inputText + "\n");

            for (int i = 0; i < 6; i++)
            {
                spaces = new string(' ', (25 - resultTitles[i].Length));
                Console.WriteLine(resultTitles[i] + spaces + parameters[i]);
            }

            if (parameters[5] > 0)
            {
                Console.WriteLine("\n\nLong words, added to file Long-Words.txt:\n");

                foreach (string word in fileOutputStrings)
                {
                    Console.WriteLine(word);
                }

                CreateLongWordsFile();
            }

            Console.WriteLine("\n\n");
        }

        //Method not in base code
        //Method: DisplayLetterStatistics
        //Displays frequency of each letter in the input
        public void DisplayLetterStatistics()
        {
            string spaces;

            Console.WriteLine("\n\nThe number of each letter is: \n");

            for (int i = 0; i < 26; i++)
            {
                spaces = new string(' ', 20);
                Console.WriteLine((char)(i+65) + ":" + spaces + parameters[i + 6].ToString());
            }
        }


        //Method not in base code
        //Method: CreateLongWordsFile
        //Creates a file containing all the long words in the input
        void CreateLongWordsFile()
        {
            using (StreamWriter sw = File.CreateText(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Long-Words.txt"))
            {
                foreach (string word in fileOutputStrings)
                {
                    sw.WriteLine(word);
                }
            }
        }
    }
}