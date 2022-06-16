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
    public partial class UserControlRecentOrder : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlRecentOrder()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void UserControlRecentOrder_Load(object sender, EventArgs e)
        {
            populateGridView();
        }
        public void populateGridView(string sql = "select * from Orders order by OrderNumber desc;")
        {
            try
            {

                var ds = this.Da.ExecuteQuery(sql);
                this.dgvRecentOrder.AutoGenerateColumns = false;
                this.dgvRecentOrder.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
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
                    string secheck = @"select * from Orders where orderId like '%"
                    + this.txtSearch.Text + "%' or customerName like '%" + this.txtSearch.Text + "%';";
                    populateGridView(secheck);
                }
            
        }
    }
}
