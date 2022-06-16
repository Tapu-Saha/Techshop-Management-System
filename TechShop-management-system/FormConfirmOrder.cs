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
    public partial class FormConfirmOrder : MetroForm
    {
        private DataAccess Da { get; set; }
        public FormConfirmOrder()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        public FormConfirmOrder(string OrderID) : this() {
            this.txtOrderID.Text = OrderID;
        }
        private void populateGridView(string sql = "select * from Cart")
        {
            try
            {
                var ds = this.Da.ExecuteQuery(sql);
                this.dgvCart.AutoGenerateColumns = false;
                this.dgvCart.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("from Grid view error" + exc.Message);
            }

        }
        private void FormConfirmOrder_Load(object sender, EventArgs e)
        {
            populateGridView();
            string sql = "select sum(price) from Cart";
            var result = this.Da.ExecuteQuery(sql);
            this.lblTotalPrice.Text = result.Tables[0].Rows[0][0].ToString();
            
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string OrderID = this.txtOrderID.Text;
            string CustomerName = this.txtCustomerName.Text;
            if(string.IsNullOrEmpty(OrderID) || string.IsNullOrEmpty(CustomerName))
            {
                MessageBox.Show("Customer name needed to confirm the order");
                return;
            }
            string Date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            try
            {
                string SqlOrder = "insert into Orders values ('" + OrderID + "','" + CustomerName + "','" + Date + "');";
                int CountOrder = this.Da.ExecuteDMLQuery(SqlOrder);
                if (CountOrder == 1)
                {
                    MessageBox.Show("Order placed successfully");
                    string sql = "delete from Cart";
                    this.Da.ExecuteDMLQuery(sql);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("from Grid view error" + exc.Message);
            }


        }
    }
}
