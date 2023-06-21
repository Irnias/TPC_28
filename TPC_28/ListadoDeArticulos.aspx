<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoDeArticulos.aspx.cs" Inherits="TPC_28.ListadoDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="column">
            <asp:GridView runat="server" DataKeyNames="ArtId" ID="dgvListaArticulos" onSelectedIndexChanged="dgvListaArticulos_SelectedIndexChanged" cssClass="table table-warning table-striped" AutoGenerateColumns="false">
            <Columns>
               <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
               <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
               <asp:BoundField HeaderText="Marca" DataField="Nombre" />
               <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
               <asp:BoundField HeaderText="Precio" DataField="Precio" />
               <asp:CommandField ShowSelectButton="true" SelectText="Modificar Articulo" HeaderText="Accion" />
            </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:Button Text="Agregar Articulo" runat="server" ID="btnAgregarArticulos" class="btn btn-primary" OnClick="btnAgregarArticulos_Click" />

</asp:Content>
