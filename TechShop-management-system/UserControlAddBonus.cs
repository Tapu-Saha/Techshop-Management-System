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
    public partial class UserControlAddBonus : UserControl
    {
        private DataAccess Da { get; set; }
        public UserControlAddBonus()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void populateGridView(string sql = "select userId ,userName, salary, bonus , salaryBonus,role from UserInformation where not role='admin';")
        {
            try
            {
                var ds = this.Da.ExecuteQuery(sql);
                this.dgvManager.AutoGenerateColumns = false;
                this.dgvManager.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("from Grid view error" + exc.Message);
            }

        }

        private void UserControlAddBonusManager_Load(object sender, EventArgs e)
        {
            try
            {
                populateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error" + exc.Message);
            }
        }

        

        

        private void dgvManager_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = this.dgvManager.CurrentRow.Cells["userId"].Value.ToString();
            this.txtName.Text = this.dgvManager.CurrentRow.Cells["userName"].Value.ToString();
            this.txtAddBonus.Text = this.dgvManager.CurrentRow.Cells["bonus"].Value.ToString();
            
        }

        private void btnSetBonus_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text == "" || this.txtName.Text == "" || this.txtAddBonus.Text == "")
            {
                MessageBox.Show("Please fill all information");
                return;
            }
            string userID = this.txtID.Text;
            string bonusTxt = this.txtAddBonus.Text;
            int Bonus = Convert.ToInt32(bonusTxt);
            
            try
            {
                string sql = "update UserInformation set bonus ="+ Bonus + " ,salaryBonus=salary+"+ Bonus + " where userId='"+ userID + "';";
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
    }
}
