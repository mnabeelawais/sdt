<%@ Page Title="Services" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="asignment3n.Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .services-section {
            max-width: 1000px;
            margin: 0 auto;
            padding: 30px;
        }

        .services-section h1 {
            text-align: center;
            color: #1E88E5;
            margin-bottom: 40px;
        }

        .service-cards {
            display: flex;
            flex-wrap: wrap;
            text-justify:auto;
            margin-left: 25px;
        }

        .card {
            background-color: white;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            width: 280px;
            transition: transform 0.3s;
        }

        .card:hover {
            transform: translateY(-5px);
        }

        .card h3 {
            color: #333;
            margin-bottom: 10px;
        }

        .card p {
            color: #666;
            font-size: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="services-section">
        <h1>Our Services</h1>
        <div class="service-cards">
            <div class="card">
                <h3>Web Development</h3>
                <p>Custom websites built with modern technologies to bring your ideas to life.</p>
            </div>
            <div class="card">
                <h3>Mobile App Design</h3>
                <p>Beautiful and functional mobile app interfaces for Android and iOS platforms.</p>
            </div>
            <div class="card">
                <h3>SEO Optimization</h3>
                <p>Boost your online presence and reach your audience through smart SEO strategies.</p>
            </div>
        </div>
    </div>
</asp:Content>
