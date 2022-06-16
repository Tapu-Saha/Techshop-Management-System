using System;
using System.Globalization;
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
    public partial class FormSalesman : MetroForm
    {
        private DataAccess Da { get; set; }
        private Login Fl { get; set; }
        public FormSalesman()
        {
            InitializeComponent();
            this.Da = new DataAccess();

        }
        public FormSalesman(Login fl, string info,string Role) : this()
        {
            this.Fl = fl;
            this.lblName.Text = info;
            this.lblRole.Text = Role;
        }

        private void FormSalesman_Load(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            if (DateTime.Now.ToUniversalTime().AddHours(5).AddMinutes(30).Hour < 12)
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
            this.metroPanel3.Controls.Clear();
            UserControlRecentOrder uclRecentOrder = new UserControlRecentOrder();
            this.metroPanel3.Controls.Add(uclRecentOrder);
        }

        private void FormSalesman_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logout();
        }

        private void btnOrderTaking_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlOrder uclOrder = new UserControlOrder();
            this.metroPanel3.Controls.Add(uclOrder);
        }

       

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlRecentOrder uclRecentOrder = new UserControlRecentOrder();
            this.metroPanel3.Controls.Add(uclRecentOrder);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            EditProfile uclEditProfile = new EditProfile();
            this.metroPanel3.Controls.Add(uclEditProfile);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.metroPanel3.Controls.Clear();
            UserControlViewCustomer uclCustomers = new UserControlViewCustomer();
            this.metroPanel3.Controls.Add(uclCustomers);
        }
        private void Logout() {
            session.destroy();
            this.Hide();
            Login login = new Login();
            login.Show();
            string sql = "delete from Cart";
            this.Da.ExecuteDMLQuery(sql);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
