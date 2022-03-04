using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1
        string text = "nothing";
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Gimme Dat Inputtiedoo: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                    text = Console.ReadLine();
                    if (text != null)
                    {
                        return text;
                    }
                    else
                    {
                        throw new FormatException("Input is null");
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input \n");
                }
            }
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string filePath)
        {
            Console.WriteLine(filePath);
            try
            {
                text = File.ReadAllText(filePath);

                Console.WriteLine(text);
                Console.ReadLine();
            }

            catch(FileNotFoundException)
            {
                Console.WriteLine("File does not exist, exiting program, press enter to exit.");
                Console.ReadLine();
                Environment.Exit(1);
            }

            /*if (File.Exists(filePath))
            {
                text = File.ReadAllText(filePath);

                Console.WriteLine(text);
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("File does not exist, exiting program, press enter to exit.");
                Console.ReadLine();
                Environment.Exit(1);
            }*/


            return text;
        }

    }
}
