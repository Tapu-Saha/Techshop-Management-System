using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_and_Registration_GUI
{
    public partial class ManageSalesman : UserControl
    {
        private DataAccess Da { get; set; }
        public ManageSalesman()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
            public void populateGridView(string sql= "select * from UserInformation where role='salesman';")
        {
            var ds = this.Da.ExecuteQuery(sql);
            this.dgvmanager.AutoGenerateColumns = false;
            this.dgvmanager.DataSource = ds.Tables[0];
        }

        private void Msalesmane_Load(object sender, EventArgs e)
        {
            populateGridView();
        }

        private void dgvmanager_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = this.dgvmanager.CurrentRow.Cells["userId"].Value.ToString();
            this.txtName.Text = this.dgvmanager.CurrentRow.Cells["userName"].Value.ToString();
            this.txtPassword.Text = this.dgvmanager.CurrentRow.Cells["password"].Value.ToString();
            this.dtpDOB.Text = this.dgvmanager.CurrentRow.Cells["DOB"].Value.ToString();
            this.txtAddress.Text = this.dgvmanager.CurrentRow.Cells["address"].Value.ToString();
            this.txtPhone.Text = this.dgvmanager.CurrentRow.Cells["phoneNo"].Value.ToString();
            this.txtEmail.Text = this.dgvmanager.CurrentRow.Cells["email"].Value.ToString();
            this.txtSalary.Text = this.dgvmanager.CurrentRow.Cells["salary"].Value.ToString();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtID.Text) || string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtPassword.Text) || string.IsNullOrEmpty(this.dtpDOB.Text) || string.IsNullOrEmpty(this.txtAddress.Text) || string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtSalary.Text))
            {
                MessageBox.Show("Please fill-up all information");
                return;
            }
            try
            {
                string sql = "insert into UserInformation values('" + this.txtID.Text + "','" + this.txtName.Text + "','" + this.txtPassword.Text + "','" + this.dtpDOB.Text + "','" + this.txtAddress.Text + "','" + this.txtPhone.Text + "','" + this.txtEmail.Text + "'," + int.Parse(this.txtSalary.Text) + ",0," + int.Parse(this.txtSalary.Text) + ",'salesman');";
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Inserted suceesfully");
                }
                else
                    MessageBox.Show("Data insertion failed");
                populateGridView();
            }
            catch (Exception expc)
            {
                MessageBox.Show(expc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.dgvmanager.CurrentRow.Cells[0].Value.ToString();
                var sql = "delete from UserInformation where userId='" + id + "'";
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Deleted suceesfully");
                }
                else
                    MessageBox.Show(" failed");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("from add error" + exc.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            string sql = @"update UserInformation set userName ='" + this.txtName.Text + "', " +
                "password ='" + this.txtPassword.Text + "', DOB='" + this.dtpDOB.Text + "',address=" +
                "'" + this.txtAddress.Text + "',phoneNo='" + this.txtPhone.Text + "',email='" + 
                this.txtEmail.Text + "',salary=" + this.txtSalary.Text + " ,role='salesman' where u" +
                "serId='" + this.txtID.Text + "';";
            int count = this.Da.ExecuteDMLQuery(sql);
            if (count == 1)
            {
                MessageBox.Show("Data Updated suceesfully");
            }
            else
                MessageBox.Show("Data upgradation failed");
            this.populateGridView();
        }
        private void clearContent() {
            this.txtID.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtPassword.Clear();
            this.txtAddress.Clear();
            this.txtPhone.Clear();
            this.txtEmail.Clear();
            this.txtSalary.Clear();
            this.txtID.Clear();

        }
    }
}
