using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_PV_20_06
{
    public partial class employee : Form
    {


        public employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "mircafe")
            {
                if (textBox2.Text == "123456")
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Wrong Username or Password!! Please try agan.", "Invalid Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                MessageBox.Show("Wrong Username or Password!! Please try agan.", "Invalid Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
