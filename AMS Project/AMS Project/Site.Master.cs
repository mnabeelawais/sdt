using System;
using System.Web.UI;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if user is logged in
        if (Session["UserID"] != null)
        {
            // Display user info and logout link
            lblUserInfo.Text = "Welcome, " + Session["FullName"].ToString();
            lnkLogout.Visible = true;
        }
        else
        {
            // Redirect to login page if not on login page
            if (!Request.Url.AbsolutePath.ToLower().Contains("login.aspx"))
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        // Clear session and redirect to login page
        Session.Clear();
        Response.Redirect("~/Login.aspx");
    }
}