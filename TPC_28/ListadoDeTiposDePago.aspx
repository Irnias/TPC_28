<%@ Page Title="Admin - Tipos De Pago" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoDeTiposDePago.aspx.cs" Inherits="TPC_28.ListadoTiposDePago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="column">
            <asp:GridView runat="server" DataKeyNames="Id" ID="dgvListaTiposDePago"
                OnSelectedIndexChanged="dgvListaTiposDePago_SelectedIndexChanged" CssClass="table table-warning table-striped"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvListaTiposDePago_PageIndexChanging"
                AllowPaging="true" PageSize="6">
                <Columns>
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Eliminar Tipo De Pago" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
             <asp:Panel ID="ListaTiposDePagoPopup" runat="server" CssClass="popup">
                <h2>Nuevo Tipo De Pago</h2>
                <div class="form-group">
                    <label for="txtNombreTipoDePago" class="form-label">Nombre:</label>
                    <asp:TextBox runat="server" ID="txtNombreTipoDePago" class="form-control" />
                </div>
                <asp:Button Text="Guardar" ID="Button2" OnClick="BtnTipoPagoGuardar_Click" runat="server" CssClass="btn btn-outline-primary" />
                <asp:Button Text="Cancelar" ID="Button3" OnClick="BtnTipoPagoCancelar_Click" runat="server" CssClass="btn btn-outline-secondary" />
            </asp:Panel>
        </div>
    </div>
    <asp:Button Text="Agregar Tipo De Pago" runat="server" ID="btnAgregarTipoPago" class="btn btn-primary" OnClick="Agregar_TipoPago" />

</asp:Content>
