using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Milestone_2
{
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cbxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShow.Checked == true)
            {
                tbxPassword1.UseSystemPasswordChar = false;
                tbxPassword2.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPassword1.UseSystemPasswordChar = true;
                tbxPassword2.UseSystemPasswordChar = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Student_Data form1 = new Student_Data();
            form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogInForm form1 = new LogInForm();
            form1.Show();
            this.Close();
        }
    }
}
