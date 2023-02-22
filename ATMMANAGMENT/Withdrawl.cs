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
    public partial class Withdrawl : Form
    {
        public Withdrawl()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNum;
        int bal;
        private void getbalance() {

            con.Open();

            SqlDataAdapter dbt = new SqlDataAdapter("select Balance from ACCTable1 where ACCNUM ='" + Acc + "'", con);
            DataTable db = new DataTable();
            dbt.Fill(db);

            AVAILlbl.Text = " Balance  "+db.Rows[0][0].ToString() +" RS ";
            bal = Convert.ToInt32(db.Rows[0][0].ToString());
            con.Close();
        }
        private void adTransaction()

        {
            String tr = "WITHDRAWL";

            try
            {
                con.Open();
                String query = "insert into TRANSACTIONTBL values('" + Acc + "','" + tr + "'," + WithdrwlTB.Text + ", '" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

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
        private void Withdrawl_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
           
            hm.Show();
            this.Hide
               ();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int newBal;
        private void button1_Click(object sender, EventArgs e)
        {
            if (WithdrwlTB.Text == "")
            {
                MessageBox.Show(" Enter some Amount !! ");

            }
            else if (Convert.ToInt32(WithdrwlTB.Text) <= 0)
            {
                MessageBox.Show("Enter the valid Amount !!");

            }
            else if (Convert.ToInt32(WithdrwlTB.Text) > bal)
            {
                MessageBox.Show("Amount Cannot be Negative !!");

            }
            else 
            {
                try 
                {
                    newBal = bal - Convert.ToInt32(WithdrwlTB.Text);
                    try
                    {
                        con.Open();
                        String query = "Update ACCTable1 set Balance =" + newBal + "where ACCNUM = '" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Withdrwal sucessfully !! ");
                       

                        con.Close();
                        adTransaction();

                        Home hm = new Home();
                        this.Show();
                        hm.Hide();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            
            }

        }
    }
}
