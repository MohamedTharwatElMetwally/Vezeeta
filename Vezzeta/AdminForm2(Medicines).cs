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
    public partial class AdminForm2_Medicines_ : Form
    {
        string constr = "data source=orcl; user id=scott; password=scott;";
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public string email;
        public string id_;


        public AdminForm2_Medicines_()
        {
            InitializeComponent();
        }

        private void AdminForm2_Medicines__Load(object sender, EventArgs e)
        {
            string cmdstr = "select * from medicine_ where admin_id_=:id_";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id_", id_);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            txt_adminID.Text = id_;
        }

        private void insert_Click(object sender, EventArgs e)
        {
            int index = -1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][0].ToString() == txt_adminID.Text && ds.Tables[0].Rows[i][1].ToString() == txt_midicine.Text)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                ds.Tables[0].Rows.Add(txt_adminID.Text, txt_midicine.Text, txt_quantity.Text, txt_cost.Text);
                MessageBox.Show("Insert Successfully !!");
            }
            else
            {
                MessageBox.Show("Already Exist !!");
            }

            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = -1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][0].ToString() == txt_adminID.Text && ds.Tables[0].Rows[i][1].ToString() == txt_midicine.Text)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                MessageBox.Show("Medicine Not Exist !!");
            }
            else
            {
                ds.Tables[0].Rows[index].Delete();
                MessageBox.Show("Deleted Successfully !!");
            }

            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void back_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            AdminForm1 form1 = new AdminForm1();
            form1.email = email;
            form1.Show();
        }
    }
}
