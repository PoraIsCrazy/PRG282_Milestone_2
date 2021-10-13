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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxName.Text = "Student Name";
            tbxPassword.Text = "Password";
            cbxShow.Checked = false;
            tbxPassword.UseSystemPasswordChar = true;
        }

        private void cbxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShow.Checked == true)
            {
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPassword.UseSystemPasswordChar = true;
            }
        }

        private void lklblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration_Form form2 = new Registration_Form();
            this.Hide();
            form2.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Student_Data form3 = new Student_Data();
            this.Hide();
            form3.ShowDialog();
        }    
    }
}
