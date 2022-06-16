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
using MetroFramework.Forms;

namespace Login_and_Registration_GUI
{
    public partial class Login : MetroForm
    {
        private DataAccess Da { get; set; }

        public Login()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string getId = this.txtUserID.Text;
            string getPassword = this.txtPassword.Text;
            if (string.IsNullOrEmpty(getId) )
            {
                MessageBox.Show("Please Enter UserID");
                return;
            }
            else if (string.IsNullOrEmpty(getPassword))
            {
                MessageBox.Show("Please Enter Password");
                return;
            }
            try
            {
                string sql = "select * from UserInformation where userId='" + this.txtUserID.Text + "' and password='" + this.txtPassword.Text + "';";
                var ds = this.Da.ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //this.txtUserID.Text= "";        // this.ClearContent(); not working
                    //this.txtPassword.Text = "";     // this.ClearContent(); not working
                    this.Hide();
                    string name = ds.Tables[0].Rows[0][1].ToString();
                    string role = ds.Tables[0].Rows[0][10].ToString();
                    if (role == "admin")
                    {
                        session.userid = ds.Tables[0].Rows[0][0].ToString();
                        session.username = ds.Tables[0].Rows[0][1].ToString();
                        session.role = "admin";
                        FormAdmin admin = new FormAdmin(this, name, role);
                        this.Hide();

                        admin.Show();
                    }
                    else if (role == "manager")
                    {
                        session.userid = ds.Tables[0].Rows[0][0].ToString();
                        session.username = ds.Tables[0].Rows[0][1].ToString();
                        session.role = "manager";
                        FormManager manager = new FormManager(this, name);
                        this.Hide();
                        manager.Show();
                    }
                    else if (role == "salesman")
                    {
                        session.userid = ds.Tables[0].Rows[0][0].ToString();
                        session.username = ds.Tables[0].Rows[0][1].ToString();
                        session.role = "salesman";
                        FormSalesman salesman = new FormSalesman(this, name,role);
                        this.Hide();
                        salesman.Show();
                    }

                    
                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("User Invalid!");
                    Application.Exit();

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistration reg = new FormRegistration();
            reg.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserID.Text="";
             this.txtPassword.Text="";
        }

        private void CheckbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckbxShowPassword.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = true;
            }
            else if(! this.CheckbxShowPassword.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false ;
            }
        }
    }
}
