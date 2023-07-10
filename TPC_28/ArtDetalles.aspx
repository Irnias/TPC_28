<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArtDetalles.aspx.cs" Inherits="TPC_28.ArtDetalles" %>

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

    <h2>Detalles del Producto!</h2>
    <hr />


    <div style="max-width: 250px; float: left;">
        <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <asp:Repeater ID="imageRepeater" runat="server">
                    <ItemTemplate>
                        <div class="carousel-item active">
                            <img src='<%#Eval("ImageUrl") %>' class="d-block w-100" alt="Imagen del Articulo" onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>

        </div>
    </div>

    <asp:Label Visible="false" ID="lblArtId" Text='<%#Eval("ArtId")%>' runat="server" />

    <div class="col-6" style="margin-left: 20px;">
        <div class="d-flex flex-column">
            <asp:Label Text="" ID="lblBrand" runat="server" CssClass="label-linda" />
            <asp:Label Text="" ID="lblCategory" runat="server" CssClass="label-linda" />
            <asp:Label Text="" ID="lblName" runat="server" CssClass="label-linda" />
        </div>
        <div class="d-flex flex-column">
            <asp:Label Text="" ID="lblDescription" runat="server" CssClass="label-linda" />
            <asp:Label Text="" ID="lblPrice" runat="server" CssClass="label-linda" />
            <asp:Label Text="" ID="lblImg" runat="server" CssClass="label-linda" />
        </div>
        <asp:Button
            Text="Agregar al Carrito"
            ID="btnAgregar"
            runat="server"
            class="btn btn-outline-primary"
            OnClick="btnAgregarArticulo_Click"
            CommandName="AgregarCarrito"
            NavigateUrl='<%#"Carrito.aspx?id=" + Eval("ArtId")%>' />
        <asp:Button Text="Eliminar"
            ID="btnEliminar"
            runat="server"
            class="btn btn-danger"
            OnClick="btnEliminar_Click"
            CommandArgument='<%#Eval("ArtId")%>'
            Visible="false" />
    </div>
    <div>
        <asp:Button Text="Inicio" runat="server" ID="Inicio" OnClick="Inicio_Click" class="btn btn-warning"/>
    </div>
</asp:Content>
