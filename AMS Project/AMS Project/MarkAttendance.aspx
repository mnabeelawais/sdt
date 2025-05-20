<%@ Page Title="Mark Attendance" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="MarkAttendance" Codebehind="MarkAttendance.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mark Attendance</h2>
    
    <div>
        <div class="form-group">
            <label for="txtDate">Date:</label>
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDate" runat="server" 
                ControlToValidate="txtDate" ErrorMessage="Date is required" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <label for="ddlClass">Class:</label>
            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Class" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvClass" runat="server" 
                ControlToValidate="ddlClass" ErrorMessage="Class is required" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnLoadStudents" runat="server" Text="Load Students" CssClass="btn" 
                OnClick="btnLoadStudents_Click" />
        </div>
    </div>
    
    <asp:Panel ID="pnlAttendance" runat="server" Visible="false">
        <h3>Mark Attendance for <asp:Literal ID="litClassDate" runat="server"></asp:Literal></h3>
        
        <asp:Label ID="lblAttendanceStatus" runat="server" ForeColor="Blue" Visible="false"></asp:Label>
        
        <asp:GridView ID="gvAttendance" runat="server" CssClass="grid" AutoGenerateColumns="False"
            DataKeyNames="StudentID" EmptyDataText="No students found in this class.">
            <Columns>
                <asp:BoundField DataField="StudentCode" HeaderText="Student ID" />
                <asp:BoundField DataField="FullName" HeaderText="Student Name" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Present" Value="Present" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                            <asp:ListItem Text="Late" Value="Late"></asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <div style="margin-top: 10px;">
            <asp:Button ID="btnSaveAttendance" runat="server" Text="Save Attendance" CssClass="btn" 
                OnClick="btnSaveAttendance_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>