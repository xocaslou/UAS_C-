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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Ignasia Gladys Princy W. / 202004560006";
            toolStripStatusLabel3.Text = "copyright @atmajaya";
            toolStripStatusLabel4.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cafe MIR merupakan cafe santai yang sangat cocok untuk kalangan muda maupun tua.\n\n" +
             "Berlokasi di Jl. xxx no. xxx.\n" +
             "Jam Operasional : Senin - Sabtu pukul 10.00 - 17.00 WIB", "About Us", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuCafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee employee = new employee();
            employee.Show();
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form form = new form();
            form.Show();
        }
    }
}
