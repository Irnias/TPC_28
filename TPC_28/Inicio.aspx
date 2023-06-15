<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_28.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Holis Inicio
    </h2>

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"></asp:GridView>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("Imagenes")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                             <p class="card-text"><%#Eval("Marca") %></p>
                             <p class="card-text"><%#Eval("Categoria") %></p>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:Button Text="Ver mas" ID="verMas" class="btn btn-danger" runat="server" OnClick="verMas_Click" />

    <asp:Button Text=" Ir al Carrito" ID="irCarrito" runat="server" class="btn btn-primary" OnClick="irCarrito_Click" />
</asp:Content>
