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
            webBrowser1.Navigate(new Uri(toURL(comboBox1.SelectedItem.ToString())));
            
            comboBox1.Items[comboBox1.SelectedIndex] = toURL(comboBox1.SelectedItem.ToString());
            String a = comboBox1.Items[comboBox1.SelectedIndex].ToString();
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
        private String toURL(String keyword)
        {
            if (keyword.IndexOf(".") == -1)
            {
                keyword = "http://www.google.com/search?q=" + keyword;
            }
            else if (keyword.IndexOf("http:") == -1)
            {
                keyword = "http://" + keyword;
            }
   
            return keyword;
        }
    }
}
