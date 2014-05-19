using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class JABrowser : Form
    {
        public JABrowser()
        {
            InitializeComponent();
        }        
        
        private void search_Click(object sender, EventArgs e)
        {
            browser.Navigate(adress.Text);              
        }

        private void home_Click(object sender, EventArgs e)
        {
            browser.Navigate("http://google.com");
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            browser.Refresh();
        }

        private void next_Click(object sender, EventArgs e)
        {
            browser.GoForward();
        }

        private void back_Click(object sender, EventArgs e)
        {
            browser.GoBack();
        }

        private void adress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                browser.Navigate(adress.Text);
            }

            if (e.KeyCode == Keys.F5)
            {
                browser.Refresh();
            }

            if (e.KeyCode == Keys.Home)
            {
                browser.Navigate("http://google.com");
            }
        }

        private void JABrowser_Load(object sender, EventArgs e)
        {
            browser.Navigate("http://google.com");
            WindowState = FormWindowState.Maximized;            
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            adress.Text = browser.Url.ToString();
        }

        private void adress_Click(object sender, EventArgs e)
        {
            adress.SelectionStart = 0;
            adress.SelectionLength = adress.Text.Length;
        }
    }
}
