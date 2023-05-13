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
    public partial class DoctorForm3 : Form
    {

        string constr = "data source=orcl; user id=scott; password=scott;";
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public string email;
        public string id_;

        public DoctorForm3()
        {
            InitializeComponent();
        }

        private void DoctorForm3_Load(object sender, EventArgs e)
        {
            string cmdstr = "select * from Booking_ where doctor_id_=:id_";// where doctor_id=:id_
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id_", id_);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


       
        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            DoctorForm1 form1 = new DoctorForm1();
            form1.email = email;
            form1.Show();
        } 
        
    }
}
