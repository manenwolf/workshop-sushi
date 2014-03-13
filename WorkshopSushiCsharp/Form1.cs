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
        List<string> getcountries(string lijst)
        {
            List<string> countries = new List<string>();
            string land ="";
            for (int i = 0; i < lijst.Length; i++) {
                if (lijst[i] == '|')
                {
                    land = land.Remove(land.Length - 1);
                    
                    
                    countries.Add(land);
                    land = "";
                }
                else if (lijst[i] == '\n')
                {
                    countries.Add(land);
                    land = "";
                }
                else {
                    
                    
                       land += lijst[i];        
                    
                }

            }
            countries.Add(land);
            return countries;

        }

        float getreligion(string data) {
            int numtilde = 0;
            int pos = 0;
            string number = "";
            for (int i = 0; i < data.Length; i++) {
                if (data[i] == '|') {
                    numtilde++;
                    if (numtilde == 2) {
                        pos = i;
                        break;
                    }
                }
            }
            pos++;
            while (true)
            {
                pos++;
                if (data[pos] == '%')
                {
                    break;
                }
                number += data[pos];
                
            }              
            
            return float.Parse(number);  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int eco = economy.Value;
            int health = healthcare.Value;
            int pop = popdens.Value;
            int fait = Religion.Value;

            int afwijking = 80 ;
            bool found = false;



           while (true)
            {
                List<string> countries = new List<string>();
                List<string> countries2 = new List<string>();
                List<string> countries3 = new List<string>();
                List<string> countries4 = new List<string>();
                List<string> countries5 = new List<string>();

                //Calculate all the -things! http://api.wolframalpha.com/v2/query?input=female%20population%20Belgium&appid=99LE3A-EG946R2RTA for example
                string baseUrl1 = "http://api.wolframalpha.com/v2/query?input=country+with+population+density+%3C+" + (pop + afwijking) + "+and+population+density+%3E+" + (pop - afwijking) + "&appid=99LE3A-EG946R2RTA";
                XDocument xml = XDocument.Load(baseUrl1);

                XElement test = xml.Element("queryresult");
                var lv1s = from lv1 in xml.Descendants("pod")
                           where (lv1.Attribute("title").Value == "Result")
                           select lv1.Descendants("subpod").Descendants("plaintext").ElementAt(0).Value;

                label3.Text = lv1s.ToList<string>().ElementAt(0);

                string aaa = lv1s.ToList<string>().ElementAt(0);

                countries = getcountries(lv1s.ToList<string>().ElementAt(0));
                string test5 = "";
                for (int i = 0; i < countries.Count; i++) {
                    test5 += countries[i]; 
                }
                label9.Text = test5;

                float correction = (health / 20 - afwijking / 100);
                if (correction < 0) {
                    correction = 0;
                }
                string baseUrl2 = "http://api.wolframalpha.com/v2/query?input=Country+with+UN+health+index+%3E+"+correction+"&appid=99LE3A-EG946R2RTA";
                xml = XDocument.Load(baseUrl2);
                lv1s = from lv1 in xml.Descendants("pod")
                           where (lv1.Attribute("title").Value == "Result")
                           select lv1.Descendants("subpod").Descendants("plaintext").ElementAt(0).Value;

               string lolz = (lv1s.ToList<string>().ElementAt(0));

                countries2 = getcountries(lv1s.ToList<string>().ElementAt(0));
                test5 = "";
                for (int i = 0; i < countries2.Count; i++)
                {
                    test5 += countries2[i];
                }
                label10.Text = "dkmjlqidfjl" + test5;
                //compare the lists
                foreach (string c1 in countries)
                {
                    foreach (string c2 in countries2)
                    {
                        if (c1.Contains(c2) || c2.Contains(c1))
                        {
                            countries3.Add(c1);
                        }
                    }
                }
                string reli ="";
               switch (Religion.Value)
            {
                case 0:
                    reli = "Doesn't matter";
                    break;
                case 1:
                    reli = "Christianity";
                    break;
                case 2:
                    reli = "Islam";
                    break;
                case 3:
                    reli = "Judaism";
                    break;
                case 4:
                    reli = "Buddhism";
                    break;
                default:
                    break;
            }

               if(reli !="Doesn't matter"){
                for (int i = 0; i < countries3.Count;i++ )
                {
                    string baseUrl3 = "http://api.wolframalpha.com/v2/query?input="+countries3[i]+"+"+reli+"&appid=99LE3A-EG946R2RTA";
                    xml = XDocument.Load(baseUrl3);
                    lv1s = from lv1 in xml.Descendants("pod")
                           where (lv1.Attribute("title").Value == "Basic properties")
                           select lv1.Descendants("subpod").Descendants("plaintext").ElementAt(0).Value;
                    
                    float religieper = getreligion( lv1s.ToList<string>().ElementAt(0));
                    label2.Text = ""+religieper;
                    MessageBox.Show("" + countries3[i] + " " + religieper);
                    if (religieper > 20) {
                        countries4.Add(countries3[i]);
                    }
                }
               }else{
                countries4=countries3;
               }


                if (countries4.Count != 0)
                {
                    label2.Text = "kqkqkqk " + countries4.ElementAt(0) + countries4.Count;
                    found = true;
                }


                    


                label3.Text = test5;
                // zomg, text is showin up
                if (found == true) {

                    break;
                }
                countries = new List<string>();
                countries2 = new List<string>();
                countries3 = new List<string>();
                countries4 = new List<string>();
                countries5 = new List<string>();
                afwijking+=80;
            }

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
            switch (Religion.Value)
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

        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label7.Text = popdens.Value + " people/km^2";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {

        }
    }
}
