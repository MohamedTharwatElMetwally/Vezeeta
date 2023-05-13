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
    public partial class AdminForm3_Info_ : Form
    {
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        public string email;
        public string id_;

        public AdminForm3_Info_()
        {
            InitializeComponent();
        }

        private void AdminForm3_Info__Load(object sender, EventArgs e)
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
            cmd2.CommandText = "select admin_name_ from Adminstrator_ where admin_id_=:id_";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id_", txt_ID.Text);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                txt_Name.Text = dr2[0].ToString();
            }
            dr2.Close();
        }

        private void AdminForm3_Info__FormClosed(object sender, FormClosedEventArgs e)
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
                cmd3.CommandText = "update Adminstrator_ set admin_name_=:name_ where admin_id_=:id_";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("name_", txt_Name.Text);
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
                    cmd3.CommandText = "update Adminstrator_ set admin_name_=:name_ where admin_id_=:id_";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("name_", txt_Name.Text);
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

        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            AdminForm1 form1 = new AdminForm1();
            form1.email = email;
            form1.Show();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
        }
    }
}
