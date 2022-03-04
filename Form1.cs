using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb
{
    public partial class Form1 : Form
    {
        List<Url> urlList = new List<Url>();
        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            dataGridView1.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void readFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while(sr.Peek() != -1)
            {
                Url aux = new Url();
                aux.Resource = sr.ReadLine();
                aux.TimesVisited = Convert.ToInt32(sr.ReadLine());
                aux.Date = Convert.ToDateTime(sr.ReadLine());
                urlList.Add(aux);
            }
            sr.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            readFile("Historial.txt");
            //Escribir url en combobox
            foreach(Url url in urlList)
            {
                comboBox1.Items.Add(url.Resource);
                
            }
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            string url = "";
            if(comboBox1.Text != null)
            {
                url = comboBox1.Text;
            }
            else if(comboBox1.SelectedItem.ToString() != null)
            {
                url = comboBox1.SelectedItem.ToString();
                
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
            bool isRegisted = false;
            foreach(var aux in urlList)
            {
                if (aux.Resource.Contains(url)) 
                {
                    aux.TimesVisited++;
                    aux.Date = DateTime.Now;
                    isRegisted = true;
                }      

            }
            //Escribir lista actualizada en historial de nuevo
            if (!isRegisted)
            {
                Url aux = new Url();
                comboBox1.Items.Add(url);
                aux.Resource = url;
                aux.TimesVisited++;
                aux.Date = DateTime.Now;
                urlList.Add(aux);
            }   
            
            saveFile("Historial.txt");
            comboBox1.Text = url;
        }
        private void saveFile(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);
            foreach(var url in urlList)
            {
                foreach (string s in url.getUrlData())
                {
                    sw.WriteLine(s);
                }
            }
            sw.Close();
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

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = urlList;
        }

        private void ordenAscendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urlList.OrderByDescending(url => url.Date).ToList();
        }

        private void másVisitadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urlList.OrderBy(url => url.TimesVisited).ToList();
        }
    }
}
