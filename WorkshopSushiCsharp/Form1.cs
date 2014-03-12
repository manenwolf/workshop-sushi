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

        private void button1_Click(object sender, EventArgs e)
        {
            int eco = economy.Value;
            int health = healthcare.Value;
            int pop = popdens.Value;
            int fait = Religion.Value;

            int afwijking = 20 ;
            bool found = false;



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
