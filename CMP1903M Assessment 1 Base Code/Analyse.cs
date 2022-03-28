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
        string[] fileOutputStrings;

        string vowels;
        string consonants;

        //Constructor 
        public Analyse(string txt)
        {
            text = txt;
            fileOutputStrings = new string[]{ };

            vowels = "aeiou";
            consonants = "bcdfghjklmnpqrstvwxyz";
        }

        //Method not in base code
        //Method: GetFileOutputStrings
        //Returns: string array of long words to be put into long words file
        public string[] GetFileOutputStrings()
        {
            return fileOutputStrings;
        }


        //Method: AnalyseText
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> AnalyseText()
        {
            //List of integers to hold the first five measurements:
            //0. Number of sentences
            //1. Number of vowels
            //2. Number of consonants
            //3. Number of upper case letters
            //4. Number of lower case letters
            //5 - 31. Number of A-Z
            List<int> values = new List<int>();
            string newWord = "";

            //Initialise all the values in the list to '0'
            for (int i = 0; i < 32; i++)
            {
                values.Add(0);
            }

            foreach (char c in text)
            {
                //Check for word end
                if (Char.IsLetterOrDigit(c))
                {
                    newWord += c;
                }

                else
                {
                    AddToFileOutputStrings(newWord, values);

                    newWord = "";
                }
                
                //Increment number of words
                if (c == '.')
                {
                    values[0]++;
                }

                //Increment number of vowels
                else if (vowels.Contains(char.ToLower(c)))
                {
                    values[1]++;
                    values[char.ToLower(c) + 6 - 97]++;
                }

                //Increment number of consonants
                else if (consonants.Contains(char.ToLower(c)))
                {
                    values[2]++;
                    values[char.ToLower(c) + 6 - 97]++;
                }

                //Increment number of upper-case characters
                if (Char.IsUpper(c))
                {
                    values[3]++;
                }

                //Increment number of lower-case characters
                else if (Char.IsLower(c))
                {
                    values[4]++;
                }

            }

            //Final check if last word is long enough to be added to file
            AddToFileOutputStrings(newWord, values);

            return values;
        }


        //Method not in base code
        //Method: IncrementValuesList
        /* Parameters:
         * String newWord (Word to add to array if long enough)
         * List<int> valsList (List to add the new word to & return)
         */
        //Returns: list of integers
        //If long enough, adds a new word to the array of strings, after resizing, to be added to the LongWords file.
        public List<int> AddToFileOutputStrings(string newWord, List<int> valsList)
        {
            if (newWord.Length > 7)
            {
                fileOutputStrings.Append(newWord);
                Array.Resize(ref fileOutputStrings, fileOutputStrings.Length + 1);
                fileOutputStrings[fileOutputStrings.Length - 1] = newWord;
                valsList[5]++;
            }

            return valsList;
        }
    }
}
