using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceFromHell
{
    public partial class Form2 : Form
    {
        Form child;
        Form parent;
        Thread thread;
        Random rand = new Random();
        public Form2(Form parent)
        {
            InitializeComponent();

            this.parent = parent;
            moveOnButton.Click += new EventHandler(MoveOnButton__Click);
            moveOnButton.Enabled = false;
            moveOnButton.Visible = false;
            pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/Solid_red.png";

            foreach (RadioButton rb in piGroupBox.Controls)
            {
                rb.Click += new EventHandler(RadioButton__Click);
            }
            correctButton.Click += new EventHandler(CorrectButton__Click);
            richTextBox1.KeyPress += new KeyPressEventHandler(RichTextBox1__KeyPress);
            this.FormClosing += new FormClosingEventHandler(Form2__FormClosing);

            thread = new Thread(UpdateImage);
            thread.Start();
        }

        private void UpdateImage()
        {
            while (true)
            {
                Thread.Sleep(rand.Next(1000, 10000));
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/Solid_blue.png";
                Thread.Sleep(200);
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/Solid_red.png";
            }
        }

        private void MoveOnButton__Click(object sender, EventArgs e)
        {
            this.child = new Form3(this);
            child.Show();
        }

        private void RadioButton__Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            foreach (RadioButton rb in piGroupBox.Controls)
            {
                rb.Checked = false;
            }

            if (radioButton == radioButton1)
            {
                radioButton4.Checked = true;
            }
            else if (radioButton == radioButton2)
            {
                radioButton1.Checked = true;
            }
            else if (radioButton == radioButton3)
            {
                radioButton5.Checked = true;
            }
            else if (radioButton == radioButton4)
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }

        private void CorrectButton__Click(object sender, EventArgs e)
        {
            thread.Abort();

            radioButton2.Checked = true;
            richTextBox1.Text = "Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal.";

            moveOnButton.Enabled = true;
            moveOnButton.Visible = true;

            pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/Solid_blue.png";
        }

        private void RichTextBox1__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a' || e.KeyChar == 'e' || e.KeyChar == 'i' || e.KeyChar == 'o' || e.KeyChar == 'u')
            {
                e.Handled = true;
            }
        }

        private void Form2__FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
        }
    }
}
