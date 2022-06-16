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
    public partial class FormRegistration : Form
    {
        private DataAccess Da { get; set; }
        public FormRegistration()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private string randomUserID()
        {
            Random random = new Random();
            int RandowIDInt = random.Next(1, 1000);
            string RandomIDString = "U-" + RandowIDInt;
            return RandomIDString;
        }
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string UserID=randomUserID();
            string UserName = this.txtUsername.Text;
            string Password = this.txtPassword.Text;
            string DOB = this.dtpDOB.Text;
            string Address = this.txtAddress.Text;
            string ContactNumber = this.txtContactNumber.Text;
            string Email = this.txtEmail.Text;
            if(string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(DOB) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(ContactNumber) || string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Please fill-up all infromation");
                return;
            }
            string RegesterAs;
            if (this.rbManager.Checked)
            {
                RegesterAs = "manager";
                try
                {
                    string sql = "insert into Registration values('" + UserID + "','" + UserName + "','" + Password + "','" + DOB + "','" + Address + "', '" + ContactNumber + "','" + Email + "',80000,0,80000,'manager'); ";
                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Registration suceesful!! Please wait while admin to approve");
                    }
                    else
                        MessageBox.Show("Registration failed");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("from add error" + exc.Message);
                }
            }
            else if (this.rbSalesman.Checked)
            {
                RegesterAs = "salesman";
                try
                {
                    string sql = "insert into Registration values('" + UserID + "','" + UserName + "','" + Password + "','" + DOB + "','" + Address + "', '" + ContactNumber + "','" + Email + "',60000,0,60000,'salesman'); ";
                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Registration suceesful!! Please wait while admin to approve");
                    }
                    else
                        MessageBox.Show("Registration failed");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("from add error" + exc.Message);
                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
               this.txtUsername.Text="";
               this.txtPassword.Text="";
               this.dtpDOB.Text="";
               this.txtAddress.Text="";
               this.txtContactNumber.Text="";
               this.txtEmail.Text="";
               this.rbManager.Checked = false;
               this.rbSalesman.Checked = false;
            }
    }
}
