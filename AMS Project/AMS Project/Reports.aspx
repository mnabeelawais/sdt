<%@ Page Title="Attendance Reports" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Reports" Codebehind="Reports.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Attendance Reports</h2>
    
    <div>
        <div class="form-group">
            <label for="ddlReportType">Report Type:</label>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                <asp:ListItem Text="Select Report Type" Value=""></asp:ListItem>
                <asp:ListItem Text="Daily Attendance" Value="Daily"></asp:ListItem>
                <asp:ListItem Text="Student Attendance" Value="Student"></asp:ListItem>
                <asp:ListItem Text="Class Attendance" Value="Class"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvReportType" runat="server" 
                ControlToValidate="ddlReportType" ErrorMessage="Report type is required" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        
        <asp:Panel ID="pnlDailyReport" runat="server" Visible="false">
            <div class="form-group">
                <label for="txtDailyDate">Date:</label>
                <asp:TextBox ID="txtDailyDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDailyDate" runat="server" 
                    ControlToValidate="txtDailyDate" ErrorMessage="Date is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="DailyReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="ddlDailyClass">Class (Optional):</label>
                <asp:DropDownList ID="ddlDailyClass" runat="server" CssClass="form-control">
                    <asp:ListItem Text="All Classes" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="form-group">
                <asp:Button ID="btnGenerateDailyReport" runat="server" Text="Generate Report" CssClass="btn" 
                    OnClick="btnGenerateDailyReport_Click" ValidationGroup="DailyReport" />
            </div>
        </asp:Panel>
        
        <asp:Panel ID="pnlStudentReport" runat="server" Visible="false">
            <div class="form-group">
                <label for="ddlStudent">Student:</label>
                <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Student" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStudent" runat="server" 
                    ControlToValidate="ddlStudent" ErrorMessage="Student is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="txtStudentStartDate">Start Date:</label>
                <asp:TextBox ID="txtStudentStartDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStudentStartDate" runat="server" 
                    ControlToValidate="txtStudentStartDate" ErrorMessage="Start date is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="txtStudentEndDate">End Date:</label>
                <asp:TextBox ID="txtStudentEndDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStudentEndDate" runat="server" 
                    ControlToValidate="txtStudentEndDate" ErrorMessage="End date is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <asp:Button ID="btnGenerateStudentReport" runat="server" Text="Generate Report" CssClass="btn" 
                    OnClick="btnGenerateStudentReport_Click" ValidationGroup="StudentReport" />
            </div>
        </asp:Panel>
        
        <asp:Panel ID="pnlClassReport" runat="server" Visible="false">
            <div class="form-group">
                <label for="ddlClass">Class:</label>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Class" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvClass" runat="server" 
                    ControlToValidate="ddlClass" ErrorMessage="Class is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="ClassReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="txtClassStartDate">Start Date:</label>
                <asp:TextBox ID="txtClassStartDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClassStartDate" runat="server" 
                    ControlToValidate="txtClassStartDate" ErrorMessage="Start date is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="ClassReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="txtClassEndDate">End Date:</label>
                <asp:TextBox ID="txtClassEndDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClassEndDate" runat="server" 
                    ControlToValidate="txtClassEndDate" ErrorMessage="End date is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="ClassReport"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <asp:Button ID="btnGenerateClassReport" runat="server" Text="Generate Report" CssClass="btn" 
                    OnClick="btnGenerateClassReport_Click" ValidationGroup="ClassReport" />
            </div>
        </asp:Panel>
    </div>
    
    <asp:Panel ID="pnlReportResults" runat="server" Visible="false">
        <h3><asp:Literal ID="litReportTitle" runat="server"></asp:Literal></h3>
        
        <div style="margin-bottom: 10px;">
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn" 
                OnClientClick="window.print(); return false;" />
        </div>
        
        <asp:GridView ID="gvReport" runat="server" CssClass="grid" AutoGenerateColumns="False"
            EmptyDataText="No data found for the selected criteria.">
        </asp:GridView>
        
        <asp:Panel ID="pnlSummary" runat="server" Visible="false" Style="margin-top: 20px; padding: 10px; background-color: #f9f9f9; border: 1px solid #ddd;">
            <h4>Summary</h4>
            <div class="form-group">
                <label>Total Students:</label>
                <asp:Label ID="lblTotalStudents" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>Present:</label>
                <asp:Label ID="lblTotalPresent" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>Absent:</label>
                <asp:Label ID="lblTotalAbsent" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>Late:</label>
                <asp:Label ID="lblTotalLate" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>Attendance Rate:</label>
                <asp:Label ID="lblAttendanceRate" runat="server"></asp:Label>
            </div>
        </asp:Panel>
    </asp:Panel>
</asp:Content>