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
    public partial class LoginForm : Form
    {
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        


        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }


        private void login_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_type_ from Users_ where email_=:mail And password_=:pass";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("mail", txt_Email.Text);
            cmd.Parameters.Add("pass", txt_Password.Text);

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string user_type = dr[0].ToString();
                if(user_type=="doctor")
                {
                    this.Hide();
                    DoctorForm1 form1 = new DoctorForm1();
                    form1.email = txt_Email.Text;
                    form1.Show();
                }
                else if(user_type=="admin")
                {
                    this.Hide();
                    AdminForm1 form1 = new AdminForm1();
                    form1.email = txt_Email.Text;
                    form1.Show();
                }
                else if(user_type=="patient")
                {
                    this.Hide();
                    PatientForm1 form1 = new PatientForm1();
                    form1.email = txt_Email.Text;
                    form1.Show();
                }
            }
            dr.Close();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm form = new SignUpForm();
            form.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void aSDOCTORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm_Doctor_ form = new SignUpForm_Doctor_();
            form.Show();
  
        }

        private void aSPATIENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm_Patient_ form = new SignUpForm_Patient_();
            form.Show();
        }

        private void aSADMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm_Admin_ form = new SignUpForm_Admin_();
            form.Show();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorForm1 form = new DoctorForm1();
            form.Show();
        }

        private void vIEWREQUESTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorForm3 form = new DoctorForm3();
            form.Show();
        }

        private void viewInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorForm2 form = new DoctorForm2();
            form.Show();
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm1 form = new AdminForm1();
            form.Show();
        }

        private void manageVezeetaPharmacyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm2_Medicines_ form = new AdminForm2_Medicines_();
            form.Show();
        }

        private void viewInformationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm3_Info_ form = new AdminForm3_Info_();
            form.Show();
        }

        private void bUYMEDICINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm2_buyMedicine_ form = new PatientForm2_buyMedicine_();
            form.Show();
        }

        private void buyMedicineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm2_buyMedicine_ form = new PatientForm2_buyMedicine_();
            form.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm3_Booking_ form = new PatientForm3_Booking_();
            form.Show();
        }

        private void viewBookingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm4_viewBookinList_ form = new PatientForm4_viewBookinList_();
            form.Show();
        }

        private void viewInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm5_viewInfo_ form = new PatientForm5_viewInfo_();
            form.Show();
        }

        private void sIGNUPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm form = new SignUpForm();
            form.Show();
        }

        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
