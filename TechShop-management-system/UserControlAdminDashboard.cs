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
    public partial class UserControlAdminDashboard : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlAdminDashboard()
        {
            InitializeComponent();
        }
        private void populateGridView(string sql = "select * from Product;") {
            try
            {
                
                var ds = this.Da.ExecuteQuery(sql);
                this.dgvProduct.AutoGenerateColumns = false;
                this.dgvProduct.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }

        private void UserControlAdminDashboard_Load(object sender, EventArgs e)
        {
            this.Da = new DataAccess();
            populateGridView();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            int value = this.txtSearch.Text.Length;
            if (value < 1)
            {
                this.populateGridView();
            }
            else
            {
                string search = "select * from Product where productId like '%" + this.txtSearch.Text + "%' or productName like '%" + this.txtSearch.Text + "%';";
                populateGridView(search);

            }
        }
    }
}
