﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Login_and_Registration_GUI
{
    public class DataAccess
    {
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return sqlcon; }
            set { sqlcon = value; }
        }

        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return sqlcom; }
            set { sqlcom = value; }
        }

        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return sda; }
            set { sda = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        //internal DataTable dt;

        public DataAccess()
        {
            //this.sqcon = new SqlConnection(WFAExer.Properties.Settings.Default.conStr);
            this.Sqlcon = new SqlConnection(@"Data Source=CYBERSPACE;Initial Catalog=techshopdb;User ID=sa;Password=sa123");
            Sqlcon.Open();
        }

        private void QueryText(string query)
        {
            this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        }

        public DataSet ExecuteQuery(string sql)
        {
            this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds;
        }

        public int ExecuteDMLQuery(string sql)
        {
            this.QueryText(sql);
            int u = this.Sqlcom.ExecuteNonQuery();
            return u;
        }
    }
}
