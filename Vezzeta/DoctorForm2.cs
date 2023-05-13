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
    public partial class DoctorForm2 : Form
    {
        public string email;
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;

        public DoctorForm2()
        {
            InitializeComponent();
        }

        private void DoctorForm2_Load(object sender, EventArgs e)
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
            cmd2.CommandText = "select * from Doctor_ where doctor_id_=:id";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id", txt_ID.Text);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                txt_Name.Text = dr2[1].ToString();
                txt_Phone.Text = dr2[2].ToString();
                txt_Specialization.Text = dr2[3].ToString();
                txt_StartTime.Text = dr2[4].ToString();
                txt_EndTime.Text = dr2[5].ToString();
                txt_Location.Text = dr2[6].ToString();
                txt_Weekend.Text = dr2[7].ToString();
                txt_Cost.Text = dr2[8].ToString();
            }
            dr2.Close();

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
            txt_Location.Text = "";
            txt_Phone.Text = "";
            txt_Specialization.Text = "";
            txt_StartTime.Text = "";
            txt_EndTime.Text = "";
            txt_Weekend.Text = "";
            txt_Cost.Text = "";
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            
           
                
            
            if(email==txt_Email.Text)
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
                cmd3.CommandText = "update Doctor_ set doctor_name_=:name_, phone_number_=:phone_, department_=:depart_, work_start_time_=:start_, work_end_time_=:end_, address_=:address_, weekend_=:weekend_, examination_cost_=:cost_ where doctor_id_=:id_";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("name_", txt_Name.Text);
                cmd3.Parameters.Add("phone_", txt_Phone.Text);
                cmd3.Parameters.Add("depart_", txt_Specialization.Text);
                cmd3.Parameters.Add("start_", txt_StartTime.Text);
                cmd3.Parameters.Add("end_", txt_EndTime.Text);
                cmd3.Parameters.Add("address_", txt_Location.Text);
                cmd3.Parameters.Add("weekend_", txt_Weekend.Text);
                cmd3.Parameters.Add("cost_", txt_Cost.Text);
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
                    cmd3.CommandText = "update Doctor_ set doctor_name_=:name_, phone_number_=:phone_, department_=:depart_, work_start_time_=:start_, work_end_time_=:end_, address_=:address_, weekend_=:weekend_, examination_cost_=:cost_ where doctor_id_=:id_";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("name_", txt_Name.Text);
                    cmd3.Parameters.Add("phone_", txt_Phone.Text);
                    cmd3.Parameters.Add("depart_", txt_Specialization.Text);
                    cmd3.Parameters.Add("start_", txt_StartTime.Text);
                    cmd3.Parameters.Add("end_", txt_EndTime.Text);
                    cmd3.Parameters.Add("address_", txt_Location.Text);
                    cmd3.Parameters.Add("weekend_", txt_Weekend.Text);
                    cmd3.Parameters.Add("cost_", txt_Cost.Text);
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

        private void Back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            DoctorForm1 form1 = new DoctorForm1();
            form1.email = email;
            form1.Show();
        }

        private void DoctorForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

    }
}
