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
    public partial class MiniStatement : Form
    {
        
        public MiniStatement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\Documents\ATMMNGMTDB.mdf;Integrated Security=True;Connect Timeout=30");
        String Acc = Login.AccNum;
        private void populate()
        {
            con.Open();
            string query = " select * from TRANSACTION where AccNum= '" + Acc + "'";
            SqlDataAdapter sdq = new SqlDataAdapter(query, con);
            SqlCommandBuilder sbuild = new SqlCommandBuilder();
            var ds = new DataSet();
            sdq.Fill(ds);
            DataTable dataTable = ds.Tables[0];
       //MINIstspanDGV.DataSource=dataTable;
            con.Close();
        }
        
        private void MiniStatement_Load(object sender, EventArgs e)
        {
            populate();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
