<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_28.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
    .h-custom {
        height: calc(100% - 100px);
    }
    @media (max-width: 450px) {
        .h-custom {
            height: 100%;
        }
    }
    .vh-90{
        height: 90vh!important;
    }
</style>

<section class="vh-90">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">

      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://www.go.ooo/img/bg-img/Login.jpg" class="img-fluid" alt="Imagen de Login"/>
      </div>

      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
          <div class="form-outline mb-4">
            <asp:TextBox runat="server" type="email" id="txtMail" class="form-control form-control-lg"
              placeholder="Ingresa tu email" />
            <label class="form-label" for="txtMail">Email</label>
          </div>
          <div class="form-outline mb-3">
            <asp:TextBox runat="server" type="password" id="txtContrasenia" class="form-control form-control-lg"
              placeholder="Ingresa tu contraseña" />
            <label class="form-label" for="txtContrasenia">Contraseña</label>
          </div>

          <div class="d-flex justify-content-between align-items-center">
            <a href="#!" class="text-body">Olvidste tu contraseña?</a>
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
            <asp:Button Text="Logear" runat="server" ID="btnLogin" OnClick="btnLogin_Click" type="button" class="btn btn-outline-primary btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;" />
            <p class="small fw-bold mt-2 pt-1 mb-0">Aun no tenes cuenta? <a href="#!"
                class="link-success">Registrate</a></p>
          </div>
      </div>

    </div>
  </div>
</section>

</asp:Content>