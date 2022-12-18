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

namespace UAS_PV_20_06
{
    public partial class Form2 : Form
    {
        string st;

        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cafeDataSet1.trans' table. You can move, or remove it, as needed.
            this.transTableAdapter.Fill(this.cafeDataSet1.trans);
            try
            {
                st = string.Format("Data Source=LAPTOP-B3L7IVID\\SQLEXPRESS;Initial Catalog=Cafe;Integrated Security=True");

                SqlConnection sc = new SqlConnection(st);
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("select * from menu");
                SqlDataAdapter sda1 = new SqlDataAdapter(sb1.ToString(), sc);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                dataGridView2.DataSource = dt1;


                sc.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
            SqlConnection sc = null;
            sc = new SqlConnection(st);

            StringBuilder sb1 = new StringBuilder();
            sb1.AppendFormat("update menu set stock = stock + {0} where menu_id = {1} ", textBox7.Text, textBox5.Text);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sc;
            cmd.CommandText = sb1.ToString();
            sc.Open();
            cmd.ExecuteNonQuery();


            sc = new SqlConnection(st);
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from menu");
            SqlDataAdapter sda = new SqlDataAdapter(sb.ToString(), sc);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);


            dataGridView2.DataSource = dt1;


            sc.Close();
            sc = null;
            label7.Text = "Stock berhasil di update";
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void transBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
