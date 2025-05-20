using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDashboardData();
            LoadRecentAttendance();
        }
    }

    private void LoadDashboardData()
    {
        // Get total students count
        string totalQuery = "SELECT COUNT(*) FROM Students";
        int totalStudents = Convert.ToInt32(Database.ExecuteScalar(totalQuery));
        lblTotalStudents.Text = totalStudents.ToString();

        // Get active students count
        string activeQuery = "SELECT COUNT(*) FROM Students WHERE Status = 1";
        int activeStudents = Convert.ToInt32(Database.ExecuteScalar(activeQuery));
        lblActiveStudents.Text = activeStudents.ToString();

        // Get today's attendance
        string today = DateTime.Now.ToString("yyyy-MM-dd");

        string presentQuery = "SELECT COUNT(*) FROM Attendance WHERE AttendanceDate = @Today AND Status = 'Present'";
        SqlParameter[] presentParams = new SqlParameter[] { new SqlParameter("@Today", today) };
        int presentToday = Convert.ToInt32(Database.ExecuteScalar(presentQuery, presentParams));
        lblPresentToday.Text = presentToday.ToString();

        string absentQuery = "SELECT COUNT(*) FROM Attendance WHERE AttendanceDate = @Today AND Status = 'Absent'";
        SqlParameter[] absentParams = new SqlParameter[] { new SqlParameter("@Today", today) };
        int absentToday = Convert.ToInt32(Database.ExecuteScalar(absentQuery, absentParams));
        lblAbsentToday.Text = absentToday.ToString();

        // Calculate attendance rate
        if (activeStudents > 0)
        {
            decimal attendanceRate = (decimal)presentToday / activeStudents * 100;
            lblAttendanceRate.Text = attendanceRate.ToString("0.00") + "%";
        }
        else
        {
            lblAttendanceRate.Text = "0.00%";
        }
    }

    private void LoadRecentAttendance()
    {
        string query = @"
            SELECT TOP 10 s.StudentCode, s.FirstName + ' ' + s.LastName AS FullName, 
            a.AttendanceDate, a.Status, a.Remarks
            FROM Attendance a
            INNER JOIN Students s ON a.StudentID = s.StudentID
            ORDER BY a.AttendanceDate DESC, a.RecordedTime DESC";

        DataTable dt = Database.ExecuteQuery(query);
        gvRecentAttendance.DataSource = dt;
        gvRecentAttendance.DataBind();
    }
}