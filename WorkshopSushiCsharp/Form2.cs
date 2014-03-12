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
    public partial class Form2 : Form
    {
        String name;
        public Form2(String userName, String countryName)
        {
            InitializeComponent();
            name = userName;
            label2.Text = "Dear, " + userName;
            label3.Text = countryName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //MessageBox.Show("test");
            Application.Exit();
            base.OnFormClosing(e);
            
        }

        private void jokeButton_Click(object sender, EventArgs e)
        {

            string url = "http://api.wolframalpha.com/v2/query?input=Tell+me+a+joke&appid=99LE3A-EG946R2RTA";
            XDocument xml = XDocument.Load(url);
            var lv1s = from lv1 in xml.Descendants("pod")
                   where (lv1.Attribute("title").Value == "Result")
                   select lv1.Descendants("subpod").Descendants("plaintext").ElementAt(0).Value;

            string joke = (lv1s.ToList<string>().ElementAt(0));

            Form3 f3 = new Form3(joke);
            f3.Show();
        }
    }
}
