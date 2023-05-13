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
    public partial class PatientForm4_viewBookinList_ : Form
    {

        string constr = "data source=orcl; user id=scott; password=scott;";
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public string email;
        public string id_;
        

        public PatientForm4_viewBookinList_()
        {
            InitializeComponent();
        }

        private void PatientForm4_viewBookinList__Load(object sender, EventArgs e)
        {
            string cmdstr = "select * from Booking_ where patient_id_=:id_";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id_", id_);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            txt_patientID.Text = id_;

        }


        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            PatientForm1 form1 = new PatientForm1();
            form1.email = email;
            form1.Show();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            int index = -1;
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                if(ds.Tables[0].Rows[i][0].ToString()==txt_patientID.Text&& ds.Tables[0].Rows[i][1].ToString() == txt_doctorID.Text)
                {
                    index = i;
                    break;
                }
            }
            if(index==-1)
            {
                MessageBox.Show("Booking Not Found !!");
            }
            else
            {
                ds.Tables[0].Rows[index].Delete();
                MessageBox.Show("Deleted Successfully !!");


            }

            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }
    }
}
