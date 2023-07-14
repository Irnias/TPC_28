<%@ Page Title="Mi Cuenta" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="TPC_28.MiCuenta" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .carousel-item img {
            max-width: 250px;
            max-height: 250px;
        }

        .label-linda {
            font-size: 18px;
            color: #333;
            background-color: #f9f9f9;
            padding: 5px 10px;
            border-radius: 5px;
        }

        body {
            background-color: lightblue;
        }

        .container {
            background-color: #ffffff;
            padding: 30px;
            border-radius: 20px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #333;
            font-size: 24px;
            margin-bottom: 10px;
        }
    </style>

    <h2>Mi Cuenta</h2>
    <hr />


</asp:Content>
