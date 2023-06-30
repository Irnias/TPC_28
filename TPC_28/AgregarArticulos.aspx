<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarArticulos.aspx.cs" Inherits="TPC_28.AgregarArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />
    
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">ID del Articulo</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
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
            <div class="row mb-3">    
                <label for="ddlMarca" class="form-label">Marca</label>
                 <div class="col-md-10">
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button Text="+" ID="ButtonAddMarca" OnClick="btnNuevaMarca" runat="server" CssClass="btn btn-outline-primary" />
                </div>
                <asp:Panel ID="marcaPopup" runat="server" CssClass="popup">
                    <h2>Nueva Marca</h2>
                    <div class="form-group">
                        <label for="txtNombreMarca" class="form-label">Nombre:</label>
                        <asp:TextBox runat="server" id="txtNombreMarca" class="form-control" />
                    </div>
                    <asp:Button Text="Guardar" ID="BtnGuardar" OnClick="BtnGuardar_Click" runat="server" CssClass="btn btn-outline-primary" />
                    <asp:Button Text="Cancelar" ID="BtnCancelar" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-outline-secondary" />
                </asp:Panel>
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-outline-warning" />
            </div>
            <div class="mb-3">
            <asp:CheckBox Text="  ¿ Eliminar ?" runat="server" ID="chkEliminacion" />
            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" CssClass="btn btn-outline-danger" />
            </div>
        </div>

        <div class="col-6">
            <div class="row mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                 <div class="col-md-10">
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button Text="+" ID="btnNuevaCategoria" OnClick="Agregar_Categoria" runat="server" CssClass="btn btn-outline-primary" />
                </div>
                <asp:Panel ID="categoriaPopup" runat="server" CssClass="popup">
                    <h2>Nueva Categoria</h2>
                    <div class="form-group">
                        <label for="txtNombreCategoria" class="form-label">Nombre:</label>
                        <asp:TextBox runat="server" id="txtNombreCategoria" class="form-control" />
                    </div>
                    <asp:Button Text="Guardar" ID="Button2" OnClick="BtnCategoriaGuardar_Click" runat="server" CssClass="btn btn-outline-primary" />
                    <asp:Button Text="Cancelar" ID="Button3" OnClick="BtnCategoriaCancelar_Click" runat="server" CssClass="btn btn-outline-secondary" />
                </asp:Panel>


            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <%-- <label for="txtImagen" class="form-label">Id Imagen</label>
                   <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control"
                   AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" />--%>
                <label for="txtImagen" class="form-label">Url Imagen</label>
                <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control" 
                     AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" />
            </div>
            <asp:Image ImageUrl="https://cdn-icons-png.flaticon.com/512/5798/5798294.png"
                runat="server" ID="imgArticulo" Width="40%" />


        </div>

    </div>


</asp:Content>
