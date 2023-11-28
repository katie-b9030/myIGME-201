using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    /* Class: GameForm
     * Author: Katie Bogart
     * Purpose: run the number guessing game with the given high and low values
     * Restrictions: None
     */
    public partial class GameForm : Form
    {
        public int target;
        public int numGuesses = 0;
        public GameForm(int lowNumber, int highNumber)
        {
            InitializeComponent();

            Random random = new Random();
            int nRandom = random.Next(lowNumber, highNumber + 1);

            target = nRandom;

            timer1.Tick += new EventHandler(Timer1__Tick);
            guessButton.Click += new EventHandler(GuessButton__Click);
            this.AcceptButton = guessButton;

            timer1.Start();
        }

        /* Method: Timer1__Tick
         * Purpose: decrease the progress bar
         *          if the progress bar is 0
         *              stop the timer
         *              show that time is up
         *              close game form
         * Restrictions: None
         */
        private void Timer1__Tick(object sender, EventArgs e)
        {
            this.statusStripProgressBar.Value--;
            if (this.statusStripProgressBar.Value == 0)
            {
                this.timer1.Stop();

                MessageBox.Show("Out of time! The correct answer was " + target + "!");
                this.Close();
            }
        }

        /* Method: GuestButton__Click
         * Purpose: increase numGuesses
         *          intake string guess and parse it to int
         *          if the guess is the target
         *              stop the timer
         *              show that guess was right
         *              close game form
         *          if guess was wrong
         *              display that it was too low/high
         *              clear the guess box
         * Restrictions: None
         */
        private void GuessButton__Click(object sender, EventArgs e)
        {
            numGuesses++;
            string guess = guessTextBox.Text;
            int nGuess = Int32.Parse(guess);
            string message = nGuess + " is too ";

            if (nGuess == target) 
            {
                timer1.Stop();
                MessageBox.Show("Yay! You got the answer in " + numGuesses + " guesses!");
                this.Close();
            }
            else
            {
                if (nGuess > target)
                {
                    message += "high!";
                }
                else
                {
                    message += "low!";
                   }

                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = message;
                guessTextBox.Text = "";
            }
        }
    }
}
