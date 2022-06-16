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
    public partial class UserControlOrder : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlOrder()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void UserControlOrder_Load(object sender, EventArgs e)
        {
            populateGridView();
            this.txtOrderID.Text = randomOrderID();
        }
        private string randomOrderID() {
            Random random = new Random();
            int RandowIDInt= random.Next(1, 100);
            string RandomIDString = "O-" + RandowIDInt;
            return RandomIDString;
        }
        


        
        private void adjustStock(int quantity) {
            string productID = this.dgvProdcuts.CurrentRow.Cells["productId"].Value.ToString();
            string sqlProduct = "select * from Product where productId='" + productID + "';";
            var dsProduct = this.Da.ExecuteQuery(sqlProduct);
            string stockText = dsProduct.Tables[0].Rows[0][4].ToString();
            int stock = Int32.Parse(stockText);
            if (stock < 1)
            {
                MessageBox.Show("Stock OUT");
                return;
            }
            stock=stock- quantity;
            
            string sqlFixStock = "update Product set stock ="+ stock + " where productId='"+ productID + "';";
            //string sql = ;
            this.Da.ExecuteQuery(sqlFixStock);
            MessageBox.Show("Added in cart");
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string productID = this.dgvProdcuts.CurrentRow.Cells["productId"].Value.ToString();
            string productName = this.txtProductName.Text;
            string categoryName = this.txtCategory.Text;
            string productPrice = this.txtPrice.Text;
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(productPrice))
            {
                MessageBox.Show("Please fill-up all information");
                return;
            }
            FormConfirmOrder frmConfirm = new FormConfirmOrder(this.txtOrderID.Text);
            frmConfirm.Show();
           /*
            try
            {
                
                //set value for customer table
                string customerName = this.txtCustomerName.Text;
                string address = this.txtAddress.Text;
                string contactNumber = this.txtContactNumber.Text;
                string productID = this.dgvProdcuts.CurrentRow.Cells["productId"].Value.ToString();
                string sqlProduct = "select * from Product where productId='" + productID + "';";
                var dsProduct = this.Da.ExecuteQuery(sqlProduct);
                string catgoryID = dsProduct.Tables[0].Rows[0][2].ToString();
                string OrderID=this.txtOrderID.Text;
                string CustomerID = this.txtCusotomerID.Text;
                string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string sqlInsertCustomer = "insert into Customers values ('" + CustomerID + "','" + customerName + "', '" + address + "', '" + contactNumber + "');";

                string sqlOrderConfirm = "insert into Orders values ('"+ OrderID + "','"+ productID + "','"+ catgoryID + "','"+ CustomerID + "','"+ date + "');";
                int countCustomer = this.Da.ExecuteDMLQuery(sqlInsertCustomer);
                int countOrder = this.Da.ExecuteDMLQuery(sqlOrderConfirm);
                if (countOrder == 1 && countCustomer==1)
                {
                    MessageBox.Show("Inserted suceesfully");
                }
                else
                    MessageBox.Show("Data ubsertion failed");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
           */
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            string productID = this.dgvProdcuts.CurrentRow.Cells["productId"].Value.ToString();
            string productName = this.txtProductName.Text;
            string categoryName = this.txtCategory.Text;
            string productPrice = this.txtPrice.Text;
            if(string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(productPrice))
            {
                MessageBox.Show("Please fill-up all information");
                return;
            }
           
            string sqlProduct = "select * from Product where productId='" + productID + "';";
            var dsProduct = this.Da.ExecuteQuery(sqlProduct);
            string unit = this.qtyVal.Text;
            int quantity = Convert.ToInt32(unit);
            string catgoryID = dsProduct.Tables[0].Rows[0][2].ToString();
            
            int priceInt = Convert.ToInt32(productPrice);
            string sql = "select * from Cart";
            var dsCartCheck=this.Da.ExecuteQuery(sql);
            
                for (byte i = 0; i < dsCartCheck.Tables[0].Rows.Count; i++) {
                    if (dsCartCheck.Tables[0].Rows[i][0].ToString() == productID)
                    {
                        MessageBox.Show("Product is already added in the cart");
                        return;
                    }
                }
                
            try {
                string sqlAddCart = "insert into cart values('" + productID + "','" + productName + "'," + quantity + ",'" + catgoryID + "'," + priceInt + ");";
                var result = this.Da.ExecuteDMLQuery(sqlAddCart);
                if (result == 1)
                {
                    adjustStock(quantity);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



        }

        private void tbSlider_Scroll(object sender, ScrollEventArgs e)
        {
            int value = this.tbSlider.Value;
            this.qtyVal.Text = value.ToString();
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            Cart fc = new Cart();
            fc.Show();
        }
        public void populateGridView(string sql = @"select Product.productId, Product.productName,categorys.
                categoryName, Product.price from Product inner join categorys on
                Product.categoryId= categorys.categoryId;")
        {
            try
            {
                
                var ds = this.Da.ExecuteQuery(sql);
                this.dgvProdcuts.AutoGenerateColumns = false;
                this.dgvProdcuts.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }
        //searching 
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            int value = this.txtSearch.Text.Length;
            if (value < 1)
            {
                this.populateGridView();
            }
            else
            {

                string search= @"select  Product.productId, Product.productName,categorys.categoryName, 
                Product.price from Product inner join categorys on 
                Product.categoryId=categorys.categoryId where Product.productId 
                like '%"+this.txtSearch.Text+"%' or Product.productName like '%"+this.txtSearch.Text+"%';";
                populateGridView(search);



                /*
                string secheck = @"select Product.productId, Product.productName,categorys.categoryName, 
                Product.price from Product inner join categorys on 
                Product.categoryId=categorys.categoryId Product.productId like '%"
                + this.txtSearch.Text + "%' or Product.productName like '%" + this.txtSearch.Text + "%';";
                populateGridView(secheck);
                */
            }
        }

        private void dgvProdcuts_DoubleClick(object sender, EventArgs e)
        {

            this.txtProductName.Text = this.dgvProdcuts.CurrentRow.Cells["productName"].Value.ToString();
            this.txtCategory.Text = this.dgvProdcuts.CurrentRow.Cells["categoryName"].Value.ToString();
            this.txtPrice.Text = this.dgvProdcuts.CurrentRow.Cells["price"].Value.ToString();
        }
    }
}
