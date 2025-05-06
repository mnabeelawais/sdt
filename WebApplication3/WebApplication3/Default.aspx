<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>City, State, Country Grid</title>
    <style type="text/css">
        .styled-dropdown {
            margin: 10px;
            padding: 5px;
        }
        .styled-grid {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" CssClass="styled-dropdown" Width="200px" BackColor="#f8f8f8" BorderColor="#ccc" BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="12px"></asp:DropDownList>
            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" CssClass="styled-dropdown" Width="200px" BackColor="#f8f8f8" BorderColor="#ccc" BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="12px"></asp:DropDownList>
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" CssClass="styled-dropdown" Width="200px" BackColor="#f8f8f8" BorderColor="#ccc" BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="12px"></asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="styled-grid" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>