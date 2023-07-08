<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarArticulos.aspx.cs" Inherits="TPC_28.AgregarArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                        <asp:TextBox runat="server" ID="txtNombreMarca" class="form-control" />
                    </div>
                    <asp:Button Text="Guardar" ID="BtnGuardar" OnClick="BtnGuardar_Click" runat="server" CssClass="btn btn-outline-primary" />
                    <asp:Button Text="Cancelar" ID="BtnCancelar" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-outline-secondary" />
                </asp:Panel>
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-outline-warning" />
                <asp:Label ID="lblConfirmacion" runat="server" Visible="false" CssClass="text-success font-weight-bold"></asp:Label>
                <asp:Label ID="lblModificarMas" runat="server" Visible="false" CssClass="text-success font-weight-bold"></asp:Label>
            </div>
             <asp:Button Text="Agregar otro articulo" runat="server" ID="btnAgregarMas" OnClick="btnAgregarMas_Click" CssClass="btn btn-outline-warning" Visible="false" />
             <asp:Button Text="Modificar otro articulo" runat="server" ID="btnModificarMas" OnClick="btnModificarMas_Click" CssClass="btn btn-outline-warning" Visible="false" />
                <div class="mb-3">
                <asp:CheckBox Text="¿Eliminar?" runat="server" ID="chkEliminacion" AutoPostBack="true" OnCheckedChanged="chkEliminacion_CheckedChanged" />

                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" CssClass="btn btn-outline-danger" Visible="false" />
                <asp:Label runat="server" ID="lblConfirmaEliminacion" Visible ="false" CssClass="text-success font-weight-bold"></asp:Label>
                </div>
             <asp:Button Text="Ir a Listado De Articulos" ID="btnListado" runat="server" CssClass="btn btn-outline-primary" visible="false" OnClick="btnListado_Click"/>
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
                        <asp:TextBox runat="server" ID="txtNombreCategoria" class="form-control" />
                    </div>
                    <asp:Button Text="Guardar" ID="Button2" OnClick="BtnCategoriaGuardar_Click" runat="server" CssClass="btn btn-outline-primary" />
                    <asp:Button Text="Cancelar" ID="Button3" OnClick="BtnCategoriaCancelar_Click" runat="server" CssClass="btn btn-outline-secondary" />
                </asp:Panel>


            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:Label runat="server" ID="lblErrorPrecio" CssClass="text-danger"></asp:Label>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">

                        <label for="txtImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://cdn-icons-png.flaticon.com/512/5798/5798294.png"
                        runat="server" ID="imgArticulo" Width="40%" />
                    <%--                    <img src="<% =imagenUrl %>" alt="" Width="40%" />--%>
                    <div>
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>



        </div>

    </div>

</asp:Content>
