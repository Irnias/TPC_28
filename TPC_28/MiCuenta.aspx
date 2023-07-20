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

    <div class="col-md-8">
        <div class="card mb-3">
            <div class="card-body">
                <div class="row">
                    <div class="col-sm-3">
                        <h6 class="mb-0">Nombre</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                        <asp:Label Text="" ID="lblNombre" runat="server" CssClass="label-linda" />
                    </div>
                </div>
                <hr>
                <div class="row">
                    <div class="col-sm-3">
                        <h6 class="mb-0">Apellido</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                        <asp:Label Text="" ID="lblApellido" runat="server" CssClass="label-linda" />
                    </div>
                </div>
                <hr>
                <div class="row">
                    <div class="col-sm-3">
                        <h6 class="mb-0">Email</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                        <asp:Label Text="" ID="lblMail" runat="server" CssClass="label-linda" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:Label Text="Info de Envio" runat="server" CssClass="label-linda" />
        <asp:Label Text="" ID="lblCalle" runat="server" CssClass="label-linda" />
        <asp:Label Text="" ID="lblNumero" runat="server" CssClass="label-linda" />
        <asp:Label Text="" ID="lblCiudad" runat="server" CssClass="label-linda" />
        <asp:Label Text="" ID="lblCodigoPostal" runat="server" CssClass="label-linda" />
        <asp:Label Text="" ID="lblPais" runat="server" />
        <asp:Label ID="lblTipoEnvio" runat="server" CssClass="label-linda" />

    </div>



</asp:Content>
