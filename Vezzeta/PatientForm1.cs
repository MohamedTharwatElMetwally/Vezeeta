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
    public partial class PatientForm1 : Form
    {

        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        public string email;
        public string id;

        public PatientForm1()
        {
            InitializeComponent();
        }

        private void PatientForm1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void buyMedicine_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_id_ from Users_ where email_=:email_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email_", email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();



            this.Close();
            PatientForm2_buyMedicine_ form2 = new PatientForm2_buyMedicine_();
            form2.email = email;
            form2.id_ = id;
            form2.Show();
        }

        private void bookExamination_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_id_ from Users_ where email_=:email_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email_", email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();


            this.Close();
            PatientForm3_Booking_ form3 = new PatientForm3_Booking_();
            form3.email = email;
            form3.id_ = id;
            form3.Show();
        }

        private void viewBookingList_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_id_ from Users_ where email_=:email_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email_", email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();


            this.Close();
            PatientForm4_viewBookinList_ form4 = new PatientForm4_viewBookinList_();
            form4.email = email;
            form4.id_ = id;
            form4.Show();
        }

        

        private void viewInfo_Click(object sender, EventArgs e)
        {
            this.Close();
            PatientForm5_viewInfo_ form5 = new PatientForm5_viewInfo_();
            form5.email = email;
            form5.Show();
        }
        
       
      
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  

        private void PatientForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void homeClick(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
