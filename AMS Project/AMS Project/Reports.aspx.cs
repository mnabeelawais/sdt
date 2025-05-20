using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set default dates
            txtDailyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtStudentStartDate.Text = startOfMonth.ToString("yyyy-MM-dd");
            txtClassStartDate.Text = startOfMonth.ToString("yyyy-MM-dd");

            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            txtStudentEndDate.Text = endOfMonth.ToString("yyyy-MM-dd");
            txtClassEndDate.Text = endOfMonth.ToString("yyyy-MM-dd");

            // Load classes and students
            LoadClasses();
            LoadStudents();
        }
    }

    private void LoadClasses()
    {
        string query = "SELECT DISTINCT Class FROM Students WHERE Class IS NOT NULL ORDER BY Class";
        DataTable dt = Database.ExecuteQuery(query);

        // Add classes to all class dropdowns
        foreach (DataRow row in dt.Rows)
        {
            string className = row["Class"].ToString();
            ddlDailyClass.Items.Add(new ListItem(className, className));
            ddlClass.Items.Add(new ListItem(className, className));
        }
    }

    private void LoadStudents()
    {
        string query = @"
            SELECT StudentID, StudentCode + ' - ' + FirstName + ' ' + LastName AS StudentName
            FROM Students
            WHERE Status = 1
            ORDER BY FirstName, LastName";

        DataTable dt = Database.ExecuteQuery(query);

        ddlStudent.DataSource = dt;
        ddlStudent.DataTextField = "StudentName";
        ddlStudent.DataValueField = "StudentID";
        ddlStudent.DataBind();

        ddlStudent.Items.Insert(0, new ListItem("Select Student", ""));
    }

    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Hide all panels first
        pnlDailyReport.Visible = false;
        pnlStudentReport.Visible = false;
        pnlClassReport.Visible = false;
        pnlReportResults.Visible = false;

        // Show the selected panel
        switch (ddlReportType.SelectedValue)
        {
            case "Daily":
                pnlDailyReport.Visible = true;
                break;
            case "Student":
                pnlStudentReport.Visible = true;
                break;
            case "Class":
                pnlClassReport.Visible = true;
                break;
        }
    }

    protected void btnGenerateDailyReport_Click(object sender, EventArgs e)
    {
        DateTime reportDate = Convert.ToDateTime(txtDailyDate.Text);
        string className = ddlDailyClass.SelectedValue;

        GenerateDailyReport(reportDate, className);
    }

    protected void btnGenerateStudentReport_Click(object sender, EventArgs e)
    {
        int studentId = Convert.ToInt32(ddlStudent.SelectedValue);
        DateTime startDate = Convert.ToDateTime(txtStudentStartDate.Text);
        DateTime endDate = Convert.ToDateTime(txtStudentEndDate.Text);

        GenerateStudentReport(studentId, startDate, endDate);
    }

    protected void btnGenerateClassReport_Click(object sender, EventArgs e)
    {
        string className = ddlClass.SelectedValue;
        DateTime startDate = Convert.ToDateTime(txtClassStartDate.Text);
        DateTime endDate = Convert.ToDateTime(txtClassEndDate.Text);

        GenerateClassReport(className, startDate, endDate);
    }

    private void GenerateDailyReport(DateTime reportDate, string className)
    {
        string query = @"
            SELECT s.StudentCode, s.FirstName, s.LastName, s.Class, 
            ISNULL(a.Status, 'Not Marked') AS Status, a.Remarks
            FROM Students s
            LEFT JOIN Attendance a ON s.StudentID = a.StudentID AND a.AttendanceDate = @ReportDate
            WHERE s.Status = 1 ";

        if (!string.IsNullOrEmpty(className))
        {
            query += " AND s.Class = @ClassName";
        }

        query += " ORDER BY s.Class, s.FirstName, s.LastName";

        SqlParameter[] parameters;

        if (!string.IsNullOrEmpty(className))
        {
            parameters = new SqlParameter[]
            {
                new SqlParameter("@ReportDate", reportDate),
                new SqlParameter("@ClassName", className)
            };
        }
        else
        {
            parameters = new SqlParameter[]
            {
                new SqlParameter("@ReportDate", reportDate)
            };
        }

        DataTable dt = Database.ExecuteQuery(query, parameters);

        // Configure the GridView
        gvReport.Columns.Clear();

        gvReport.Columns.Add(new BoundField { HeaderText = "Student ID", DataField = "StudentCode" });
        gvReport.Columns.Add(new BoundField { HeaderText = "First Name", DataField = "FirstName" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Last Name", DataField = "LastName" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Class", DataField = "Class" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Status", DataField = "Status" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Remarks", DataField = "Remarks" });

        gvReport.DataSource = dt;
        gvReport.DataBind();

        // Set report title
        string title = "Daily Attendance Report for " + reportDate.ToString("MMMM d, yyyy");
        if (!string.IsNullOrEmpty(className))
        {
            title += " - Class: " + className;
        }
        litReportTitle.Text = title;

        // Calculate summary
        int totalStudents = dt.Rows.Count;
        int present = dt.Select("Status = 'Present'").Length;
        int absent = dt.Select("Status = 'Absent'").Length;
        int late = dt.Select("Status = 'Late'").Length;
        int notMarked = dt.Select("Status = 'Not Marked'").Length;

        decimal attendanceRate = totalStudents > 0 ? (decimal)(present + late) / (totalStudents - notMarked) * 100 : 0;

        lblTotalStudents.Text = totalStudents.ToString();
        lblTotalPresent.Text = present.ToString();
        lblTotalAbsent.Text = absent.ToString();
        lblTotalLate.Text = late.ToString();
        lblAttendanceRate.Text = attendanceRate.ToString("0.00") + "%";

        // Show panels
        pnlReportResults.Visible = true;
        pnlSummary.Visible = true;
    }

    private void GenerateStudentReport(int studentId, DateTime startDate, DateTime endDate)
    {
        // Get student details
        string studentQuery = "SELECT StudentCode, FirstName + ' ' + LastName AS FullName, Class FROM Students WHERE StudentID = @StudentID";
        SqlParameter[] studentParams = new SqlParameter[]
        {
            new SqlParameter("@StudentID", studentId)
        };

        DataTable studentDt = Database.ExecuteQuery(studentQuery, studentParams);
        string studentName = "";
        string studentCode = "";
        string studentClass = "";

        if (studentDt.Rows.Count > 0)
        {
            DataRow row = studentDt.Rows[0];
            studentCode = row["StudentCode"].ToString();
            studentName = row["FullName"].ToString();
            studentClass = row["Class"].ToString();
        }

        // Get attendance records
        string query = @"
            SELECT a.AttendanceDate, a.Status, a.Remarks, 
            u.FullName AS RecordedBy
            FROM Attendance a
            LEFT JOIN Users u ON a.RecordedBy = u.UserID
            WHERE a.StudentID = @StudentID 
            AND a.AttendanceDate BETWEEN @StartDate AND @EndDate
            ORDER BY a.AttendanceDate DESC";

        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@StudentID", studentId),
            new SqlParameter("@StartDate", startDate),
            new SqlParameter("@EndDate", endDate)
        };

        DataTable dt = Database.ExecuteQuery(query, parameters);

        // Configure the GridView
        gvReport.Columns.Clear();

        gvReport.Columns.Add(new BoundField { HeaderText = "Date", DataField = "AttendanceDate", DataFormatString = "{0:MM/dd/yyyy}" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Status", DataField = "Status" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Remarks", DataField = "Remarks" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Recorded By", DataField = "RecordedBy" });

        gvReport.DataSource = dt;
        gvReport.DataBind();

        // Set report title
        string title = "Attendance Report for " + studentName + " (" + studentCode + ")";
        title += "<br/>Class: " + studentClass;
        title += "<br/>Period: " + startDate.ToString("MM/dd/yyyy") + " to " + endDate.ToString("MM/dd/yyyy");
        litReportTitle.Text = title;

        // Calculate summary
        int totalDays = dt.Rows.Count;
        int present = dt.Select("Status = 'Present'").Length;
        int absent = dt.Select("Status = 'Absent'").Length;
        int late = dt.Select("Status = 'Late'").Length;

        decimal attendanceRate = totalDays > 0 ? (decimal)(present + late) / totalDays * 100 : 0;

        lblTotalStudents.Text = "1";
        lblTotalPresent.Text = present.ToString();
        lblTotalAbsent.Text = absent.ToString();
        lblTotalLate.Text = late.ToString();
        lblAttendanceRate.Text = attendanceRate.ToString("0.00") + "%";

        // Show panels
        pnlReportResults.Visible = true;
        pnlSummary.Visible = true;
    }

    private void GenerateClassReport(string className, DateTime startDate, DateTime endDate)
    {
        string query = @"
            SELECT s.StudentCode, s.FirstName, s.LastName,
            COUNT(a.AttendanceID) AS TotalDays,
            SUM(CASE WHEN a.Status = 'Present' THEN 1 ELSE 0 END) AS Present,
            SUM(CASE WHEN a.Status = 'Absent' THEN 1 ELSE 0 END) AS Absent,
            SUM(CASE WHEN a.Status = 'Late' THEN 1 ELSE 0 END) AS Late,
            CAST(CAST(SUM(CASE WHEN a.Status IN ('Present', 'Late') THEN 1 ELSE 0 END) AS FLOAT) / 
            CASE WHEN COUNT(a.AttendanceID) = 0 THEN 1 ELSE COUNT(a.AttendanceID) END * 100 AS DECIMAL(5,2)) AS AttendanceRate
            FROM Students s
            LEFT JOIN Attendance a ON s.StudentID = a.StudentID 
            AND a.AttendanceDate BETWEEN @StartDate AND @EndDate
            WHERE s.Class = @ClassName AND s.Status = 1
            GROUP BY s.StudentCode, s.FirstName, s.LastName
            ORDER BY s.FirstName, s.LastName";

        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@ClassName", className),
            new SqlParameter("@StartDate", startDate),
            new SqlParameter("@EndDate", endDate)
        };

        DataTable dt = Database.ExecuteQuery(query, parameters);

        // Configure the GridView
        gvReport.Columns.Clear();

        gvReport.Columns.Add(new BoundField { HeaderText = "Student ID", DataField = "StudentCode" });
        gvReport.Columns.Add(new BoundField { HeaderText = "First Name", DataField = "FirstName" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Last Name", DataField = "LastName" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Total Days", DataField = "TotalDays" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Present", DataField = "Present" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Absent", DataField = "Absent" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Late", DataField = "Late" });
        gvReport.Columns.Add(new BoundField { HeaderText = "Attendance Rate", DataField = "AttendanceRate", DataFormatString = "{0}%" });

        gvReport.DataSource = dt;
        gvReport.DataBind();

        // Set report title
        string title = "Class Attendance Report for " + className;
        title += "<br/>Period: " + startDate.ToString("MM/dd/yyyy") + " to " + endDate.ToString("MM/dd/yyyy");
        litReportTitle.Text = title;

        // Calculate summary
        int totalStudents = dt.Rows.Count;
        int totalDays = 0;
        int totalPresent = 0;
        int totalAbsent = 0;
        int totalLate = 0;

        foreach (DataRow row in dt.Rows)
        {
            totalDays += Convert.ToInt32(row["TotalDays"]);
            totalPresent += Convert.ToInt32(row["Present"]);
            totalAbsent += Convert.ToInt32(row["Absent"]);
            totalLate += Convert.ToInt32(row["Late"]);
        }

        decimal attendanceRate = totalDays > 0 ? (decimal)(totalPresent + totalLate) / totalDays * 100 : 0;

        lblTotalStudents.Text = totalStudents.ToString();
        lblTotalPresent.Text = totalPresent.ToString();
        lblTotalAbsent.Text = totalAbsent.ToString();
        lblTotalLate.Text = totalLate.ToString();
        lblAttendanceRate.Text = attendanceRate.ToString("0.00") + "%";

        // Show panels
        pnlReportResults.Visible = true;
        pnlSummary.Visible = true;
    }
}