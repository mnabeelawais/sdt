using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public class DataAccessLayer

    {
        string constr;
        SqlConnection mydbCon;
        SqlDataAdapter da;
        DataSet ds;
        public DataAccessLayer()
        {
            constr = System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ToString();
        }
        protected SqlConnection OpenDBCon()
        {
            try
            {
                mydbCon = new SqlConnection(constr);
                mydbCon.Open();
                return mydbCon;
            }
            catch (SqlException ex)
            {
                throw new Exception("Failed to connect to database. Please verify SQL Server is running and connection string is correct. Error: " + ex.Message);
            }
        }
        public DataSet FillDS(string query)
        {
            da = new SqlDataAdapter(query, OpenDBCon());
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void FillDG(GridView g, string query)
        {
            g.DataSource = FillDS(query).Tables[0];
            g.DataBind();
        }
        
        public void FillDropDown(DropDownList ddl, string query)
        {
            DataTable dt = FillDS(query).Tables[0];
            ddl.DataSource = dt;
            ddl.DataTextField = dt.Columns[0].ColumnName;
            ddl.DataValueField = dt.Columns[0].ColumnName;
            ddl.DataBind();
        }
    }
}