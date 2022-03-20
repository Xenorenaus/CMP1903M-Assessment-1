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


        public string[] GetFileOutputStrings()
        {
            return fileOutputStrings;
        }


        //Method: analyseText
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
                if (c != ' ' && c != '.' && c != ',' && c != '\r')
                {
                    newWord += c;
                }

                else
                {
                    if (newWord.Length > 7)
                    {
                        fileOutputStrings.Append(newWord);
                        Array.Resize(ref fileOutputStrings, fileOutputStrings.Length + 1);
                        fileOutputStrings[fileOutputStrings.Length - 1] = newWord;
                        values[5]++;
                    }

                    newWord = "";
                }
                
                if (c == '.')
                {
                    values[0]++;
                }

                else if (vowels.Contains(char.ToLower(c)))
                {
                    values[1]++;
                    values[char.ToLower(c) + 6 - 97]++;
                }

                else if (consonants.Contains(char.ToLower(c)))
                {
                    values[2]++;
                    values[char.ToLower(c) + 6 - 97]++;
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

            if (newWord.Length > 7)
            {
                fileOutputStrings.Append(newWord);
                Array.Resize(ref fileOutputStrings, fileOutputStrings.Length + 1);
                fileOutputStrings[fileOutputStrings.Length - 1] = newWord;
                values[5]++;
            }

            return values;
        }
    }
}
