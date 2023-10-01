using System;
using System.Timers;

namespace Unit1Exam_Q4
{

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: asks the user to pick between 3 questions and gives them 5 seconds to answer
     * Restrictions: None
     */
    internal class Program
    {
        static Timer timeOutTimer;
        static bool bTimeOut = false;
        static string sAnswer = "";

        /* Method: Main
         * Purpose: ask the user which question they want
         *          ask the question and give them 5 seconds to answer
         *          if they answer correctly say well done
         *          if they answer wrong or run out of time tell them the right answer
         *          ask if they want to play again
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // true while the user wants to play again
            bool bPlayAgain = true;
            string sPlayAgain = "";

            // checks if the user wants to run the loop
            while (bPlayAgain)
            {
                // intitialize variables
                string[] questions = new string[] { "What is your favorite color?", "What is the answer to life, the universe, and everything?", "What is the airspeed velocity of an unladen swallow?" };
                string sQuestion = "";
                int nQuestion = 0;
                bool bValid = false;
                string userAnswer = "";

                // loop until input is valid
                while (!bValid)
                {
                    // prompt the user to choose a question
                    Console.Write("Choose your question (1-3): ");
                    sQuestion = Console.ReadLine();
                    try
                    {
                        nQuestion = int.Parse(sQuestion);
                        // answer is invalid if it is not in range 1-3
                        if (nQuestion > 3 || nQuestion < 1)
                        {
                            bValid = false;
                        }
                        // answer is valid if it is an int in range 1-3 (inclusive)
                        else
                        {
                            bValid = true;
                        }
                    }
                    // ansewr is invalid if it is not an int
                    catch
                    {
                        bValid = false;
                    }
                }

                // reset to check if play again value is valid
                bValid = false;

                // INITIALIZE TIMER
                timeOutTimer = new Timer(5000);

                // Timer calls Timer.Elapsed event handler when the time runs out
                timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine(questions[nQuestion - 1]);
                
                // set the answers to the questions so they can be used for a wrong response or for times up
                if (nQuestion == 1)
                {
                    sAnswer = "The answer is: black";
                }
                else if (nQuestion == 2)
                {
                    sAnswer = "The answer is: 42";
                }
                else
                {
                    sAnswer = "The answer is: What do you mean? African or European swallow?";
                }

                // START TIMER
                timeOutTimer.Start();

                // read the user's answer
                userAnswer = Console.ReadLine();

                // stop the timer once they've answered
                timeOutTimer.Stop();

                // if the timer didn't run out check whether the answer is right or wrong
                if (!bTimeOut)
                {
                    if (userAnswer == sAnswer)
                    {
                        Console.WriteLine("Well Done!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong!  " + sAnswer);
                    }
                }
                 
                
                while (!bValid)
                {
                    Console.Write("Play again? ");
                    sPlayAgain = Console.ReadLine();
                    Console.WriteLine();
                    if (sPlayAgain.StartsWith("y"))
                    {
                        bPlayAgain = true;
                        bValid = true;
                    }
                    else if (sPlayAgain.StartsWith("n"))
                    {
                        bPlayAgain = false;
                        bValid = true;
                    }
                    else
                    {
                        bValid = false;
                    }
                }
            }

        }

        // handles if the time runs out
        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            // send a newline to the console to interrupt the user entry
            Console.WriteLine();

            // let the user know their time is up
            Console.WriteLine("Time's Up!");
            Console.WriteLine(sAnswer);
            Console.WriteLine("Please press enter.");

            // set the time out flag
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();
        }
    }
}
