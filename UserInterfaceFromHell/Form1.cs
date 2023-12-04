using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceFromHell
{
    public partial class Form1 : Form
    {
        int continueCount = 0;
        Random random = new Random();
        Form child;

        public Form1()
        {
            InitializeComponent();

            exitButton.Click += new EventHandler(ExitButton__Click);
            continueButton.Click += new EventHandler(ContinueButton__Click);
            urlTextBox.KeyPress += new KeyPressEventHandler(UrlTextBox__KeyPress);
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            //exit application
            Application.Exit();
        }

        private void ContinueButton__Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(urlTextBox.Text))
            {
                for (int i = 0; i < random.Next(1, 11); i++)
                {
                    MessageBox.Show("What are you doing? Put something in the text box!");
                }
            }
            else if (continueCount >= 3)
            {
                //open next form
                this.child = new Form2(this);
                child.Show();
            }
            //open a variety of "can't do that" message boxes
            else if (continueCount == 0)
            {
                for (int i = 0; i < random.Next(1, 11); i ++)
                {
                    MessageBox.Show("You can't do that");
                }
                continueCount++;
            }
            else if (continueCount == 1)
            {
                for (int i = 0; i < random.Next(1, 11); i++)
                {
                    MessageBox.Show("I told you you can't do that");
                }
                continueCount++;
            }
            else
            {
                for (int i = 0; i < random.Next(1, 11); i++)
                {
                    MessageBox.Show("YOU REALLY CAN'T DO THAT");
                }
                continueCount++;
            }
        }

        private void UrlTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            //check for spaces so that it's valid
            //also don't let them use the backspace key, they have to exit and start over
            if (e.KeyChar == ' ' || e.KeyChar == '\t' || e.KeyChar == '\b')
            {
                e.Handled = true;
                for (int i = 0; i < random.Next(1, 11); i++)
                {
                    MessageBox.Show("Nuh uh");
                }
            }
        }
    }
}
