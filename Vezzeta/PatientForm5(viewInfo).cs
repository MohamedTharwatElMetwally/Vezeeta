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
    public partial class PatientForm5_viewInfo_ : Form
    {
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        public string email;

        public PatientForm5_viewInfo_()
        {
            InitializeComponent();
        }

        private void PatientForm5_viewInfo__Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            OracleCommand cmd2 = new OracleCommand();

            cmd.Connection = conn;
            cmd.CommandText = "select * from Users_ where email_=:email";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_ID.Text = dr[0].ToString();
                txt_Email.Text = dr[1].ToString();
                txt_Password.Text = dr[2].ToString();
            }
            dr.Close();


            cmd2.Connection = conn;
            cmd2.CommandText = "select * from Patient_ where patient_id_=:id";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id", txt_ID.Text);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                txt_Name.Text = dr2[1].ToString();
                txt_Phone.Text = dr2[2].ToString();
                txt_HealthStatus.Text= dr2[3].ToString();
            }
            dr2.Close();
        }

        private void PatientForm5_viewInfo__FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (email == txt_Email.Text)
            {
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "update Users_ set email_=:email_,password_=:password_ where user_id_=:id_";
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("email_", txt_Email.Text);
                cmd2.Parameters.Add("password_", txt_Password.Text);
                cmd2.Parameters.Add("id_", txt_ID.Text);


                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "update Patient_ set patient_name_=:name_, phone_number_=:phone_, information_=:info_ where patient_id_=:id_";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("name_", txt_Name.Text);
                cmd3.Parameters.Add("phone_", txt_Phone.Text);
                cmd3.Parameters.Add("info_", txt_HealthStatus.Text);
                cmd3.Parameters.Add("id_", txt_ID.Text);

                int r1 = cmd2.ExecuteNonQuery();
                int r2 = cmd3.ExecuteNonQuery();

                if (r1 != -1 && r2 != -1)
                {
                    MessageBox.Show("Updated Successfully !!");
                }

            }
            else
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select user_id_ from Users_ where email_=:email_";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("email_", txt_Email.Text);

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("This email already exist !!");
                }
                else
                {
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "update Users_ set email_=:email_,password_=:password_ where user_id_=:id_";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("email_", txt_Email.Text);
                    cmd2.Parameters.Add("password_", txt_Password.Text);
                    cmd2.Parameters.Add("id_", txt_ID.Text);


                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = "update Patient_ set patient_name_=:name_, phone_number_=:phone_, information_=:info_ where patient_id_=:id_";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("name_", txt_Name.Text);
                    cmd3.Parameters.Add("phone_", txt_Phone.Text);
                    cmd3.Parameters.Add("info_", txt_HealthStatus.Text);
                    cmd3.Parameters.Add("id_", txt_ID.Text);

                    int r1 = cmd2.ExecuteNonQuery();
                    int r2 = cmd3.ExecuteNonQuery();

                    if (r1 != -1 && r2 != -1)
                    {
                        MessageBox.Show("Updated Successfully !!");
                    }

                }
                dr.Close();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
            txt_Phone.Text = "";
            txt_HealthStatus.Text = "";
        }

        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            PatientForm1 form1 = new PatientForm1();
            form1.email = email;
            form1.Show();
        }
    }
}
