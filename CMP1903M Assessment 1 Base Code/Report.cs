using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Handles the reporting of the analysis
    class Report
    {
        string inputText;
        string[] resultTitles;
        List<int> parameters;

        //Constructor
        public Report(string txt, List<int> par)
        {
            inputText = txt;
            resultTitles = new string[] { "Number of Sentences", "Number of Vowels", "Number of consonants", "Number of Upper-Cases", "Number of Lower-Cases" };
            parameters = par;
        }


        public void DisplayStatistics()
        {
            string spaces;

            Console.WriteLine("\n\nThe inputted text is: " + inputText + "\n");

            for (int i = 0; i < 5; i++)
            {
                spaces = new string(' ', (25 - resultTitles[i].Length));
                Console.WriteLine(resultTitles[i] + spaces + parameters[i]);
            }
        }
    }
}