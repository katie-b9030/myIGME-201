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
    /* Class: Form1
     * Author: Katie Bogart
     * Purpose: intake high and low values and create/run the guessing game
     * Restrictions: None
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            startButton.Click += new EventHandler(StartButton__Click);
            lowTextBox.KeyPress += new KeyPressEventHandler(LowTextBox__KeyPress);
            highTextBox.KeyPress += new KeyPressEventHandler(HighTextBox__KeyPress);
        }

        /* Method: StartButton__Click
         * Purpose: parse the low and high numbers
         *          check if the range is valid
         *          if not, display that it's invalid
         *          if it is
         *              create a new game form with the given high and low vals
         *              disable this form while the other is active
         * Restrictions: None
         */
        private void StartButton__Click(object sender, EventArgs e)
        {
            bool bConv;
            int lowNumber = 0;
            int highNumber = 0;

            // convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse
            lowNumber = Int32.Parse(lowTextBox.Text);
            highNumber = Int32.Parse(highTextBox.Text);

            // if not a valid range
            if (highNumber <= lowNumber)
            {
                // show a dialog that the numbers are not valid
                MessageBox.Show("The high number must be greater than the low number!");
            }
            else
            {
                // otherwise we're good
                // create a form object of the second form 
                // passing in the number range
                GameForm gameForm = new GameForm(lowNumber, highNumber);

                // display the form as a modal dialog, 
                // which makes the first form inactive
                // ShowDialog() creates the form as a Modal dialog 
                // which disables the parent form while the Modal dialog is active
                gameForm.ShowDialog();
            }

        }

        /* Method: LowTextBox__KeyPress
         * Purpose: check if entered value is a digit
         *          if not, display a message
         * Restrictions: None
         */
        private void LowTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Please enter a digit!");
            }
        }

        /* Method: HighTextBox__KeyPress
         * Purpose: check if entered value is a digit
         *          if not, display a message
         * Restrictions: None
         */
        private void HighTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Please enter a digit!");
            }
        }
    }
}