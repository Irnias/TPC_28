﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarArticulos.aspx.cs" Inherits="TPC_28.AgregarArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="TxtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcionLarga" class="form-label">Descripcion Larga</label>
                <asp:TextBox runat="server" ID="txtDescripcionLarga" CssClass="form-control" TextMode="MultiLine" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-outline-warning" />
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen</label>
                <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control"
                    AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" />
            </div>
            <asp:Image ImageUrl="https://cdn-icons-png.flaticon.com/512/5798/5798294.png"
                runat="server" ID="imgArticulo" width="50%" />


        </div>

    </div>


</asp:Content>