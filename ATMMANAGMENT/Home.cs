using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMMANAGMENT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        public static String AccNum;

        private void Home_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "ACCOUNT NUMBER : " + Login.AccNum;
            AccNum = Login.AccNum;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           Login hm= new Login();
            hm.Show();
            this.Hide();
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            
            this.Hide();
            bal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deposit depo = new deposit();
            depo.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Changepin cpn = new Changepin();
            cpn.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdrawl wdr = new Withdrawl();
            wdr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MiniStatement mst = new MiniStatement();
            mst.Show();
            this.Hide();
        }
    }
}
