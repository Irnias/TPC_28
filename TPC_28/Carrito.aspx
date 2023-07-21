<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_28.Carrito" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
        .button-container{
            margin-top:10px;
        }
        body {
            background-color: lightblue;
        }
    </style>

  <asp:Label Text="" ID="probando" runat="server" />

    <section class="h-100" style="background-color: #eee;">
        <div class="container h-100 py-5">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-10">

                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h3 class="fw-normal mb-0 text-black">Shopping Cart</h3>
                    </div>
                    <asp:Repeater runat="server" ID="repRepetidorCarrito">
                        <ItemTemplate>
                            <div class="card rounded-3 mb-4">
                                <div class="card-body p-4">
                                    <div class="row d-flex justify-content-between align-items-center">
                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <img
                                                src='<%# Eval("Imagenes[0].ImageUrl") %>'
                                                class="img-fluid rounded-3"
                                                alt="Imagen del producto <%#Eval("Nombre") %>"
                                                onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'" />
                                        </div>
                                        <div class="col-md-3 col-lg-3 col-xl-3">
                                            <p class="lead fw-normal mb-2"><%#Eval("Nombre") %></p>
                                            <p><span class="text-muted">Categoria: </span><%#Eval("Categoria")%> <span class="text-muted">Marca: </span><%#Eval("Marca") %></p>
                                            <p><span class="text-muted"><%#Eval("Descripcion")%> </span></p>
                                        </div>

                                        <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                            <span class="badge text-bg-light"><%#Eval("Cantidad") %></span>
                                        </div>
                                        

                                        <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                            <asp:Label Visible="false" ID="lblArticleId" Text='<%#Eval("ArtId")%>' runat="server" />
                                            <h5 class="mb-0">$<%#Eval("Precio") %></h5>
                                            <asp:Button Text="-" ID="btnEliminar" class="btn btn-info" runat="server" OnClick="btnEliminar_Click"
                                                CommandArgument='<%# Eval("ArtId") %>' />
                                            <asp:Button Text="+" ID="btnAgregar" class="btn btn-info" runat="server" OnClick="btnAgregar_Click"
                                                CommandArgument='<%# Eval("ArtId") %>' />
                                            <div class="button-container">
                                            <asp:Button Text="Eliminar" ID="btnPeligro" class="btn btn-danger" runat="server" OnClick="btnPeligro_Click"
                                                CommandArgument='<%# Eval("ArtId") %>' />
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="card">
                        <div class="card-body">
                            <asp:Label Text="Total a pagar:" runat="server" />
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                           </div>
                    </div>
                    



                    <div class="card mb-4">
                        <div class="card-body p-4 d-flex flex-row">
                            <div class="form-outline flex-fill">
                                <input type="text" id="form1" class="form-control form-control-lg" />
                                <label class="form-label" for="form1">Discound code</label>
                            </div>
                            <button type="button" class="btn btn-outline-warning btn-lg ms-3">Apply</button>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-body">
                            <asp:Button Text="Finalizar Compra" ID="btnComprar" OnClick="btnComprar_Click" runat="server" class="btn btn-warning" />  
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>




</asp:Content>
