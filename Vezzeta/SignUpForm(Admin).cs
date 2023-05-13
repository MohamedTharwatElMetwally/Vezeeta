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
    public partial class SignUpForm_Admin_ : Form
    {
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        

        public SignUpForm_Admin_()
        {
            InitializeComponent();
        }

        private void SignUpForm_Admin__Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            //get Max UserID from the Users table
            int maxID, newID;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetMaxUserID_";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                maxID = Convert.ToInt32(cmd.Parameters["id"].Value.ToString());
                newID = maxID + 1;
                txt_ID.Text = newID.ToString();
            }
            catch
            {
                newID = 1;
            }
        }

  
       
        private void register_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_type_ from Users_ where email_=:mail";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("mail", txt_Email.Text);

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("This email already exist !!");
            }
            else
            {
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into Users_ values(:id_,:email_,:password_,'admin')";
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("id_", txt_ID.Text);
                cmd2.Parameters.Add("email_", txt_Email.Text);
                cmd2.Parameters.Add("password_", txt_Password.Text);


                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "insert into Adminstrator_ values(:id_, :name_)";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("id_", txt_ID.Text);
                cmd3.Parameters.Add("name_", txt_Name.Text);

                int r1 = cmd2.ExecuteNonQuery();
                int r2 = cmd3.ExecuteNonQuery();

                if (r1 != -1 && r2 != -1)
                {
                    MessageBox.Show("New Admin is added");
                }



                this.Close();
                AdminForm1 form1 = new AdminForm1();
                form1.email = txt_Email.Text;
                form1.Show();





            }
            dr.Close();


        }

        private void SignUpForm_Admin__FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void backClick(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            SignUpForm form1 = new SignUpForm();
            form1.Show();
        }

        private void exitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
