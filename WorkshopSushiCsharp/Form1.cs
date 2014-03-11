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
            // http://api.wolframalpha.com/v2/query?input=Belgium&appid=99LE3A-EG946R2RTA
            XDocument xml = XDocument.Load("http://api.wolframalpha.com/v2/query?input=Belgium&appid=99LE3A-EG946R2RTA");
            XElement test = xml.Element("queryresult");
            //var values = xml.Descendants("queryresult").Where(i => i.Element("pod").Value == "Input interpretation").Where(f => f.Element("subpod").Value == "");
            var lv1s = from lv1 in xml.Descendants("pod")
                       where (lv1.Attribute("title").Value == "Demographics")
                       select lv1.Descendants("subpod").Descendants("plaintext").ElementAt(0).Value;

            label3.Text = lv1s.ToList<string>().ElementAt(0);
            // zomg, text is showin up


          //  this.Hide();
            Form2 f2 = new Form2(textBox1.Text, "placeholder");
            f2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            switch (trackBar5.Value)
            {
                case 0:
                    label11.Text = "Doesn't matter";
                    break;
                case 1:
                    label11.Text = "Christianity";
                    break;
                case 2:
                    label11.Text = "Islam";
                    break;
                case 3:
                    label11.Text = "Judaism";
                    break;
                case 4:
                    label11.Text = "Buddhism";
                    break;
                default:
                    break;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label13.Text = trackBar3.Value + " C";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar2.Value + " people/km^2";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
