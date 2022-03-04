using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Handles the analysis of text
    public class Analyse
    {
        string text;

        string vowels;
        string consonants;


        //Constructor 
        public Analyse(string txt)
        {
            text = txt;

            vowels = "aeiou";
            consonants = "bcdfghjklmnpqrstvwxyz";
        }


        //Method: analyseText
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText()
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();

            //Initialise all the values in the list to '0'
            for(int i = 0; i<5; i++)
            {
                values.Add(0);
            }

            foreach (char c in text)
            {
                if (c == '.')
                {
                    values[0]++;
                }

                else if (vowels.Contains(char.ToLower(c)))
                {
                    values[1]++;
                }

                else if (consonants.Contains(char.ToLower(c)))
                {
                    values[2]++;
                }

                if (Char.IsUpper(c))
                {
                    values[3]++;
                }

                else if (Char.IsLower(c))
                {
                    values[4]++;
                }
            }

            return values;
        }
    }
}
