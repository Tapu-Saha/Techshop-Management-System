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
    public partial class UserControlViewCustomer : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlViewCustomer()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        public void populateGridView(string sql = "select * from Customers;")
        {
            try
            {

                var ds = this.Da.ExecuteQuery(sql);
                this.dgvCustomers.AutoGenerateColumns = false;
                this.dgvCustomers.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }
        private void UserControlViewCustomer_Load(object sender, EventArgs e)
        {
            populateGridView();
        }
    }
}
