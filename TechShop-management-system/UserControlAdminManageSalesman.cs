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
    public partial class UserControlAdminManageSalesman : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlAdminManageSalesman()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void populateGridView(string sql ="select * from UserInformation where role='salesman'") {
            try
            {
                var ds = this.Da.ExecuteQuery(sql);
                this.dvgSalesman.AutoGenerateColumns = false;
                this.dvgSalesman.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("from Grid view error" + exc.Message);
            }

        }

        private void UserControlAdminManageSalesman_Load(object sender, EventArgs e)
        {
            try
            {
                populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }

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
                    MessageBox.Show("Data ubsertion failed");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("from add error" + exc.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update UserInformation set userName ='"+this.txtName.Text+"', password ='"+this.txtPassword.Text+"', DOB='"+this.dtpDOB.Text+"',address='"+this.txtAddress.Text+"',phoneNo='"+this.txtPhone.Text+"',email='"+this.txtEmail.Text+"',salary="+this.txtSalary.Text+" ,role='salesman' where userId='"+this.txtID.Text+"';";
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Data Updated suceesfully");
                }
                else
                    MessageBox.Show("Data upgradation failed");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("from edit error" + exc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.dvgSalesman.CurrentRow.Cells[0].Value.ToString();
                var name = this.dvgSalesman.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from UserInformation where userId ='" + id + "';";

                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show(name + " has been deleted successfully.");
                }
                else
                    MessageBox.Show("Data deletion failed.");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error from delete" + exc.Message);
            }
        }

        private void dvgSalesman_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = this.dvgSalesman.CurrentRow.Cells["userId"].Value.ToString();
            this.txtName.Text = this.dvgSalesman.CurrentRow.Cells["userName"].Value.ToString();
            this.txtPassword.Text = this.dvgSalesman.CurrentRow.Cells["password"].Value.ToString();
            this.dtpDOB.Text = this.dvgSalesman.CurrentRow.Cells["DOB"].Value.ToString();
            this.txtAddress.Text = this.dvgSalesman.CurrentRow.Cells["address"].Value.ToString();
            this.txtPhone.Text = this.dvgSalesman.CurrentRow.Cells["phoneNo"].Value.ToString();
            this.txtEmail.Text = this.dvgSalesman.CurrentRow.Cells["email"].Value.ToString();
            this.txtSalary.Text = this.dvgSalesman.CurrentRow.Cells["salary"].Value.ToString();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }
        private void ClearContent() {
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
