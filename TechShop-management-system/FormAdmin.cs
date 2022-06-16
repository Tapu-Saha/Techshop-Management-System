using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Login_and_Registration_GUI
{
   
public partial class FormAdmin : MetroForm {


    private Login Fl { get; set; }
    public FormAdmin()
        {
            InitializeComponent();
            UserControlAdminDashboard ucl = new UserControlAdminDashboard();
            this.metroPanel3.Controls.Add(ucl);
        }
    public FormAdmin(Login fl, string info ,string Role) : this()
        {
            //InitializeComponent();
            this.Fl = fl;
            this.lblName.Text = info;
            this.lblRole.Text = Role;

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlAdminDashboard ucl = new UserControlAdminDashboard();
            this.metroPanel3.Controls.Add(ucl);
        }


        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            session.destroy();
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnManageSalesman_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlAdminManageSalesman uclSalesman = new UserControlAdminManageSalesman();
            this.metroPanel3.Controls.Add(uclSalesman);
        }

        private void btnManageManager_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlManageManager uclManager = new UserControlManageManager();
            this.metroPanel3.Controls.Add(uclManager);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlEditProfile uclProfile = new UserControlEditProfile();
            this.metroPanel3.Controls.Add(uclProfile);

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

            this.lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            if (DateTime.Now.ToUniversalTime().AddHours(8).AddMinutes(30).Hour < 5)
            {
                lblGreeting.Text = "Good Night";
            }
            else if (DateTime.Now.ToUniversalTime().AddHours(5).AddMinutes(30).Hour < 12)
            {
                lblGreeting.Text = "Good Morning";
            }
            else if (DateTime.Now.ToUniversalTime().AddHours(5).AddMinutes(30).Hour < 17)
            {
                lblGreeting.Text = "Good Afternoon";
            }
            else
            {
                lblGreeting.Text = "Good Evening";
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlAddBonus uclAddBonusManager = new UserControlAddBonus();
            this.metroPanel3.Controls.Add(uclAddBonusManager);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlApproveReg uclApproveReg = new UserControlApproveReg();
            this.metroPanel3.Controls.Add(uclApproveReg);

        }
        private void Logout()
        {
            session.destroy();
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
    }
