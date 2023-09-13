using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE6_ParsingAndFormatting
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: have a user guess a randomly generated number between 1 and 100
     * Restrictions: None
     */
    static internal class Program
    {
        /* Method: Main
         * Purpose: generate a random integer between 1 and 100
         *          print the
         *          use a loop to let the user attempt to guess 8 times
         *          tell the user what it was
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // generate the number the user should try to guess (0 to 100 inclusive
            Random rand = new Random();
            bool guessedCorrectly = false;
            int randomNumber = rand.Next(0, 101);
            // print the number for testing purposes
            Console.WriteLine("Number to guess: " + randomNumber);
            // give the user 8 tries to guess the number
            for (int i = 1; i <= 8; i++)
            {
                if (!guessedCorrectly)
                {
                    int? userGuess = null;
                    while (userGuess == null)
                    {
                        // prompt the user to guess
                        Console.WriteLine("Turn #" + i + ": Enter your guess: ");
                        // parse the user value and check if it's valid
                        try
                        {
                            userGuess = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid guess - try again");
                        }
                    }
                    // tell the user if their guess was too high, too low, or correct
                    // if they guess correctly, tell them the number of turns it took
                    if ((int)userGuess == randomNumber)
                    {
                        Console.WriteLine("Correct! You won in " + i + " turns!");
                        guessedCorrectly = true;
                    }
                    // if they guess incorrectly, keep guessing
                    else if ((int)userGuess > randomNumber)
                    {
                        Console.WriteLine("Too high");
                        userGuess = null;
                    }
                    else
                    {
                        Console.WriteLine("Too low");
                        userGuess = null;
                    }
                }
            }
            // if they never guess correctly, tell them what it was
            if (!guessedCorrectly)
            {
                Console.WriteLine("You ran out of turns. The number was " + randomNumber + ".");
            }
        }
    }
}

