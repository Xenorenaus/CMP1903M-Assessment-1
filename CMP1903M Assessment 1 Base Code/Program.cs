//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            string text;
            string[] fileOutputStrings;

            bool displayLetters = false;
            bool validChoice = false;
            string choice;

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            Input newInput = new();
            text = newInput.GetText();

            //Create an 'Analyse' object from constructor
            //Get parameters from the text analysis
            Analyse newAnalysis = new(text);
            parameters = newAnalysis.AnalyseText();
            fileOutputStrings = newAnalysis.GetFileOutputStrings();

            //Create 'Report' object from constructor, passing parameters
            //Display the results of the analysis
            Report newReport = new(text, parameters, fileOutputStrings);
            newReport.DisplayMainStatistics();


            //Get whether to see frequency of individual letters
            while (!validChoice)
            {
                try
                {
                    Console.WriteLine("\nWould you like to see the amount of times each letter was used?\n" +
                        "1) Yes\n" +
                        "2) No");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    choice = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                    switch (choice)
                    {
                        case ("1"):
                            {
                                displayLetters = true;
                                validChoice = true;
                                break;
                            }

                        case ("2"):
                            {
                                validChoice = true;
                                break;
                            }

                        default:
                            {
                                throw new Exception("Given choice was neither 1 nor 2");
                            }
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input \n");
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message + "\n");
                }
            }


            //Display frequency of individual letters
            if (displayLetters)
            {
                newReport.DisplayLetterStatistics();
            }

            Console.WriteLine("\n\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}
