<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="asignment3n.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .home-container {
            max-width: 800px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.05);
            text-align: center;
        }

        .home-container h1 {
            color: #1E88E5;
            font-size: 36px;
            margin-bottom: 10px;
        }

        .home-container p {
            font-size: 18px;
            color: #555;
            margin-bottom: 25px;
        }

        .btn-learn {
            background-color: #1E88E5;
            color: white;
            padding: 10px 20px;
            text-decoration: none;
            font-size: 16px;
            border-radius: 5px;
            transition: background-color 0.3s;
        }

        .btn-learn:hover {
            background-color: #1565C0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-container">
        <h1>Welcome to My Company</h1>
        <p>
            We provide high-quality services to help you grow your business.
            Explore our offerings and get in touch with us to know more!
        </p>
        <a href="Services.aspx" class="btn-learn">Learn More</a>
    </div>
</asp:Content>
