using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresidentsApp
{
    public partial class Form1 : Form
    {
        private RadioButton[] presidentButtons;
        private Dictionary<TextBox, string> presidentNums;
        private ToolTip toolTip;

        public Form1()
        {
            InitializeComponent();

            presidentButtons = new RadioButton[] {harrisonRadioButton, fdrRadioButton, clintonRadioButton, buchananRadioButton, pierceRadioButton, bushRadioButton, obamaRadioButton, kennedyRadioButton, mckinleyRadioButton, reaganRadioButton, eisenhowerRadioButton, vanburenRadioButton, washingtonRadioButton, adamsRadioButton, rooseveltRadioButton, jeffersonRadioButton};
            presidentNums = new Dictionary<TextBox, string>() { { textBox1, "23"}, { textBox2, "32" }, { textBox3, "42" }, { textBox4, "15" }, { textBox5, "14" }, { textBox6, "43" }, { textBox7, "44" }, { textBox8, "35" }, { textBox9, "25" }, { textBox10, "40" }, { textBox11, "34" }, { textBox12, "8" }, { textBox13, "1" }, { textBox14, "2" }, { textBox15, "26" }, { textBox16, "3" }};
            toolTip = new ToolTip();

            //all text box vals set to 0
            //text box keypress event handler
            //text box hover event handler
            //text box leave event handler
            foreach (TextBox tb in presidentNums.Keys)
            {
                tb.Text = "0";
                tb.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);
                tb.MouseHover += new EventHandler(TextBox__MouseHover);
                tb.Leave += new EventHandler(TextBox__Leave);
            }
            //exit button disabled
            exitButton.Enabled = false;
            //benjamin harrison checked(other president radio buttons unchecked)
            harrisonRadioButton.Checked = true;
            //filter "all" checked(other filters unchecked)
            allRadioButton.Checked = true;
            //progress bar max = 240
            //progress bar val = 240
            //progress bar step = 1
            toolStripProgressBar1.Maximum = 240;
            toolStripProgressBar1.Value = 240;
            toolStripProgressBar1.Step = 1;
            //timer interval = 500
            timer1.Interval = 500;
            //picturebox shows benjamin harrison image
            pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/BenjaminHarrison.jpeg";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //webbrowser shows benjamin harrison wikipedia
            this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Benjamin_Harrison");
            this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Benjamin_Harrison";
            //error icon not visible
            pictureBox2.Visible = false;

            //president radio button click event handler
            foreach (RadioButton rb in presidentButtons)
            {
                rb.Click += new EventHandler(PresidentButton__Click);
            }
            //webbrowser document completed event handler
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);
            //filter radio button click event handler
            foreach (RadioButton rb in filterGroupBox.Controls)
            {
                rb.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);
            }
            //exit button click event handler
            exitButton.Click += new EventHandler(ExitButton__Click);
            //timer tick event handler
            timer1.Tick += new EventHandler(Timer1__Tick);
            //error icon hover event handler
            pictureBox2.MouseEnter += new EventHandler(PictureBox2__MouseEnter);
            pictureBox2.MouseLeave += new EventHandler(PictureBox2__MouseLeave);
            //image hover event handler
            pictureBox1.MouseEnter += new EventHandler(PictureBox1__MouseEnter);
            pictureBox1.MouseLeave += new EventHandler(PictureBox1__MouseLeave);
        }

        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (timer not started)
            if (!timer1.Enabled)
            {
            //    start the timer
                timer1.Start();
            }

            //if (typed in not digit or backspace)
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
            //    character is handled(put nothing in the box)
                e.Handled = true;
            }
        }

        private void TextBox__MouseHover(object sender, EventArgs e)
        {
            //display ?what #
            toolTip.Show("What # President?", this, MousePosition.X+10, MousePosition.Y+10);
        }

        private void TextBox__Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            pictureBox2.Visible = false;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
            //if (text box value has not 0 and is incorrect)
            else if (textBox.Text != "0" && textBox.Text != presidentNums[textBox])
            {
            //    show error icon
                pictureBox2.Location = new Point(textBox.Location.X+31, textBox.Location.Y);
                pictureBox2.Visible = true;
            }
            //else if (all text box values are correct)
            else
            {
                foreach(TextBox tb in presidentNums.Keys)
                {
                    if (tb.Text == "0")
                    {
                        return;
                    }
                }
                //    stop timer
                timer1.Stop();
                //    change webbrowser to fireworks gif
                webBrowser1.Navigate("https://media.giphy.com/media/TmT51OyQLFD7a/giphy.gif");
                exitButton.Enabled = true;
            }
        }

        private void PresidentButton__Click(object sender, EventArgs e)
        {
            //change webbrowser to clicked president's wikipedia
            //change groupbox text to wikipedia link
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton == harrisonRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/BenjaminHarrison.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Benjamin_Harrison");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Benjamin_Harrison";
            }
            else if (radioButton == fdrRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/FranklinDRoosevelt.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Franklin_D_Roosevelt");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Franklin_D_Roosevelt";
            }
            else if (radioButton == clintonRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/WilliamJClinton.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/William_J_Clinton");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/William_J_Clinton";
            }
            else if (radioButton == buchananRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/JamesBuchanan.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/James_Buchanan");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/James_Buchanan";
            }
            else if (radioButton == pierceRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/FranklinPierce.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Franklin_Pierce");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Franklin_Pierce";
            }
            else if (radioButton == bushRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/GeorgeWBush.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/George_W_Bush");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/George_W_Bush";
            }
            else if (radioButton == obamaRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/BarackObama.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Barack_Obama");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Barack_Obama";
            }
            else if (radioButton == kennedyRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/JohnFKennedy.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/John_F_Kennedy");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/John_F_Kennedy";
            }
            else if (radioButton == mckinleyRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/WilliamMcKinley.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/William_McKinley");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/William_McKinley";
            }
            else if (radioButton == reaganRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/RonaldReagan.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Ronald_Reagan");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Ronald_Reagan";
            }
            else if (radioButton == eisenhowerRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/DwightDEisenhower.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Dwight_D_Eisenhower");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Dwight_D_Eisenhower";
            }
            else if (radioButton == vanburenRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/MartinVanBuren.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Martin_VanBuren");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Martin_VanBuren";
            }
            else if (radioButton == washingtonRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/GeorgeWashington.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/George_Washington");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/George_Washington";
            }
            else if (radioButton == adamsRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/JohnAdams.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/John_Adams");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/John_Adams";
            }
            else if (radioButton == rooseveltRadioButton)
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/TheodoreRoosevelt.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Theodore_Roosevelt");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Theodore_Roosevelt";
            }
            else
            {
                pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/ThomasJefferson.jpeg";
                this.webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/Thomas_Jefferson");
                this.webbrowserGroupBox.Text = "https://en.m.wikipedia.org/wiki/Thomas_Jefferson";
            }
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //get array of anchor tags
            WebBrowser wb = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection = wb.Document.GetElementsByTagName("a");
            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                //    link hover event handler
                htmlElement.MouseEnter += new HtmlElementEventHandler(HtmlElement__MouseEnter);
                htmlElement.MouseLeave += new HtmlElementEventHandler(HtmlElement__MouseLeave);
            }
        }

        private void FilterRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selected = (RadioButton)sender;
            foreach (RadioButton rb in presidentButtons)
            {
                rb.Visible = false;
                rb.Enabled = false;
            }
            //if (all)
            if (selected == allRadioButton)
            { 
            //    show all president buttons
                foreach (RadioButton rb in presidentButtons)
                {
                    rb.Visible = true;
                    rb.Enabled = true;
                }
            }
            //else if (Democrat)
            else if (selected == democratRadioButton)
            {
                //    show only democrat butons
                fdrRadioButton.Visible = true;
                fdrRadioButton.Enabled = true;
                clintonRadioButton.Visible = true;
                clintonRadioButton.Enabled = true;
                buchananRadioButton.Visible = true;
                buchananRadioButton.Enabled = true;
                pierceRadioButton.Visible = true;
                pierceRadioButton.Enabled = true;
                obamaRadioButton.Visible = true;
                obamaRadioButton.Enabled = true;
                kennedyRadioButton.Visible = true;
                kennedyRadioButton.Enabled = true;
                vanburenRadioButton.Visible = true;
                vanburenRadioButton.Enabled = true;
            }
            //else if (Republican)
            else if (selected == republicanRadioButton)
            {
                //    show only republican buttons
                harrisonRadioButton.Visible = true;
                harrisonRadioButton.Enabled = true;
                bushRadioButton.Visible = true;
                bushRadioButton.Enabled = true;
                mckinleyRadioButton.Visible = true;
                mckinleyRadioButton.Enabled = true;
                reaganRadioButton.Visible = true;
                reaganRadioButton.Enabled = true;
                eisenhowerRadioButton.Visible = true;
                eisenhowerRadioButton.Enabled = true;
                rooseveltRadioButton.Visible = true;
                rooseveltRadioButton.Enabled = true;
            }
            //else if (Democratic - Republican)
            else if (selected == drRadioButton)
            {
            //    show only democratic - republican buttons
                jeffersonRadioButton.Visible = true;
                jeffersonRadioButton.Enabled = true;
            }
            else
            {
            //    show only federalist buttons
                washingtonRadioButton.Visible = true;
                washingtonRadioButton.Enabled = true;
                adamsRadioButton.Visible = true;
                adamsRadioButton.Enabled = true;
            }
        }

        private void HtmlElement__MouseEnter(object sender, HtmlElementEventArgs e)
        {
            //display message "Professor Schuch for President!"
            HtmlElement link = (HtmlElement)sender;
            toolTip.Show("Professor Schuch for President!", this, MousePosition.X, MousePosition.Y);
        }

        private void HtmlElement__MouseLeave(object sender, HtmlElementEventArgs e)
        {
            //stop displaying message "Professor Schuch for President!"
            toolTip.Hide(this);
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            //close application
            System.Windows.Forms.Application.Exit();
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {
            //if (timer is at 0)
            if (toolStripProgressBar1.Value == 0)
            {
                //    stop timer
                timer1.Stop();
                //    reset all text box vals to 0
                foreach (TextBox tb in presidentNums.Keys)
                {
                    tb.Text = "0";
                }
                //    set progress bar value to 240
                toolStripProgressBar1.Value = 240;
            }

            else
            {
            //    decrease progress bar
                toolStripProgressBar1.Value--;
            }
        }

        private void PictureBox1__MouseEnter(object sender, EventArgs e)
        {
            //make image bigger
            pictureBox1.Size = new Size(231, 283);
        }

        private void PictureBox1__MouseLeave(object sender, EventArgs e)
        {
            //make image smaller
            pictureBox1.Size = new Size(154, 189);
        }

        private void PictureBox2__MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox2.Visible)
            {
                toolTip.Show("That is the wrong number", this, MousePosition.X, MousePosition.Y);
            }
        }

        private void PictureBox2__MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox2.Visible)
            {
                toolTip.Hide(this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //leave empty, created on click by accident
        }
    }
}
