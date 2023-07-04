<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_28.Inicio" %>


<%@ MasterType VirtualPath="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Holis Inicio
    </h2>

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"></asp:GridView>

    <div class="row row-cols-1 row-cols-md-3 g-4">

            <asp:Repeater runat="server" ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">

            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("Imagenes")%>" class="card-img-top" alt="<%#Eval("Nombre")%>-foto" onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("ArtId")%></p>
                            <p class="card-text"><%#Eval("Marca") %></p>
                            <p class="card-text"><%#Eval("Categoria") %></p>
                            <p class="card-text"><%#Eval("Descripcion") %></p>

                            <asp:Label Visible="false" ID="lblArtId" Text='<%#Eval("ArtId")%>' runat="server" />

                            <asp:Button
                                Text="Ver mas"
                                ID="verMas"
                                class="btn btn-outline-secondary"
                                runat="server"
                                OnClick="verMas_Click"
                                CommandArgument='<%#Eval("ArtId")%>'
                                NavigateUrl='<%#"ArtDetalles.aspx?id=" + Eval("ArtId")%>' />

                            <asp:Button
                                Text="Agregado!!"
                                CssClass="btn btn-info"
                                runat="server" ID="btnAgregado"
                                OnClick="btnAgregado_Click"
                                Visible="false" />

                            <asp:Button
                                Text="Agregar al Carrito"
                                ID="btnAgregar"
                                runat="server"
                                class="btn btn-outline-primary"
                                OnClick="btnAgregar_Click"
                                CommandArgument='<%#Eval("ArtId")%> '
                                NavigateUrl='<%#"Carrito.aspx?id=" + Eval("ArtId")%>'
                                UseSubmitBehavior="false"
                                Visible="false" />

                            <asp:Button Text="Eliminar"
                                ID="btnEliminar"
                                runat="server"
                                class="btn btn-danger"
                                OnClick="btnEliminar_Click"
                                CommandArgument='<%#Eval("ArtId")%> '
                                NavigateUrl='<%#"Carrito.aspx?id=" + Eval("ArtId")%>'
                                UseSubmitBehavior="false"
                                Visible="false" />

                            <div>
                                <asp:Button Text="-" ID="btnRestar"
                                    class="btn btn-outline-warning" runat="server"
                                    OnClick="btnRestar_Click"
                                    CommandArgument='<%# Eval("ArtId") %>' />
                                <asp:Button Text="+" ID="btnSumar"
                                    class="btn btn-outline-warning" runat="server"
                                    OnClick="btnSumar_Click"
                                    CommandArgument='<%# Eval("ArtId") %>' />
                            </div>


                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
