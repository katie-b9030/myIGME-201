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
    public partial class Form3 : Form
    {
        Form parent;

        public Form3(Form parent)
        {
            InitializeComponent();

            this.parent = parent;
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001,
                Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {
            }

            webBrowser1.Navigate("https://www.youtube.com/watch?v=hvL1339luv0");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //created by accident on click, leave empty
        }
    }
}
