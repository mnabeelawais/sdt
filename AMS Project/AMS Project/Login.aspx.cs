using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear session if user is logging out
        if (Request.QueryString["logout"] == "true")
        {
            Session.Clear();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        // Create SQL query to check user credentials
        string query = "SELECT UserID, Username, FullName, Role FROM Users WHERE Username = @Username AND Password = @Password";

        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password)
        };

        // Execute query
        DataTable dt = Database.ExecuteQuery(query, parameters);

        if (dt.Rows.Count > 0)
        {
            // Login successful - store user info in session
            DataRow row = dt.Rows[0];
            Session["UserID"] = row["UserID"];
            Session["Username"] = row["Username"];
            Session["FullName"] = row["FullName"];
            Session["Role"] = row["Role"]; 

            // Redirect to dashboard
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            // Login failed
            lblError.Text = "Invalid username or password";
            lblError.Visible = true;
        }
    }
}