using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    //Handles the text input for Assessment 1
    public class Input
    {
        string text;
        EnumerationContainer.InputTypes inputType;

        string filePath;

        //Constructor
        public Input()
        {
            text = "";
            inputType = EnumerationContainer.InputTypes.None;

            filePath = "";
        }


        //Method not in base code
        //Method: GetText
        //Returns: string (The text input)
        //Passes a function to get input based on the user's choice of input type
        public string GetText()
        {
            SetInputType();

            try
            {
                if (inputType.Equals(EnumerationContainer.InputTypes.ManualInput))
                {
                    ManualTextInput();
                }

                else if (inputType.Equals(EnumerationContainer.InputTypes.FileInput))
                {
                    FileTextInput(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filePath));
                }

                else
                {
                    throw new Exception("What the f***???");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().Message + "\n");
                Console.ReadLine();
                Environment.Exit(1);
            }

            return text;
        }


        //Method not in base code
        //Method: SetInputType
        //Retrieves input and determines whether inputType is manual or from a file, in which case, which file
        void SetInputType()
        {
            string choice;
            string fileName;

            while (inputType.Equals(EnumerationContainer.InputTypes.None))
            {
                try
                {
                    Console.WriteLine("\nWhat input would you like to get?\n" +
                        "1) Enter the text via the keyboard?\n" +
                        "2) Read in the text from a file?");

                    choice = Console.ReadLine() ?? "";

                    switch (choice)
                    {
                        case ("1"):
                        {
                            inputType = EnumerationContainer.InputTypes.ManualInput;
                            break;
                        }

                        case ("2"):
                        {
                            Console.WriteLine("\nWhat is the file's name? (Leave blank for default file)");

                            fileName = Console.ReadLine() ?? "";

                            if (fileName == "")
                            {
                                fileName = "ReadFromFile";
                            }

                            filePath = @"..\..\..\..\" + fileName + ".txt";

                            inputType = EnumerationContainer.InputTypes.FileInput;
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
        }


        //Method: ManualTextInput
        //Sets text based on input from the keyboard
        void ManualTextInput()
        {
            while (true)
            {
                try
                {
                    string newText;
                    bool endInput = false;

                    while (!endInput)
                    {
                            Console.WriteLine("\nGimme Dat Inputtiedoo(* as last character for another line of input): ");//, put \\n at the start of the line to write another line after

                        newText = Console.ReadLine() ?? "";

                        if (newText != null || newText == '\r'.ToString())
                        {
                            text += newText;

                            if (newText[newText.Length - 1] != '*')
                            {
                                endInput = true;
                            }
                        }

                        else
                        {
                            throw new FormatException("Input is null");
                        }
                    }

                    return;
                }

                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid input \n");
                }
            }
        }

        //Method: FileTextInput
        //Arguments: string (the file path)
        //Sets text based on input from a .txt file
        void FileTextInput(string filePath)
        {
            Console.WriteLine(filePath);

            try
            {
                text = File.ReadAllText(filePath);
                if (text != null)
                {
                    return;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }

            catch(FileNotFoundException)
            {
                Console.WriteLine("File does not exist, exiting program, press enter to exit.");
                Console.ReadLine();
                Environment.Exit(1);
            }
        }
    }


    
}
