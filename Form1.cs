using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            //Url
            //Commit1
            string url = "";
            if(comboBox1.Text != null)
            {
                url = comboBox1.Text;
            }
            else if(comboBox1.SelectedItem.ToString() != null)
            {
                url=comboBox1.SelectedItem.ToString();
                
            }
            if (!url.Contains("."))
            {
                url = "http://www.google.com/search?q=" + url;
            }
            else
            {
                url = "http://" + url;
            }
            webBrowser1.Navigate(new Uri(url));
            
            comboBox1.Text = url;
            Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

    }
}
