using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WorkshopSushiCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Calculate all the things! http://api.wolframalpha.com/v2/query?input=female%20population%20Belgium&appid=99LE3A-EG946R2RTA for example
            XDocument xml = XDocument.Load("http://api.wolframalpha.com/v2/query?input=female%20population%20Belgium&appid=99LE3A-EG946R2RTA");
            XElement test = xml.Element("queryresult");
            var values = xml.Descendants("queryresult").Where(i => i.Element("pod").Value == "Input interpretation").Where(f => f.Element("subpod").Value == "");



            this.Hide();
            Form2 f2 = new Form2(textBox1.Text, "placeholder");
            f2.Show();
        }
    }
}
