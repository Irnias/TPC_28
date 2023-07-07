<%@ Page Title="Admin - Categorias" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoDeCategorias.aspx.cs" Inherits="TPC_28.ListadoDeCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="column">
            <asp:GridView runat="server" DataKeyNames="Id" ID="dgvListaCategoria"
                OnSelectedIndexChanged="dgvListaCategorias_SelectedIndexChanged" CssClass="table table-warning table-striped"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvListaCategoria_PageIndexChanging"
                AllowPaging="true" PageSize="6">
                <Columns>
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Eliminar Categoría" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
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
    </div>
    <asp:Button Text="Agregar Categoria" runat="server" ID="btnAgregarCategoria" class="btn btn-primary" OnClick="Agregar_Categoria" />

</asp:Content>
