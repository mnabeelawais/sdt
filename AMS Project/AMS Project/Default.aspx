<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Dashboard</h2>
    
    <div class="dashboard">
        <div class="card">
            <h3>Students</h3>
            <p>Total Students: <asp:Label ID="lblTotalStudents" runat="server" Text="0"></asp:Label></p>
            <p>Active Students: <asp:Label ID="lblActiveStudents" runat="server" Text="0"></asp:Label></p>
            <p><asp:HyperLink ID="lnkManageStudents" runat="server" NavigateUrl="~/ManageStudents.aspx">Manage Students</asp:HyperLink></p>
        </div>
        
        <div class="card">
            <h3>Today's Attendance</h3>
            <p>Present: <asp:Label ID="lblPresentToday" runat="server" Text="0"></asp:Label></p>
            <p>Absent: <asp:Label ID="lblAbsentToday" runat="server" Text="0"></asp:Label></p>
            <p>Attendance Rate: <asp:Label ID="lblAttendanceRate" runat="server" Text="0%"></asp:Label></p>
            <p><asp:HyperLink ID="lnkMarkAttendance" runat="server" NavigateUrl="~/MarkAttendance.aspx">Mark Attendance</asp:HyperLink></p>
        </div>
        
        <div class="card">
            <h3>Quick Actions</h3>
            <ul>
                <li><asp:HyperLink ID="lnkTakeAttendance" runat="server" NavigateUrl="~/MarkAttendance.aspx">Take Attendance</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkAddStudent" runat="server" NavigateUrl="~/ManageStudents.aspx?action=add">Add New Student</asp:HyperLink></li>
                <li><asp:HyperLink ID="lnkGenerateReport" runat="server" NavigateUrl="~/Reports.aspx">Generate Reports</asp:HyperLink></li>
            </ul>
        </div>
    </div>
    
    <h3>Recent Attendance Records</h3>
    <asp:GridView ID="gvRecentAttendance" runat="server" CssClass="grid" AutoGenerateColumns="False"
        EmptyDataText="No recent attendance records found.">
        <Columns>
            <asp:BoundField DataField="StudentCode" HeaderText="Student ID" />
            <asp:BoundField DataField="FullName" HeaderText="Student Name" />
            <asp:BoundField DataField="AttendanceDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
        </Columns>
    </asp:GridView>
</asp:Content>