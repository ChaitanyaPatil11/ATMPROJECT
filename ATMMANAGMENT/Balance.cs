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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home hm= new Home();
            this.Hide();
            hm.Show();
        }

        private void ACCNUMLBL_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void getbalance() {

            con.Open();

            SqlDataAdapter dbt = new SqlDataAdapter("select Balance from ACCTable1 where ACCNUM ='" + ACCNUMLBL.Text + "'", con);
            DataTable db = new DataTable();
            dbt.Fill(db);
            Ballbl.Text = " RS  "+db.Rows[0][0].ToString();
            con.Close();
        }
        
        private void Balance_Load(object sender, EventArgs e)
        {
            ACCNUMLBL.Text = Home.AccNum;
            getbalance();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
