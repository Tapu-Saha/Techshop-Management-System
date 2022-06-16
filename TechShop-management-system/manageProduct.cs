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
    public partial class manageProduct : UserControl
    {
        private DataAccess Da { get; set; }
        public manageProduct()
        {
            InitializeComponent();
            
        }
        private void populateGridView(string sql = "select * from Product;")
        {
            try
            {
                this.Da = new DataAccess();
                var ds = this.Da.ExecuteQuery(sql);
                this.dvgProducts.AutoGenerateColumns = false;
                this.dvgProducts.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("error from load" + exc.Message);
            }
        }
        private void manageProduct_Load(object sender, EventArgs e)
        {
            populateGridView();
        }

        private void metroGrid1_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = this.dvgProducts.CurrentRow.Cells["productId"].Value.ToString();
            this.txtProductName.Text = this.dvgProducts.CurrentRow.Cells["productName"].Value.ToString();
            this.txtCategory.Text = this.dvgProducts.CurrentRow.Cells["categoryId"].Value.ToString();
            this.txtPrice.Text = this.dvgProducts.CurrentRow.Cells["price"].Value.ToString();
            this.txtStock.Text = this.dvgProducts.CurrentRow.Cells["stock"].Value.ToString();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string ProductID = this.txtID.Text;
            string ProductName = this.txtProductName.Text;
            string Price = this.txtPrice.Text;
            string Stock = this.txtStock.Text;
            string CategoryID = this.txtCategory.Text;
            if (string.IsNullOrEmpty(ProductID) || string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Price) || string.IsNullOrEmpty(Stock) || string.IsNullOrEmpty(CategoryID) )
            {
                MessageBox.Show("Please fill-up all information");
                return;
            }
            try
            {
            

            string sqlProduct = "insert into Product values ('" + ProductID + "','" + ProductName + "','" + CategoryID + "'," + Price + "," + Stock + ");";
            int count = this.Da.ExecuteDMLQuery(sqlProduct);
            if (count == 1)
            {
                MessageBox.Show("Inserted suceesfully");
            }
            else
                MessageBox.Show("Data ubsertion failed");
            this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("from add error" + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }
        private void ClearContent()
        {
            this.txtID.Clear();
            this.txtProductName.Clear();
            this.txtPrice.Clear();
            this.txtStock.Clear();
            this.txtCategory.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.txtID.Text;
                var name = this.txtProductName.Text;
                var sql = "delete from Product where productId='"+id+"';";
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show(name + " has been deleted successfully.");
                }
                else
                    MessageBox.Show("Data deletion failed.");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error from delete" + exc.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string ProductID = this.txtID.Text;
                string ProductName = this.txtProductName.Text;
                string PriceText = this.txtPrice.Text;
                int Price = Int32.Parse(PriceText);
                string StockText = this.txtStock.Text;
                int stock = Int32.Parse(StockText);
                string CategoryID = this.txtCategory.Text;
                string sql = @"update Product set productName='"+ ProductName + "', categoryId='"+ CategoryID + "',price="+ Price + ", stock="+ stock + " where productId='"+ ProductID + "';";
                int count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Data Updated suceesfully");
                }
                else
                    MessageBox.Show("Data upgradation failed");
                this.populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("from edit error" + exc.Message);
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
                string search = "select * from Product where productId like '%"+ this.txtSearch.Text + "%' or productName like '%"+ this.txtSearch.Text + "%';";
                populateGridView(search);

            }
        }
    }
}
