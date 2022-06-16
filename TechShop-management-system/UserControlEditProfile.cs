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
    public partial class UserControlEditProfile : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlEditProfile()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

       



        private void populateGridView(string sql = "select * from UserInformation where role='admin'")
        {
            try
            {
                var ds = this.Da.ExecuteQuery(sql);
                this.dvgProfile.AutoGenerateColumns = false;
                this.dvgProfile.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("from Grid view error" + exc.Message);
            }

        }
        private void UserControlEditProfile_Load(object sender, EventArgs e)
        {
            try
            {
                populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
            try
            {
                this.txtID.Text = this.dvgProfile.Rows[0].Cells["userId"].Value.ToString();
                this.txtName.Text = this.dvgProfile.Rows[0].Cells["userName"].Value.ToString();
                this.txtPassword.Text = this.dvgProfile.Rows[0].Cells["password"].Value.ToString();
                this.dtpDOB.Text = this.dvgProfile.Rows[0].Cells["DOB"].Value.ToString();
                this.txtAddress.Text = this.dvgProfile.Rows[0].Cells["address"].Value.ToString();
                this.txtPhone.Text = this.dvgProfile.Rows[0].Cells["phoneNo"].Value.ToString();
                this.txtEmail.Text = this.dvgProfile.Rows[0].Cells["email"].Value.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("from load error" + exc.Message);
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update UserInformation set userName ='" + this.txtName.Text + "', password ='" + this.txtPassword.Text + "', DOB='" + this.dtpDOB.Text + "',address='" + this.txtAddress.Text + "',phoneNo='" + this.txtPhone.Text + "',email='" + this.txtEmail.Text + "',salary= 0 ,role='admin' where userId='" + this.txtID.Text + "';";
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
    }
}
