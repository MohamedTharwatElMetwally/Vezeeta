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
    public partial class PatientForm2_buyMedicine_ : Form
    {
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        public string email;
        public string id_;
        DataTable dt;

        public PatientForm2_buyMedicine_()
        {
            InitializeComponent();

        }

        private void PatientForm2_buyMedicine__Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            dt = new DataTable();


            dt.Columns.Add("Medicine Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Available Quantity");
            dataGridView1.DataSource = dt;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select medicine_name_,cost_,available_quantity_ from medicine_";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();

            txt_patientID.Text = id_;

        }


        private void buy_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from cart_ where patient_id_=:id_ And medicine_name_=:medicinename";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id_", txt_patientID.Text);
            cmd.Parameters.Add("medicinename", txt_Medicine.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Already in Your Cart !!");
            }
            else
            {
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into cart_ values(:pid,:midName)";
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("pid", txt_patientID.Text);
                cmd2.Parameters.Add("midName", txt_Medicine.Text);

                int r = cmd2.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Added to Cart !!");
                }
            }
            dr.Close();


            

        }

        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            PatientForm1 form1 = new PatientForm1();
            form1.email = email;
            form1.Show();
        }
        private void PatientForm2_buyMedicine__FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
