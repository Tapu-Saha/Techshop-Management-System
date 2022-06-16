using System;
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
    public partial class FormManager : MetroForm
    {
        private Login Fl { get; set; }
        public FormManager()
        {
            InitializeComponent();
        }
        public FormManager(Login fl, string info) : this()
        {
            this.Fl = fl;
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            this.metroPanel4.Controls.Clear();
            UserControlRecentOrder RecentOrders = new UserControlRecentOrder();
            this.metroPanel4.Controls.Add(RecentOrders);
        }

        private void btnManageSalesman_Click(object sender, EventArgs e)
        {
            this.metroPanel4.Controls.Clear();
            ManageSalesman msales = new ManageSalesman();
            this.metroPanel4.Controls.Add(msales);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.metroPanel4.Controls.Clear();
            UserControlRecentOrder RecentOrders = new UserControlRecentOrder();
            this.metroPanel4.Controls.Add(RecentOrders);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.metroPanel4.Controls.Clear();
            manageProduct Product = new manageProduct();
            this.metroPanel4.Controls.Add(Product);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            this.metroPanel4.Controls.Clear();
            EditProfile edit = new EditProfile();
            this.metroPanel4.Controls.Add(edit);
        }
        private void Logout()
        {
            session.destroy();
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void FormManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logout();
        }
    }
}
