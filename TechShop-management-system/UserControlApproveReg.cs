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
    public partial class UserControlApproveReg : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlApproveReg()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void populateGridView(string sql = "select * from Registration;") {
            try
            {
                var ds = this.Da.ExecuteQuery(sql);
                this.dgvRegistration.AutoGenerateColumns = false;
                this.dgvRegistration.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }

        private void UserControlApproveReg_Load(object sender, EventArgs e)
        {
            populateGridView();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string UserID = this.dgvRegistration.CurrentRow.Cells["userId"].Value.ToString();
            string UserName = this.dgvRegistration.CurrentRow.Cells["UserName"].Value.ToString();
            string Password = this.dgvRegistration.CurrentRow.Cells["password"].Value.ToString();
            string DOB = this.dgvRegistration.CurrentRow.Cells["DOB"].Value.ToString();
            string Address = this.dgvRegistration.CurrentRow.Cells["address"].Value.ToString();
            string phoneNo = this.dgvRegistration.CurrentRow.Cells["phoneNo"].Value.ToString();
            string Email = this.dgvRegistration.CurrentRow.Cells["email"].Value.ToString();
            string Salary = this.dgvRegistration.CurrentRow.Cells["salary"].Value.ToString();
            string Role = this.dgvRegistration.CurrentRow.Cells["role"].Value.ToString();

            approve(UserID, UserName, Password, DOB, Address, phoneNo, Email, Salary, Role);

        }
        private void approve(string UserID, string UserName, string Password, string DOB, string Address, string phoneNo, string Email, string Salary,string Role) {

            string sql = @"insert into UserInformation values('"+ UserID + "','"+ UserName + "','"+ 
                         Password + "','"+ DOB + "','"+ Address + "','"+ phoneNo + "','"+ Email + "'," +
                         ""+ Salary + ",0,"+ Salary + ",'"+ Role + "');";
            try
            {
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show(UserName + " has been added successfully.");
                    string sql2 = "delete from Registration where userId='" + UserID + "'";
                    this.Da.ExecuteDMLQuery(sql2);
                }
                else
                    MessageBox.Show(UserName+" Declined to register");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error from approve" + exc.Message);
            }
        }

        private void dgvRegistration_DoubleClick(object sender, EventArgs e)
        {
            this.lblName.Text= this.dgvRegistration.CurrentRow.Cells["userName"].Value.ToString();
            this.lblID.Text= this.dgvRegistration.CurrentRow.Cells["userId"].Value.ToString();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            string UserID= this.dgvRegistration.CurrentRow.Cells["userId"].Value.ToString();
            string sql = "delete from Registration where userId='" + UserID + "'";
            this.Da.ExecuteDMLQuery(sql);
            MessageBox.Show("Declined");
            populateGridView();
        }
    }
}
