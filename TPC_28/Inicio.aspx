<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_28.Inicio" %>


<%@ MasterType VirtualPath="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="TxtFilter" runat="server"></asp:TextBox>
    <asp:Button ID="BtnFiltro" Text="buscar" class="btn btn-dark" runat="server" OnClick="BtnFiltro_Click" />

    <section style="background-color: #eee;">
        <div class="container py-5">
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater runat="server" ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-6 col-lg-4 mb-4 mb-md-0">

                            <div class="card">
                                <img src='<%# GetFirstImageUrl(Eval("Imagenes")) %>' style="height: 400px; width: 350px" class="card-img-top" alt="Imagen del producto <%#Eval("Nombre") %>"
                                    onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'" />

                                <div class="card-body">
                                    <div class="d-flex justify-content-between">
                                        <p class="small"><a href="#!" class="text-muted"><%#Eval("Descripcion") %></a></p>
                                        <p class="small text-danger"><s>$<%#Eval("PrecioViejo") %></s></p>
                                    </div>

                                    <div class="d-flex justify-content-between mb-3">
                                        <h5 class="mb-0"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Marca") %></p>
                                        <h5 class="text-dark mb-0">$<%#Eval("Precio") %></h5>
                                    </div>

                                    <asp:Label Visible="false" ID="lblArtId" Text='<%#Eval("ArtId")%>' runat="server" />

                                    <asp:Button
                                        Text="Ver mas"
                                        ID="btnVerMas"
                                        class="btn btn-outline-secondary"
                                        runat="server"
                                        OnClick="btnVerMas_Click"
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
                                        <asp:Button Text="Ir al carrito" runat="server"
                                            class="btn btn-outline-warning" ID="btnIrAlCarrito"
                                            OnClick="btnIrAlCarrito_Click" />
                                        <%-- <asp:Button Text="+" ID="btnSumar"
                                            class="btn btn-outline-warning" runat="server"
                                            OnClick="btnSumar_Click"
                                            CommandArgument='<%# Eval("ArtId") %>' />
                                        <asp:Button Text="-" ID="btnRestar"
                                            class="btn btn-outline-success" runat="server"
                                            OnClick="btnRestar_Click"
                                            CommandArgument='<%# Eval("ArtId") %>' />--%>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
