using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMMANAGMENT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public static String AccNum;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlDataAdapter dta = new SqlDataAdapter("Select Count(*) from ACCTable1 where ACCNUM='"+accountnumTb.Text +"' and PINNUMBER = "+accpinTB.Text+ "",con);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1" )
            {

                AccNum = accountnumTb.Text;
                Home home = new Home();
                home.Show();
                this.Hide();
                con.Close();

            }
            else
            {
                MessageBox.Show("Wrong Pin Enter !!!");
            
            }
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            account ac = new account();
            this.Hide();
            ac.Show();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
