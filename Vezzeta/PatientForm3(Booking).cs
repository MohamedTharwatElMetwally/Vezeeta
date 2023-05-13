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
    public partial class PatientForm3_Booking_ : Form
    {

        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        public string email;
        public string id_;
        DataTable dt;

        public PatientForm3_Booking_()
        {
            InitializeComponent();
        }

        private void PatientForm3_Booking__Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select DISTINCT department_ from doctor_";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                departs_comboBox1.Items.Add(dr[0]);
            }
            dr.Close();

            dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Doctor Name");
            dt.Columns.Add("Phone Number");
            dt.Columns.Add("Specialization");
            dt.Columns.Add("Work Start Time");
            dt.Columns.Add("Work End Time");
            dt.Columns.Add("Address");
            dt.Columns.Add("Weekend");
            dt.Columns.Add("Cost");
            dataGridView1.DataSource = dt;

            txt_patientID.Text = id_;

        }

        private void PatientForm3_Booking__FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void book_Click(object sender, EventArgs e)
        {
            string cost = "";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select examination_cost_ from doctor_ where doctor_id_=:id_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id_", txt_patientID.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cost = dr[0].ToString();
            }
            dr.Close();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "insert into booking_ values (:pid , :did ,TO_DATE('2021/05/03 21:02:44', 'yyyy/mm/dd hh24:mi:ss'),:cost)";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("pid", txt_patientID.Text);
            cmd2.Parameters.Add("did", txt_doctorID.Text);
            cmd2.Parameters.Add("cost", cost);
            int r = cmd2.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Booking Done !!");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            PatientForm1 form1 = new PatientForm1();
            form1.email = email;
            form1.Show();
        }

        private void search_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from doctor_ where department_=:dept_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("dept_", departs_comboBox1.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }
            dr.Close();
        }
    }
}
