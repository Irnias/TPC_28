<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisVentas.aspx.cs" Inherits="TPC_28.MisVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mis ventas</h2>
    <div class="row">
        <div class="column">    
            <asp:GridView runat="server" DataKeyNames="IdCompra,Estado" ID="dgvListaVentas"
                OnSelectedIndexChanged="dgvListaVentas_SelectedIndexChanged" CssClass="table table-warning table-striped"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvListaVentas_PageIndexChanging"
                AllowPaging="true" PageSize="4">
                <Columns>
                    <asp:BoundField DataField="IdCompra" HeaderText="ID Compra" />
                    <asp:BoundField DataField="Usuario.Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Usuario.Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Usuario.Mail" HeaderText="Mail" />
                    <asp:BoundField DataField="Envio.CodigoEnvio" HeaderText="Código de Envío" />
                    <asp:BoundField DataField="Envio.DireccionEnvio.Calle" HeaderText="Calle de Envío" />
                    <asp:BoundField DataField="Envio.DireccionEnvio.Numero" HeaderText="Número de Envío" />
                    <asp:BoundField DataField="Pago.TipoPago" HeaderText="Tipo de Pago" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado de Compra" /> 
                    <asp:CommandField ShowSelectButton="true" SelectText="Modificar Estado" HeaderText="Modificar" />
                </Columns>
            </asp:GridView>
     
        </div>
    </div>

</asp:Content>
