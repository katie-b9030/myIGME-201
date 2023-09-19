using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_MoreAboutVariables_Q9
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: places double quotes around each word in a string
     * Restrictions: None
     */
    internal class Program
    {
        /* Method: Main
         * Purpose: ask user to enter their name
         *          have user choose a story
         *          prompt user for part of speech inputs
         *          print final story
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            string initialString;
            string[] words;
            string finalString = "";

            // accept a string from the user
            Console.WriteLine("Please enter a multi-word string: ");
            initialString = Console.ReadLine();

            // split that string into words
            words = initialString.Split(' ');

            // append each word to the string with quotes around it and a space following
            for (int i = 0; i < words.Length; i++)
            {
                finalString += "\"" + words[i] + "\" " ;
            }

            // print the final string
            Console.WriteLine("Here is your final string: " + finalString);
        }
    }
}
