<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ResumenDeCompra.aspx.cs" Inherits="TPC_28.ResumenDeCompra" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .main-container {
            background-color: #ffa040;
            padding-top: 20px;
            padding-bottom: 20px;
        }

        .card {
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }

        .card-body {
            padding: 20px;
        }

        .card-body p {
            margin-bottom: 10px;
        }

        .card-body img {
            max-width: 100%;
            height: auto;
            border-radius: 4px;
            display: block;
            margin: 0 auto;
            max-height: 100px;
        }

        .badge {
            background-color: #f0ad4e;
            color: #fff;
            font-size: 14px;
            padding: 4px 8px;
            border-radius: 4px;
        }

        .total-label {
            font-weight: bold;
            margin-top: 10px;
        }

        .total-price {
            font-size: 20px;
            color: #f0ad4e;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <asp:Label ID="lblUsuarioNombre" runat="server"></asp:Label>

        <section>
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="mb-4">
                            <h3 class="fw-normal mb-0 text-black">Resumen de compra</h3>
                        </div>
                        <asp:Repeater runat="server" ID="repRepetidorCarrito">
                            <ItemTemplate>
                                <div class="card">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <img src='<%# Eval("Imagenes[0].ImageUrl") %>' alt="Imagen del producto <%#Eval("Nombre") %>" />
                                            </div>
                                            <div class="col-md-6">
                                                <p class="lead fw-normal mb-2"><%#Eval("Nombre") %></p>
                                                <p><span class="text-muted">Categoría: </span><%#Eval("Categoria")%> <span class="text-muted">Marca: </span><%#Eval("Marca") %></p>
                                            </div>
                                            <div class="col-md-3">
                                                <span class="badge"><%#Eval("Cantidad") %></span>
                                                <h5 class="mb-0">$<%#Eval("Precio") %></h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="card">
                            <div class="card-body">
                                <asp:Label Text="Total a pagar:" runat="server" CssClass="total-label" />
                                <asp:Label ID="lblTotal" runat="server" CssClass="total-price"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

