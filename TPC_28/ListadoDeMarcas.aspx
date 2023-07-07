<%@ Page Title="Admin - Marcas" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoDeMarcas.aspx.cs" Inherits="TPC_28.ListadoDeMarcas"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="column">
            <asp:GridView runat="server" DataKeyNames="Id" ID="dgvListaMarcas"
                OnSelectedIndexChanged="dgvListaMarcas_SelectedIndexChanged" CssClass="table table-warning table-striped"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvListaMarcas_PageIndexChanging"
                AllowPaging="true" PageSize="6">
                <Columns>
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Eliminar Marca" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
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
    </div>
    <asp:Button Text="Agregar Marca" runat="server" ID="btnAgregarMarca" class="btn btn-primary" OnClick="Agregar_Marca" />

</asp:Content>
