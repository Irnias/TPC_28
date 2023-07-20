<%@ Page Title="Mi Cuenta" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="TPC_28.MiCuenta" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .label-linda {
            font-size: 15px;
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

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card mb-3">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-4">
                                <h6 class="mb-0">Nombre</h6>
                            </div>
                            <div class="col-sm-8 text-secondary">
                                <asp:Label Text="" ID="lblNombre" runat="server" CssClass="label-linda" />
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-sm-4">
                                <h6 class="mb-0">Apellido</h6>
                            </div>
                            <div class="col-sm-8 text-secondary">
                                <asp:Label Text="" ID="lblApellido" runat="server" CssClass="label-linda" />
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-sm-4">
                                <h6 class="mb-0">Email</h6>
                            </div>
                            <div class="col-sm-8 text-secondary">
                                <asp:Label Text="" ID="lblMail" runat="server" CssClass="label-linda" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <h6 class="label-linda">Info de Envio</h6>
                <asp:Label Text="Calle : " ID="lblCalle" runat="server" CssClass="label-linda" Visible="false" />
                <asp:Label Text="Número : " ID="lblNumero" runat="server" CssClass="label-linda" Visible="false" />
                <asp:Label Text="Ciudad : " ID="lblCiudad" runat="server" CssClass="label-linda" Visible="false" />
                <asp:Label Text="Codigo Postal :" ID="lblCodigoPostal" runat="server" CssClass="label-linda" Visible="false" />
                <asp:Label Text=" Pais :" ID="lblPais" runat="server" CssClass="label-linda" Visible="false" />
                <asp:Label ID="lblTipoEnvio" runat="server" CssClass="label-linda" />

            </div>
            <div class="col-md-4">
                <h6 class="label-linda">Forma de Pago</h6>
                <asp:Label Text="" ID="lblFormaPago" runat="server" CssClass="label-linda" />
            </div>
        </div>

        <section>
            <div class="row">
                <div class="col-12">
                    <div class="mb-4">
                        <h3 class="label-linda">Productos en tu carrito</h3>
                    </div>
                    <asp:Repeater runat="server" ID="repRepetidor">
                        <ItemTemplate>
                            <div class="card mb-2">
                                <div class="card-body">
                                    <div class="product-info">
                                        <p><span class="text-muted">Nombre: <%#Eval("Nombre") %></p>
                                        <p><span class="text-muted">Marca: </span><%#Eval("Marca") %></p>
                                        <p><span class="text-muted">Cantidad: </span><%#Eval("Cantidad") %></p>
                                        <p><span class="text-muted">Precio Unitario: </span><%#Eval("Precio") %></p>
                                        <p><span class="text-muted">Precio Total: </span><%# (Convert.ToDouble(Eval("Cantidad")) * Convert.ToDouble(Eval("Precio"))).ToString("0.00") %></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
