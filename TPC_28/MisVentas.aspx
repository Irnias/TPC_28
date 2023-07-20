<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisVentas.aspx.cs" Inherits="TPC_28.MisVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mis ventas</h2>
    <div class="row">
        <div class="column">
            <asp:GridView runat="server" DataKeyNames="ventas" ID="dgvListaVentas"
                OnSelectedIndexChanged="dgvListaVentas_SelectedIndexChanged" CssClass="table table-warning table-striped"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvListaVentas_PageIndexChanging"
                AllowPaging="true" PageSize="6">
                <Columns>
                    <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
                    <asp:BoundField DataField="InfoExtra" HeaderText="Información Extra" />
                    <asp:BoundField DataField="CodigoEnvio" HeaderText="Código de Envío" />
                    <asp:BoundField DataField="Calle" HeaderText="Calle de Envío" />
                    <asp:BoundField DataField="ENumero" HeaderText="Número de Envío" />
                    <asp:BoundField DataField="TipoPago" HeaderText="Tipo de Pago" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
