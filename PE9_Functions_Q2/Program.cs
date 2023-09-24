using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PE9_Functions_Q2
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: gives the user 5 seconds to answer each Math Quiz question
     * Restrictions: None
     */
    static internal class Program
    {
        static Timer timeOutTimer;
        static bool bTimeOut = false;

        /* Method: Main
         * Purpose: ask the user how many questions they want to play
         *          ask what difficulty they want to play
         *          randomly select the operation
         *          give them 5 seconds to answer a question
         *          if the answer is right, increment the # correct
         *          print the number of correct answers
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // store user name
            string myName = "";

            // string and int of # of questions
            string sQuestions = "";
            int nQuestions = 0;

            // string and base value related to difficulty
            string sDifficulty = "";
            int nMaxRange = 0;

            // constant for setting difficulty with 1 variable
            const int MAX_BASE = 10;

            // question and # correct counters
            int nCntr = 0;
            int nCorrect = 0;

            // operator picker
            int nOp = 0;

            // operands and solution
            int val1 = 0;
            int val2 = 0;
            int nAnswer = 0;

            // string and int for the response
            string sResponse = "";
            Int32 nResponse = 0;

            // play again?
            string sAgain = "";

            // valid state
            bool bValid = false;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // seed the random number generator
            Random rand = new Random();

            Console.WriteLine("Math Quiz!");
            Console.WriteLine();

            // fetch the user's name into myName
            while (true)
            {
                Console.Write("What is your name-> ");
                myName = Console.ReadLine();

                if (myName.Length > 0)
                {
                    break;
                }
            }

        // label to return to if they want to play again
        start:

            // initialize correct responses for each time around
            nCorrect = 0;

            Console.WriteLine();

            // ask how many questions until they enter a valid number
            do
            {
                Console.Write("How many questions-> ");
                sQuestions = Console.ReadLine();
                //bValid = int.TryParse(sQuestions, out nQuestions);
            } while (!int.TryParse(sQuestions, out nQuestions));
            //} while ( !bValid );

            Console.WriteLine();

            // ask difficulty level until they enter a valid response
            do
            {
                Console.Write("Difficulty level (easy, medium, hard)-> ");
                sDifficulty = Console.ReadLine();
                sDifficulty = sDifficulty.ToLower().Trim();
            } while (sDifficulty != "easy" &&
                    sDifficulty != "medium" &&
                    sDifficulty != "hard"
                    );

            Console.WriteLine();

            // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
            // if they choose medium, set nMaxRange = MAX_BASE * 2
            // if they choose hard, set nMaxRange = MAX_BASE * 3
            switch (sDifficulty)
            {
                case "easy":
                    nMaxRange = MAX_BASE;

                    if (myName.ToLower() == "david")
                    {
                        goto case "hard";
                    }
                    break;

                case "medium":
                case "med":
                    nMaxRange = MAX_BASE * 2;
                    break;

                case "hard":
                    nMaxRange = MAX_BASE * 3;
                    break;
            }

            // ask each question
            for (nCntr = 1; nCntr <= nQuestions; nCntr++)
            {

                // generate a random number between 0 inclusive and 3 exclusive to get the operation
                nOp = rand.Next(0, 3);

                val1 = rand.Next(0, nMaxRange) + nMaxRange;
                val2 = rand.Next(0, nMaxRange);

                // if either argument is 0, pick new numbers
                if (val1 == 0 || val2 == 0)
                {
                    --nCntr;
                    continue;
                }


                switch (nOp)
                {
                    case 0:
                        nAnswer = val1 + val2;
                        sQuestions = $"Question #{nCntr + 1}: {val1 + " (this first value is really hard)"} + {val2} ==> {val1 + val2} ";
                        sQuestions = "Question #" + (nCntr + 1) + ": " + val1 + " + " + val2 + " ==> " + (val1 + val2) + " ";
                        break;
                    case 1:
                        nAnswer = val1 - val2;
                        sQuestions = $"Question #{nCntr + 1}: {val1} - {val2} ==> ";
                        break;
                    case 2:
                        nAnswer = val1 * val2;
                        sQuestions = $"Question #{nCntr + 1}: {val1} * {val2} ==> ";
                        break;
                }

                // if nOp == 0, then addition
                if (nOp == 0)
                {
                    nAnswer = val1 + val2;
                    sQuestions = $"Question #{nCntr}: {val1} + {val2} ==> ";
                }
                // if nOp == 1, then subtraction
                else if (nOp == 1)
                {
                    nAnswer = val1 - val2;
                    sQuestions = $"Question #{nCntr}: {val1} - {val2} ==> ";
                }
                // else multiplication
                else
                {
                    nAnswer = val1 * val2;
                    sQuestions = $"Question #{nCntr}: {val1} * {val2} ==> ";
                }

                bValid = false;
                timeOutTimer = new Timer(5000);

                // Timer calls the Timer.Elapsed event handler when the time elapses
                // The Timer.Elapsed event handler uses a delegate function with the following signature:
                //        public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
                // This delegate method type is already defined for us by .NET
                timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

                    // start the timer just before the user is prompted for the answer
                    // the timer process will be a second process running at the same time as this program
                    // it will countdown from the value initialized in line #48 and call the delegate method(s)
                    // associated with the Elapsed event handler as set in line #59
                timeOutTimer.Start();

                // display the question and prompt for the answer until they enter a valid number
                do
                {
                    Console.WriteLine(sQuestions);

                    sResponse = Console.ReadLine();

                    // always stop the timer directly after the Console.ReadLine()
                    // otherwise the timer will keep running even if the user entered the correct answer in time
                    // and the TimesUp() method will be called
                    timeOutTimer.Stop();

                    // can use either TryParse
                    bValid = int.TryParse(sResponse, out nResponse);

                    if (!bValid)
                    {
                        Console.WriteLine("Please enter an integer");
                        timeOutTimer.Stop();
                    }


                    // or try/catch with Parse() or Convert.ToInt32()
                    try
                    {
                        nResponse = int.Parse(sResponse);
                        nResponse = Convert.ToInt32(sResponse);
                        bValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter an integer");
                        bValid = false;
                    }
                } while (!bValid);

                // if response == answer, output flashy reward and increment # correct
                if (nResponse == nAnswer && !bTimeOut)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Well done, {0}!!", myName);
                    nCorrect ++;
                }
                // else output stark answer
                else if (!bTimeOut)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, nAnswer);
                }



                // restore the screen colors
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();


            }

            Console.WriteLine();

            // output how many they got correct and their score


            Console.WriteLine("You entered " + nCorrect + " correct answers. Your score is " + nCorrect + "/" + (nCntr - 1));

            do
            {
                // prompt if they want to play again
                Console.Write("Do you want to play again? ");

                sAgain = Console.ReadLine();

                // if they type y or yes then play again
                // else if they type n or no then leave this loop
                if (sAgain.ToLower().Trim().StartsWith("y"))
                {
                    goto start;
                }
                else
                {
                    break;
                }
            } while (true);

        }

        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            // send a newline to the console to interrupt the user entry
            Console.WriteLine();

            // let the user know their time is up
            Console.WriteLine("You ran out of time!");
            Console.WriteLine("Please press Enter.");

            // set the time out flag
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();
        }
    }
}
