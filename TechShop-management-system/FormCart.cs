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
    public partial class Cart : MetroForm
    {
        private DataAccess Da { get; set; }
        public Cart()
        {
            InitializeComponent();
            this.Da = new DataAccess();
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
        private void Cart_Load(object sender, EventArgs e)
        {
            populateGridView();
            string sql = "select sum(price) from Cart";
            var result = this.Da.ExecuteQuery(sql);
            this.lblTotalPrice.Text= result.Tables[0].Rows[0][0].ToString();
        }

        private void dgvCart_DoubleClick(object sender, EventArgs e)
        {

           /* this.lblProductName.Text = this.dgvCart.CurrentRow.Cells["productName"].Value.ToString();
            this.txtProductUnit.Text = this.dgvCart.CurrentRow.Cells["quantity"].Value.ToString();
           */
        }

        private void dgvCart_Click(object sender, EventArgs e)
        {
            this.lblProductName.Text = this.dgvCart.CurrentRow.Cells["productName"].Value.ToString();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string key= this.dgvCart.CurrentRow.Cells["productName"].Value.ToString();
            string sqlDelete = "delete from Cart where ProductName='"+key+"';";
            var count = this.Da.ExecuteDMLQuery(sqlDelete);
            if(count == 1)
            {
                MessageBox.Show(key+" removed from the cart");
                
                populateGridView();
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            string sql = "delete from Cart";
            var count = this.Da.ExecuteDMLQuery(sql);
            if (count > 0)
            {
                MessageBox.Show("This cart is cleaned");
                populateGridView();
            }
        }
    }
}
