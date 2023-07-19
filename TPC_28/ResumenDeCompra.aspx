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

        .custom-label {
            font-weight: bold;
            font-family: Arial, sans-serif;
            font-size: 14px;
            color: #333;
        }

        .cajita {
            width: 150px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
            color: #333;
            background-color: #f9f9f9;
        }

        .form-container {
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 20px;
            width: 300px;
        }

        .small-textbox {
            width: 150px;
            height: 20px;
            padding: 5px;
            font-size: 14px;
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
                            <h3 class="fw-normal mb-0 text-black">Finalizar compra</h3>
                        </div>
                        <asp:Repeater runat="server" ID="repRepetidorCarrito">
                            <ItemTemplate>
                                <div class="card">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <img src='<%# Eval("Imagenes[0].ImageUrl") %>' alt="Imagen del producto <%#Eval("Nombre") %>" />
                                            </div>
                                            <div class="col-md-9">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <p class="lead fw-normal mb-2"><%#Eval("Nombre") %></p>
                                                        <p><span class="text-muted">Marca: </span><%#Eval("Marca") %></p>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <p><span class="text-muted">Cantidad: </span><%#Eval("Cantidad") %></p>
                                                        <p><span class="text-muted">Precio Unitario: </span><%#Eval("Precio") %></p>
                                                        <p><span class="text-muted">Precio Total: </span><%# (Convert.ToDouble(Eval("Cantidad")) * Convert.ToDouble(Eval("Precio"))).ToString("0.00") %></p>
                                                    </div>
                                                </div>
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
                        <div style="border: 1px solid #ccc; padding: 10px; width: 500px; display: flex">
                            <div style="display: inline-block; border: 1px solid #ccc; padding: 10px; width: 240px;">
                                <div class="mb-3">
                                    <asp:Label Text="Forma de pago" runat="server" CssClass="custom-label" />
                                    <asp:DropDownList ID="ddlFormaDePago" runat="server" CssClass="form-select" Style="width: 200px;"></asp:DropDownList>
                                </div>
                            </div>
                            <div style="display: inline-block; border: 1px solid #ccc; padding: 10px; width: 240px;">
                                <div class="mb-3">
                                    <asp:Label Text="Envio" runat="server" CssClass="custom-label" />
                                    <asp:DropDownList ID="ddlEnvio" runat="server" CssClass="form-select" Style="width: 200px;"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div style="margin-top: 10px;">
                            <asp:Label Text="Formulario de Envio:" runat="server" CssClass="total-label" Visible="false" />
                        </div>
                        <div cssclass="form-container">

                            <div style="margin-top: 10px;">
                                <asp:TextBox ID="txtDomicilio" runat="server" class="cajita" Placeholder="Domicilio - Calle" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtNumero" runat="server" class="cajita" Placeholder="Numero" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtPiso" runat="server" class="cajita" Placeholder="Piso" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtDepartamento" runat="server" class="cajita" Placeholder="Departamento" Visible="false"></asp:TextBox>
                            </div>
                            <div style="margin-top: 10px;">

                                <asp:TextBox ID="txtCodigoPostal" runat="server" class="cajita" Placeholder="Codigo Postal" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtCiudad" runat="server" class="cajita" Placeholder="Ciudad" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtPais" runat="server" class="cajita" Placeholder="Pais" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                        <div style="margin-top: 10px;">
                            <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-primary" ID="Aceptar" OnClick="Aceptar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

