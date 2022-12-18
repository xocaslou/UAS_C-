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
    public partial class checkout : Form
    {
        string st;
        public static DataTable DT1 = new DataTable();
        public static int total = 0, price, totalhrg, id;
        public static string ket;

        public checkout()
        {
            InitializeComponent();
            DT1.Columns.Add("ID", typeof(int));
            DT1.Columns.Add("Items", typeof(string));
            DT1.Columns.Add("Values", typeof(int));
            DT1.Columns.Add("Price", typeof(int));
            DT1.Columns.Add("Total", typeof(int));


            DT1.Clear();
            label3.Text = "Halo, " + form.nama + "!!";

            label9.Text = form.pay;

            if (form.pay == "Virtual Payment")
            {
                label4.Text = "Scan Here to Pay~";
                pictureBox1.Visible = true;
            }
            else if (form.pay == "Bank Payment")
                label4.Text = "\n" + "Bank BCA\n" +
                    "Account Number : 4616461\n" +
                    "a/n MIR Cafe\n" +
                    "\n\n" +
                    "Bank BRI\n" +
                    "Account Number : 312312\n" +
                    "a/n MIR Cafe\n";
            else
                label4.Text = "\n\n\nPlease go to counter to pay!!";
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            try
            {
                st = string.Format("Data Source=LAPTOP-B3L7IVID\\SQLEXPRESS;Initial Catalog=Cafe;Integrated Security=True");
               
                SqlConnection sc = new SqlConnection(st);
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("select * from menu");
                SqlDataAdapter sda1 = new SqlDataAdapter(sb1.ToString(), sc);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["namamenu"].ToString());
                }

                sc.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sc = null;
            sc = new SqlConnection(st);
            sc.Open();

            StringBuilder sb1 = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            if (radioButton1.Checked == false && radioButton2.Checked == false)
                MessageBox.Show("Please fill all the form", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {

                try
                {
                    sb1.Clear();

                    sb1.AppendFormat("insert into trans (total, paymentmethod) values ({0}, '{1}')", label6.Text, label9.Text);
                    cmd.Connection = sc;
                    cmd.CommandText = sb1.ToString();
                    cmd.ExecuteNonQuery();

                    sb1.Clear();

                    sc.Close();
                    sc = null;


                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Thank you for Purchasing. Hope you enjoy the food~", "Thank You", MessageBoxButtons.OK);
                this.Close();

            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sc = new SqlConnection(st);
                sc.Open();
                SqlDataReader sdr = null;

                SqlCommand cmd = new SqlCommand("select stock from menu where namamenu = '" + comboBox1.Text + "'", sc);

                sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    textBox2.Text = (sdr["stock"].ToString());

                }
                sc.Close();
                sc.Open();
                SqlDataReader sdr1 = null;
                SqlCommand cmd1 = new SqlCommand("select menu_id from menu where namamenu = '" + comboBox1.Text + "'", sc);
                sdr1 = cmd1.ExecuteReader();

                while (sdr1.Read())
                {
                    textBox3.Text = (sdr1["menu_id"].ToString());
                }
                sc.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string items = comboBox1.GetItemText(comboBox1.SelectedItem);
            string values = textBox1.Text;

            if (items == "Affogato Esspresso")
                price = 25000;
            else if (items == "Americano")
                price = 15000;
            else if (items == "Blueberry Pancake")
                price = 17000;
            else if (items == "Brown Cheese Caramel Milktea")
                price = 30000;
            else if (items == "Caramel Cookies")
                price = 21000;
            else if (items == "Cookie&Cream Blencchino")
                price = 27000;
            else if (items == "Cranberries Pie")
                price = 23000;
            else if (items == "Earl Grey Roll Cake")
                price = 25000;
            else if (items == "Fudge Brownie")
                price = 20000;
            else if (items == "Machiatto")
                price = 17000;
            else if (items == "Mini Cheesecake")
                price = 17000;
            else if (items == "Mini Strawberry Shortcake")
                price = 20000;
            else if (items == "Sparkle Unicorn Milkshake")
                price = 30000;
            else if (items == "Strawberry Milkshake with Bubble")
                price = 28000;

            if (items == "" || values == "")
                label5.Text = "Please fill all the items";
            else
            {
                DataRow DR = DT1.NewRow();

                total = int.Parse(values) * price;

                DR["ID"] = textBox3.Text;
                DR["Items"] = items;
                DR["Values"] = values;
                DR["Price"] = price;
                DR["Total"] = total;

                DT1.Rows.Add(DR);
                dataGridView1.DataSource = DT1;
                label11.Text = total.ToString(); 
                totalhrg = totalhrg + total;
                label6.Text = totalhrg.ToString();
            }


            SqlConnection sc = null;
            sc = new SqlConnection(st);
            sc.Open();

            StringBuilder sb1 = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            StringBuilder sb2 = new StringBuilder();
            SqlCommand cmd1 = new SqlCommand();


            try
            {
                sb1.Clear();

                sb1.AppendFormat("update menu set stock = stock - {0} where namamenu = '{1}'",
                    textBox1.Text, comboBox1.SelectedItem);
                cmd.Connection = sc;
                cmd.CommandText = sb1.ToString();
                cmd.ExecuteNonQuery();

                sb2.AppendFormat("insert into order_detail (menu_id, jmlbeli, totalharga) values ({0}, {1}, {2})", textBox3.Text, textBox1.Text, label11.Text);
                cmd1.Connection = sc;
                cmd1.CommandText = sb2.ToString();
                cmd1.ExecuteNonQuery();

                sb1.Clear();
                sb2.Clear();

                sc.Close();
                sc = null;


            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
