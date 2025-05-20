using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageStudents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is authenticated
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            // Check user role and hide "Add New Student" button for teachers
            string userRole = Session["Role"].ToString();
            btnAddNew.Visible = (userRole == "Admin"); // Only visible for Admin role

            // Check if we're adding a new student
            if (Request.QueryString["action"] == "add" && userRole == "Admin")
            {
                ShowStudentForm(true);
            }
            else
            {
                LoadStudents();
            }

            LoadClasses();
        }
    }

    private void LoadStudents(string searchTerm = "")
    {
        string query = @"
            SELECT StudentID, StudentCode, FirstName, LastName, Gender, Class, 
            CASE WHEN Status = 1 THEN 'Active' ELSE 'Inactive' END AS Status
            FROM Students
            WHERE (@SearchTerm = '' OR 
                  StudentCode LIKE '%' + @SearchTerm + '%' OR 
                  FirstName LIKE '%' + @SearchTerm + '%' OR 
                  LastName LIKE '%' + @SearchTerm + '%')
            ORDER BY FirstName, LastName";

        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@SearchTerm", searchTerm)
        };

        DataTable dt = Database.ExecuteQuery(query, parameters);
        gvStudents.DataSource = dt;
        gvStudents.DataBind();
    }

    private void LoadClasses()
    {
        string query = "SELECT ClassID, ClassName FROM Classes ORDER BY ClassName";
        DataTable dt = Database.ExecuteQuery(query);

        ddlClass.Items.Clear();
        ddlClass.Items.Add(new ListItem("Select Class", ""));

        foreach (DataRow row in dt.Rows)
        {
            ddlClass.Items.Add(new ListItem(row["ClassName"].ToString(), row["ClassName"].ToString()));
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        ShowStudentForm(true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadStudents(txtSearch.Text.Trim());
    }

    protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int studentId = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "EditStudent")
        {
            LoadStudentForEdit(studentId);
        }
        else if (e.CommandName == "DeleteStudent")
        {
            DeleteStudent(studentId);
        }
    }

    private void LoadStudentForEdit(int studentId)
    {
        string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@StudentID", studentId)
        };

        DataTable dt = Database.ExecuteQuery(query, parameters);

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];

            hdnStudentID.Value = studentId.ToString();
            txtStudentCode.Text = row["StudentCode"].ToString();
            txtFirstName.Text = row["FirstName"].ToString();
            txtLastName.Text = row["LastName"].ToString();

            if (row["Gender"] != DBNull.Value)
            {
                ddlGender.SelectedValue = row["Gender"].ToString();
            }

            if (row["Class"] != DBNull.Value)
            {
                ddlClass.SelectedValue = row["Class"].ToString();
            }

            chkStatus.Checked = Convert.ToBoolean(row["Status"]);

            ShowStudentForm(false);
        }
        else
        {
            lblMessage.Text = "Student not found.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }
    }

    private void DeleteStudent(int studentId)
    {
        // Check if student has attendance records
        string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentID = @StudentID";
        SqlParameter[] checkParams = new SqlParameter[]
        {
            new SqlParameter("@StudentID", studentId)
        };

        int attendanceCount = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));

        if (attendanceCount > 0)
        {
            // Student has attendance records, just mark as inactive
            string updateQuery = "UPDATE Students SET Status = 0 WHERE StudentID = @StudentID";
            SqlParameter[] updateParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentId)
            };

            Database.ExecuteNonQuery(updateQuery, updateParams);
            lblMessage.Text = "Student marked as inactive because they have attendance records.";
        }
        else
        {
            // No attendance records, safe to delete
            string deleteQuery = "DELETE FROM Students WHERE StudentID = @StudentID";
            SqlParameter[] deleteParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentId)
            };

            Database.ExecuteNonQuery(deleteQuery, deleteParams);
            lblMessage.Text = "Student deleted successfully.";
        }

        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Visible = true;

        // Reload the grid
        LoadStudents();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Check if student code already exists
        string checkQuery = "SELECT COUNT(*) FROM Students WHERE StudentCode = @StudentCode AND StudentID != @StudentID";
        SqlParameter[] checkParams = new SqlParameter[]
        {
            new SqlParameter("@StudentCode", txtStudentCode.Text.Trim()),
            new SqlParameter("@StudentID", string.IsNullOrEmpty(hdnStudentID.Value) ? 0 : Convert.ToInt32(hdnStudentID.Value))
        };

        int existingCount = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));

        if (existingCount > 0)
        {
            lblFormMessage.Text = "Student ID already exists. Please use a different ID.";
            lblFormMessage.Visible = true;
            return;
        }

        // Insert or update student
        if (string.IsNullOrEmpty(hdnStudentID.Value))
        {
            // Insert new student
            string insertQuery = @"
                INSERT INTO Students (StudentCode, FirstName, LastName, Gender, Class, Status)
                VALUES (@StudentCode, @FirstName, @LastName, @Gender, @Class, @Status)";

            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("@StudentCode", txtStudentCode.Text.Trim()),
                new SqlParameter("@FirstName", txtFirstName.Text.Trim()),
                new SqlParameter("@LastName", txtLastName.Text.Trim()),
                new SqlParameter("@Gender", ddlGender.SelectedValue),
                new SqlParameter("@Class", ddlClass.SelectedValue),
                new SqlParameter("@Status", chkStatus.Checked)
            };

            Database.ExecuteNonQuery(insertQuery, insertParams);
            lblMessage.Text = "Student added successfully.";
        }
        else
        {
            // Update existing student
            string updateQuery = @"
                UPDATE Students SET 
                StudentCode = @StudentCode, 
                FirstName = @FirstName, 
                LastName = @LastName, 
                Gender = @Gender, 
                Class = @Class, 
                Status = @Status
                WHERE StudentID = @StudentID";

            SqlParameter[] updateParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID", Convert.ToInt32(hdnStudentID.Value)),
                new SqlParameter("@StudentCode", txtStudentCode.Text.Trim()),
                new SqlParameter("@FirstName", txtFirstName.Text.Trim()),
                new SqlParameter("@LastName", txtLastName.Text.Trim()),
                new SqlParameter("@Gender", ddlGender.SelectedValue),
                new SqlParameter("@Class", ddlClass.SelectedValue),
                new SqlParameter("@Status", chkStatus.Checked)
            };

            Database.ExecuteNonQuery(updateQuery, updateParams);
            lblMessage.Text = "Student updated successfully.";
        }

        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Visible = true;

        // Reset form and show student list
        ResetForm();
        pnlStudentForm.Visible = false;
        pnlStudentList.Visible = true;

        // Reload the grid
        LoadStudents();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetForm();
        pnlStudentForm.Visible = false;
        pnlStudentList.Visible = true;
    }

    private void ShowStudentForm(bool isNew)
    {
        if (isNew)
        {
            litFormTitle.Text = "Add New Student";
            ResetForm();
        }
        else
        {
            litFormTitle.Text = "Edit Student";
        }

        pnlStudentList.Visible = false;
        pnlStudentForm.Visible = true;
    }

    private void ResetForm()
    {
        hdnStudentID.Value = "";
        txtStudentCode.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        ddlGender.SelectedIndex = 0;
        ddlClass.SelectedIndex = 0;
        chkStatus.Checked = true;
        lblFormMessage.Visible = false;
    }
}