using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATMMANAGMENT
{
    public partial class Changepin : Form
    {
        public Changepin()
        {
            InitializeComponent();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
      
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNum;
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (Pin1TB.Text == "" || ConpinTB.Text == "")
            {
                MessageBox.Show("Enter And Confirm pin ");

            }
            else if (Pin1TB.Text != ConpinTB.Text )
            {
                MessageBox.Show("Both Pin are different  ");
            }
            else
            {
               // newBal = oldBallbl + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    con.Open();
                    String query = "Update ACCTable1 set PINNUMBER =" + Pin1TB.Text + "where ACCNUM = '" + Acc + " ';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Pin added sucessfully !!");

                    con.Close();
                    Login  home = new Login();
                    this.Show();
                    home.Hide();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
           
        
        }
    }
}
