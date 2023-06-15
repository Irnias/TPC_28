<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_28.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Holis Inicio
    </h2>

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"></asp:GridView>


    <asp:Button Text="Ver mas" ID="verMas" class="btn btn-danger" runat="server" OnClick="verMas_Click" />

    <asp:Button Text=" Ir al Carrito" ID="irCarrito" runat="server" class="btn btn-primary" OnClick="irCarrito_Click" />
</asp:Content>
