<%@ Page Title="Manage Students" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageStudents.aspx.cs" Inherits="ManageStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Students</h2>
    
    <asp:Panel ID="pnlStudentList" runat="server">
        <div style="margin-bottom: 10px;">
            <asp:Button ID="btnAddNew" runat="server" Text="Add New Student" CssClass="btn" 
                OnClick="btnAddNew_Click" Visible="false" />
            
            <div style="float: right;">
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by name or ID" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" 
                    OnClick="btnSearch_Click" />
            </div>
            <div style="clear: both;"></div>
        </div>
        
        <asp:GridView ID="gvStudents" runat="server" CssClass="grid" AutoGenerateColumns="False"
            DataKeyNames="StudentID" OnRowCommand="gvStudents_RowCommand"
            EmptyDataText="No students found.">
            <Columns>
                <asp:BoundField DataField="StudentCode" HeaderText="Student ID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditStudent" 
                            CommandArgument='<%# Eval("StudentID") %>' Text="Edit"></asp:LinkButton> |
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteStudent" 
                            CommandArgument='<%# Eval("StudentID") %>' Text="Delete" 
                            OnClientClick="return confirm('Are you sure you want to delete this student?');"
                            Visible='<%# Session["Role"].ToString() == "Admin" %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <div style="margin-top: 10px;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlStudentForm" runat="server" Visible="false">
        <h3><asp:Literal ID="litFormTitle" runat="server"></asp:Literal></h3>
        
        <div>
            <asp:HiddenField ID="hdnStudentID" runat="server" />
            
            <div class="form-group">
                <label for="txtStudentCode">Student ID:</label>
                <asp:TextBox ID="txtStudentCode" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStudentCode" runat="server" 
                    ControlToValidate="txtStudentCode" ErrorMessage="Student ID is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentForm"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="txtFirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="First Name is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentForm"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="txtLastName">Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="Last Name is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentForm"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="ddlGender">Gender:</label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Gender" Value=""></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGender" runat="server" 
                    ControlToValidate="ddlGender" ErrorMessage="Gender is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentForm"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="ddlClass">Class:</label>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvClass" runat="server" 
                    ControlToValidate="ddlClass" ErrorMessage="Class is required" 
                    ForeColor="Red" Display="Dynamic" ValidationGroup="StudentForm"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label for="chkStatus">Status:</label>
                <asp:CheckBox ID="chkStatus" runat="server" Text="Active" Checked="true" />
            </div>
            
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" 
                    OnClick="btnSave_Click" ValidationGroup="StudentForm" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" 
                    OnClick="btnCancel_Click" CausesValidation="false" />
            </div>
            
            <div>
                <asp:Label ID="lblFormMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
    </asp:Panel>
</asp:Content>