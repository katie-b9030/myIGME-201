using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE7_MadLibs
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: have a user input words based on the specified part of speech and show them the story
     * Restrictions: None
     */
    static internal class Program
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
            string name = "";
            string resultString = "";
            string playLibs = "";
            bool validData = false;
            bool validNumber = false;
            int storyNum = 0;
            int numMadLibs = 0;
            int currentLine = 0;

            StreamReader input;

            // open template file to collect number of stories
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                numMadLibs++;
            }

            // close template file
            input.Close();

            // make an array with the same length as the number of mad libs
            string[] madLibs = new string[numMadLibs];

            // put one story into each element of the array
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set the element to current line of template
                madLibs[currentLine] = line;

                // replace "\\n" tag with newline
                madLibs[currentLine] = madLibs[currentLine].Replace("\\n", "\n");

                currentLine++;
            }

            input.Close();

            // record user's name
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();

            while (validData == false) {

                // ask the user if they want to play madLibs
                Console.WriteLine("Hello, " + name + ", would you like to play MadLibs?");
                playLibs = Console.ReadLine().ToLower();

                // play madLibs
                if (playLibs == "yes")
                {
                    validData = true;

                    // record user's story number

                    while (!validNumber)
                    {
                        Console.WriteLine("To select a story, please choose a number between 1 and " + numMadLibs);
                        try
                        {
                            storyNum = int.Parse(Console.ReadLine()) - 1;
                            validNumber = true;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                        

                    // split the story into words
                    string[] words = madLibs[storyNum].Split(' ');

                    foreach (string word in words)
                    {
                        // if word is a placeholder
                        if (word[0] == '{')
                        {
                            string replaceWord = word.Replace("{", "").Replace("}", "").Replace("_", " ");
                            // prompt user for replacement
                            Console.Write("Input a {0}: ", replaceWord);
                            // append user response to result string
                            resultString += Console.ReadLine();
                        }
                        // otherwise append word to result string
                        else
                        {
                            resultString += word;
                        }

                        resultString += " ";
                    }

                    // print the resulting story
                    Console.WriteLine(resultString);
                }

                // exit program
                else if (playLibs == "no")
                {
                    validData = true;
                    Console.WriteLine("Goodbye!");
                }

            }
        }
    }
}
