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
    public partial class EditProfile : UserControl
    {
        private DataAccess Da { get; set; }
        public EditProfile()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            string userID = session.userid;
        }

        private void UserControlSalesmanEditProfile_Load(object sender, EventArgs e)
        {

            try
            {
                string sql = "select * from UserInformation where userId='" + session.userid + "' and role ='"+ session.role + "';";
                var ds = this.Da.ExecuteQuery(sql);



                this.txtID.Text = ds.Tables[0].Rows[0][0].ToString();
                this.txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                this.txtPassword.Text = ds.Tables[0].Rows[0][2].ToString();
                this.dtpDOB.Text = ds.Tables[0].Rows[0][3].ToString();
                this.txtAddress.Text = ds.Tables[0].Rows[0][4].ToString();
                this.txtPhone.Text = ds.Tables[0].Rows[0][5].ToString();
                this.txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update UserInformation set userName ='" + this.txtName.Text + "', password ='" + this.txtPassword.Text + "', DOB='" + this.dtpDOB.Text + "',address='" + this.txtAddress.Text + "',phoneNo='" + this.txtPhone.Text + "',email='" + this.txtEmail.Text + "',salary= 0 ,role='"+ session.role + "' where userId='" + this.txtID.Text + "';";
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Data Updated suceesfully");
                }
                else
                    MessageBox.Show("Data upgradation failed");
            }
            catch (Exception exc)
            {
                MessageBox.Show("from edit error" + exc.Message);
            }
        }
    }
}
