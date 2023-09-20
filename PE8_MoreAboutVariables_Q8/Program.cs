using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PE8_MoreAboutVariables_Q8
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: accepts a string and does a case-insensitive replacement of all "no"s with "yes"s
     * Restrictions: None
     */
    static internal class Program
    {
        /* Method: Main
         * Purpose: ask user for a string
         *          replace any "no"s with "yes"s
         *          print the final string
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            string userString;
            //string[] words;
            //char[] wordChars;
            //string finalString = "";

            // accept a string from the user
            Console.WriteLine("Please enter a string (preferably containing the word \"no\"): ");
            userString = Console.ReadLine();

            // if the string contains the word no, replace it with yes
            userString = userString.Replace("no", "yes");
            userString = userString.Replace("NO", "YES");
            userString = userString.Replace("No", "Yes");
            userString = userString.Replace("nO", "yES");

            // split the words
            //words = userString.Split(' ');

            //// check if the string contains the word "no"
            //for (int i = 0; i < words.Length; i++)
            //{
            //    wordChars = words[i].ToCharArray();
            //    if (words[i].ToLower() == "no")
            //    {

            //        // if it does, replace it with yes
            //        if (wordChars[0] == 'N')
            //        {
            //            finalString += "Y";
            //        }
            //        else
            //        {
            //            finalString += "y";
            //        }
            //        if (wordChars[1] == 'O')
            //        {
            //            finalString += "ES";
            //        }
            //        else
            //        {
            //            finalString += "es";
            //        }
            //        if (wordChars.Length > 2)
            //        {
            //            for (int j = 2; j < wordChars.Length; j++)
            //            {
            //                finalString += wordChars[j];
            //            }
            //        }
            //        finalString += " ";
            //    }

            //    // if the word is anything else
            //    else
            //    {
            //        finalString += words[i] + " ";
            //    }
            //}

            //// print the final string
            //Console.WriteLine(finalString);

            Console.WriteLine(userString);
        }
    }
}
