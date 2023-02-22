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
    public partial class deposit : Form
    {
        public deposit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      

         

        
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");
        String Acc = Login.AccNum;
        private void adTransaction()

        {
            String tr = "Deposited";

            try
            {
                con.Open();
                String query = "insert into TRANSACTIONTBL values('" + Acc + "','" + tr + "'," + DepoAmtTb.Text + ", '" + DateTime.Today.Date.ToString() + "')";

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (DepoAmtTb.Text == "" || Convert.ToInt32(DepoAmtTb.Text) <= 0)
            {
                MessageBox.Show(" Enter the Amount you want to deposit");

            }
            else
            { 
                newBal = oldBallbl + Convert.ToInt32(DepoAmtTb.Text);
                try 
                {
                    con.Open();
                    String query = "Update ACCTable1 set Balance =" + newBal + "where ACCNUM = '" + Acc + "'";
                    SqlCommand cmd =new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("deposited sucessfully !!");

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
        }

        private void DepoAmtTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
                
        }

        int oldBallbl,newBal;
        private void getbalance()
        {

            con.Open();

            SqlDataAdapter dbt = new SqlDataAdapter("select Balance from ACCTable1 where ACCNUM ='" + Acc + "'", con);
            DataTable db = new DataTable();
            dbt.Fill(db);
            oldBallbl = Convert.ToInt32(db.Rows[0][0].ToString());
            con.Close();
        }
        private void deposit_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
