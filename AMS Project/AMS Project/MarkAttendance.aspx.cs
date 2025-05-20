using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MarkAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set default date to today
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Load classes
            LoadClasses();
        }
    }

    private void LoadClasses()
    {
        string query = "SELECT DISTINCT Class FROM Students WHERE Class IS NOT NULL ORDER BY Class";
        DataTable dt = Database.ExecuteQuery(query);

        ddlClass.Items.Clear();
        ddlClass.Items.Add(new ListItem("Select Class", ""));

        foreach (DataRow row in dt.Rows)
        {
            ddlClass.Items.Add(new ListItem(row["Class"].ToString(), row["Class"].ToString()));
        }
    }

    protected void btnLoadStudents_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlClass.SelectedValue) && !string.IsNullOrEmpty(txtDate.Text))
        {
            LoadStudentsForAttendance();
        }
    }

    private void LoadStudentsForAttendance()
    {
        string selectedClass = ddlClass.SelectedValue;
        DateTime selectedDate = Convert.ToDateTime(txtDate.Text);

        // Check if attendance already exists for this class and date
        string checkQuery = @"
            SELECT COUNT(*) FROM Attendance a
            INNER JOIN Students s ON a.StudentID = s.StudentID
            WHERE s.Class = @Class AND a.AttendanceDate = @Date";

        SqlParameter[] checkParams = new SqlParameter[]
        {
            new SqlParameter("@Class", selectedClass),
            new SqlParameter("@Date", selectedDate)
        };

        int attendanceCount = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));

        string query;
        SqlParameter[] parameters;

        if (attendanceCount > 0)
        {
            // Load existing attendance records
            lblAttendanceStatus.Text = "Attendance for this class and date has already been recorded. You can update it below.";
            lblAttendanceStatus.Visible = true;

            query = @"
                SELECT s.StudentID, s.StudentCode, s.FirstName + ' ' + s.LastName AS FullName,
                a.Status, a.Remarks
                FROM Students s
                LEFT JOIN Attendance a ON s.StudentID = a.StudentID AND a.AttendanceDate = @Date
                WHERE s.Class = @Class AND s.Status = 1
                ORDER BY s.FirstName, s.LastName";

            parameters = new SqlParameter[]
            {
                new SqlParameter("@Class", selectedClass),
                new SqlParameter("@Date", selectedDate)
            };
        }
        else
        {
            // Load students for new attendance
            lblAttendanceStatus.Text = "Recording new attendance for this class and date.";
            lblAttendanceStatus.Visible = true;

            query = @"
                SELECT StudentID, StudentCode, FirstName + ' ' + LastName AS FullName,
                NULL AS Status, NULL AS Remarks
                FROM Students
                WHERE Class = @Class AND Status = 1
                ORDER BY FirstName, LastName";

            parameters = new SqlParameter[]
            {
                new SqlParameter("@Class", selectedClass)
            };
        }

        DataTable dt = Database.ExecuteQuery(query, parameters);
        gvAttendance.DataSource = dt;
        gvAttendance.DataBind();

        // Set existing attendance status and remarks if available
        if (attendanceCount > 0)
        {
            for (int i = 0; i < gvAttendance.Rows.Count; i++)
            {
                string status = dt.Rows[i]["Status"].ToString();
                string remarks = dt.Rows[i]["Remarks"].ToString();

                if (!string.IsNullOrEmpty(status))
                {
                    RadioButtonList rblStatus = (RadioButtonList)gvAttendance.Rows[i].FindControl("rblStatus");
                    rblStatus.SelectedValue = status;

                    TextBox txtRemarks = (TextBox)gvAttendance.Rows[i].FindControl("txtRemarks");
                    txtRemarks.Text = remarks;
                }
            }
        }

        litClassDate.Text = selectedClass + " on " + selectedDate.ToString("MMMM d, yyyy");
        pnlAttendance.Visible = true;
    }

    protected void btnSaveAttendance_Click(object sender, EventArgs e)
    {
        DateTime selectedDate = Convert.ToDateTime(txtDate.Text);
        int recordedBy = Convert.ToInt32(Session["UserID"]);
        bool success = true;

        // Process each student in the grid
        foreach (GridViewRow row in gvAttendance.Rows)
        {
            int studentId = Convert.ToInt32(gvAttendance.DataKeys[row.RowIndex].Value);
            RadioButtonList rblStatus = (RadioButtonList)row.FindControl("rblStatus");
            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");

            string status = rblStatus.SelectedValue;
            string remarks = txtRemarks.Text.Trim();

            // First delete any existing attendance record for this student and date
            string deleteQuery = "DELETE FROM Attendance WHERE StudentID = @StudentID AND AttendanceDate = @Date";
            SqlParameter[] deleteParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentId),
                new SqlParameter("@Date", selectedDate)
            };

            Database.ExecuteNonQuery(deleteQuery, deleteParams);

            // Then insert new attendance record
            string insertQuery = @"
                INSERT INTO Attendance (StudentID, AttendanceDate, Status, Remarks, RecordedBy)
                VALUES (@StudentID, @Date, @Status, @Remarks, @RecordedBy)";

            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentId),
                new SqlParameter("@Date", selectedDate),
                new SqlParameter("@Status", status),
                new SqlParameter("@Remarks", remarks),
                new SqlParameter("@RecordedBy", recordedBy)
            };

            int result = Database.ExecuteNonQuery(insertQuery, insertParams);

            if (result <= 0)
            {
                success = false;
            }
        }

        if (success)
        {
            lblMessage.Text = "Attendance saved successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblMessage.Text = "Error saving attendance.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }

        lblMessage.Visible = true;
    }
}