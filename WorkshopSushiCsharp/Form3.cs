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
    public partial class Form3 : Form
    {
        String joke;
        public Form3(String j)
        {
            InitializeComponent();
            joke = j;
            label1.Text = joke;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://api.wolframalpha.com/v2/query?input=Tell+me+a+joke&appid=99LE3A-EG946R2RTA";
            XDocument xml = XDocument.Load(url);
            var lv1s = from lv1 in xml.Descendants("pod")
                       where (lv1.Attribute("title").Value == "Result")
                       select lv1.Descendants("subpod").Descendants("plaintext").ElementAt(0).Value;

            label1.Text = (lv1s.ToList<string>().ElementAt(0));
        }
    }
}
