using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Vezzeta
{
    public partial class SignUpForm : Form
    {

        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void next_Click(object sender, EventArgs e)
        {
            if(patient_radioButton3.Checked)
            {
                this.Close();
                SignUpForm_Patient_ form = new SignUpForm_Patient_();
                form.Show();
            }
            else if(doctor_radioButton2.Checked)
            {
                this.Close();
                SignUpForm_Doctor_ form = new SignUpForm_Doctor_();
                form.Show();
            }
            else if(admin_radioButton1.Checked)
            {
                this.Close();
                SignUpForm_Admin_ form = new SignUpForm_Admin_();
                form.Show();
            }
        }

        private void SignUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void backClick(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            LoginForm form1 = new LoginForm();
            form1.Show();
        }

        private void exitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
