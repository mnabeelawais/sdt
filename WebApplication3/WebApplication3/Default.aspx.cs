using System;
using System.Web.UI;


namespace WebApplication3
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataAccessLayer dal = new DataAccessLayer();
                string query = "SELECT DISTINCT city FROM C_data";
                dal.FillDropDown(ddlCity, query);
                
                query = "SELECT DISTINCT state FROM C_data";
                dal.FillDropDown(ddlState, query);
                
                query = "SELECT DISTINCT country FROM C_data";
                dal.FillDropDown(ddlCountry, query);
            }
        }
    }
}