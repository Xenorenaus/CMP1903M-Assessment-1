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
        string text;
        InputTypes inputType;

        string filePath;


        //Constructor
        public Input()
        {
            text = "";
            inputType = InputTypes.None;

            filePath = "";
        }

        public string GetText()
        {
            SetInput();

            try
            {
                if (inputType.Equals(InputTypes.ManualInput))
                {
                    manualTextInput();
                }

                else if (inputType.Equals(InputTypes.FileInput))
                {
                    fileTextInput(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filePath));
                }

                else
                {
                    throw new Exception("What the f***???");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().Message + "\n");
            }

            return text;
        }

        void SetInput()
        {
            string choice;
            string fileName;
            while (inputType.Equals(InputTypes.None))
            {
                try
                {
                    Console.WriteLine("\nWhat input would you like to get?\n" +
                        "1) Enter the text via the keyboard?\n" +
                        "2. Read in the text from a file?");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    choice = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                    switch (choice)
                    {
                        case ("1"):
                            {
                                inputType = InputTypes.ManualInput;
                                break;
                            }

                        case ("2"):
                            {
                                Console.WriteLine("What is the file's name?");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                                fileName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                                filePath = @"..\..\..\..\" + fileName + ".txt";

                                inputType = InputTypes.FileInput;
                                break;
                            }

                        default:
                            {
                                throw new Exception("Given choice was neither 1 nor 0");
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
        }

        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        void manualTextInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Gimme Dat Inputtiedoo: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                    text = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                    if (text != null)
                    {
                        return;
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
        void fileTextInput(string filePath)
        {
            Console.WriteLine(filePath);
            try
            {
                text = File.ReadAllText(filePath);
                return;
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
        }
    }

    enum InputTypes
    {
        None,
        ManualInput,
        FileInput
    }

}
