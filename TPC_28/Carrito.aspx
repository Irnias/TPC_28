<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_28.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Estamos en el carrito :P
    </h2>

    <asp:Button Text="Ver mas" ID="verMas" class="btn btn-danger" runat="server" OnClick="verMas_Click" />

    <asp:Button Text="Ir al Inicio" ID="irInicio" class="btn btn-primary" runat="server"  OnClick="irInicio_Click"/>
</asp:Content>
