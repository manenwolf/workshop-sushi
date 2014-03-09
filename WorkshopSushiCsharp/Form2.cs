using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
