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
    public partial class form : Form
    {

        public static string nama, alamat, telp, pay;
        string st;
        SqlConnection sc;

        private void form_Load(object sender, EventArgs e)
        {
            try
            {
                st = string.Format("Data Source=LAPTOP-B3L7IVID\\SQLEXPRESS;Initial Catalog=Cafe;Integrated Security=True");
                sc = new SqlConnection(st);
                sc.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public form()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb1 = new StringBuilder();
                sb1.Clear();
                sb1.AppendFormat("Insert into cust values('{0}', '{1}', '{2}')", textBox1.Text, textBox2.Text, textBox3.Text);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sc;
                cmd.CommandText = sb1.ToString();
                sc.Open();
                cmd.ExecuteNonQuery();

                sc.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            nama = textBox1.Text;
            alamat = textBox2.Text;
            telp = textBox3.Text;
            pay = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (nama == "" || alamat == "" || telp == "" || pay == "")
                MessageBox.Show("Please enter all your data", " Fill the form", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                checkout checkout = new checkout();
                checkout.Show();
                this.Close();
            }
        }
    }
}
