using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);
            this.webBrowser1.Navigate("C:\\Users\\kathe\\source\\repos\\katie-b9030\\myIGME-201\\PE20\\example.html");


        }
        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            // Question 8
            htmlElementCollection = webBrowser1.Document.GetElementsByTagName("h1");
            htmlElement = htmlElementCollection[0];
            htmlElement.InnerText = "My UFO Page";

            // Question 9
            htmlElementCollection = webBrowser1.Document.GetElementsByTagName("h2");
            htmlElement = htmlElementCollection[0];
            htmlElement.InnerText = "My UFO Info";

            // Question 10
            htmlElementCollection = webBrowser1.Document.GetElementsByTagName("h2");
            htmlElement = htmlElementCollection[1];
            htmlElement.InnerText = "My UFO Pictures";

            // Question 11
            htmlElementCollection = webBrowser1.Document.GetElementsByTagName("h2");
            htmlElement = htmlElementCollection[2];
            htmlElement.InnerText = "";

            // Question 12
            htmlElement = webBrowser1.Document.Body;
            htmlElement.Style = "font-family: sans-serif; color: #880808";

            // Question 13
            htmlElementCollection = webBrowser1.Document.GetElementsByTagName("p");
            htmlElement = htmlElementCollection[0];
            htmlElement.InnerText = "Report your UFO sightings here: ";
            htmlElement.InnerHtml += "<a href='http://www.nuforc.org'>http://www.nuforc.org</a>";
            htmlElement.Style = "color: green; font-weight: bold; font-size: 2em; text-transform: uppercase; text-shadow: 3px 2px #A44";

            // Question 14
            htmlElement = htmlElementCollection[1];
            htmlElement.InnerText = "";

            // Question 15
            htmlElement = htmlElementCollection[2];
            HtmlElement image = webBrowser1.Document.CreateElement("img");
            image.SetAttribute("src", "https://www.politico.com/dims4/default/6c48ad2/2147483647/strip/true/crop/2382x1621+0+0/resize/1290x878!/quality/90/?url=https%3A%2F%2Fstatic.politico.com%2F69%2Fb2%2Fce58b21248ec9ef761087e5352ab%2Fufos-investigation-62696.jpg");
            image.SetAttribute("alt", "UFO");
            htmlElement.AppendChild(image);

            // Question 16
            htmlElement = webBrowser1.Document.Body;
            htmlElement.InnerHtml += "<footer>&copy;2023 Katie Bogart</footer>";
        }

    }
}
