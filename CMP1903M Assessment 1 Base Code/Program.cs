﻿//Base code project for CMP1903M Assessment 1
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

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            Input newInput = new();
            text = newInput.GetText();

            //Create an 'Analyse' object from constructor
            //Get parameters from the text analysis
            Analyse newAnalysis = new(text);
            parameters = newAnalysis.analyseText();

            //Create 'Report' object from constructor, passing parameters
            //Display the results of the analysis


            /* TO DO: Add the ability to input multiple lines of text manually
             * Output file of long words in text (words >= 7 characters)
             */
            //TO ADD: Get the frequency of individual letters?

           
        }
        
        
    
    }
}
