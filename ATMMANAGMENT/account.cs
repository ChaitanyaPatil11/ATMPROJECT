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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void account_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");       
        private void button1_Click(object sender, EventArgs e)
        {

            int bal = 0;
            if (ACCNUMTB.Text == "" || NAMETB.Text == "" || FNAMETB.Text == "" ||
                ADDRESSTB.Text == "" || PHONETB.Text == "" || OCCUPATIONTB.Text == "" || PINNUMBERTB.Text
                == "") 
            {
                MessageBox.Show("Mising Information !!");
            }
            else 
            {
                try {
                    con.Open();
                    String query = "insert into ACCTable1 values('" +ACCNUMTB.Text+ "','" +NAMETB.Text+ "','" +
                        FNAMETB.Text + "','" + ADDRESSTB.Text + "','" + PHONETB.Text + "','" + OCCUPATIONTB.Text + "','" +PINNUMBERTB.Text + "','" + DobTB.Value.Date + "'," + bal + ")";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Account Created Sucessfully");
                    con.Close();
                    Login log = new Login();  
                    log.Show();
                    this.Hide();    
                }
                catch (Exception ex) 
                { 
                         MessageBox.Show(ex.Message);
                }                 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NAMETB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
