using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_MoreAboutVariables_Q7
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: accept a string from the user and output the string with the characters in reverse order
     * Restrictions: None
     */
    static internal class Program
    {
        /* Method: Main
         * Purpose: 
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            string initialWord;
            char[] letters;

            // accept a string from the user
            Console.WriteLine("Please enter a word: ");
            initialWord = Console.ReadLine();

            // split that string into letters
            letters = initialWord.ToCharArray();

            Console.Write("Here is your reversed word: ");

            // print each letter of the word in reverse order
            for (int i = letters.Length- 1; i >= 0; i--)
            {
                Console.Write(letters[i]);
            }
            Console.WriteLine();

        }
    }
}
