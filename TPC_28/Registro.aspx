<%@ Page Title="Registro" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPC_28.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function handleEmailInputChange() {
            var txtMail = document.getElementById('<%= txtMail.ClientID %>');
            txtMail.classList.remove("is-invalid");
        }
        function handlePassInputChange() {
            var txtPass2 = document.getElementById('<%= txtContrasenia2.ClientID %>');
            txtPass2.classList.remove("is-invalid");
        }
    </script>
<style>
    .h-custom {
        height: calc(100%);
    }
    @media (max-width: 450px) {
        .h-custom {
            height: 100%;
        }
    }
    .vh-90{
        height: 110vh!important;
    }
</style>

<section class="vh-90">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
        <h1>Registro</h1>
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://teorema-rd.com/wp-content/uploads/2020/05/user-security-management-header-600x541.png" class="img-fluid" alt="Imagen de Login"/>
      </div>

      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
          <div class="form-outline mb-4">
            <asp:TextBox runat="server" type="email" required id="txtMail" oninput="handleEmailInputChange()" class="form-control form-control-lg"
              placeholder="Ingresa tu email" />
            <label class="form-label" for="txtMail">Email</label>
             
            <div id="txtMailFeedback" class="invalid-feedback">
                <asp:Literal runat="server" ID="lblFeedback" Mode="PassThrough" Text="El mail ya esta registrado!" />
            </div>

          </div>
          <div class="form-outline mb-4">
            <asp:TextBox runat="server" type="text" required id="txtNombre" class="form-control form-control-lg"
              placeholder="Ingresa tu Nombre" />
            <label class="form-label" for="txtNombre">Nombre</label>
          </div>
          <div class="form-outline mb-4">
            <asp:TextBox runat="server" type="text" required id="txtApellido" class="form-control form-control-lg"
              placeholder="Ingresa tu Apellido" />
            <label class="form-label" for="txtApellido">Apellido</label>
          </div>
          <div class="form-outline mb-3">
            <asp:TextBox runat="server" type="password" required id="txtContrasenia" class="form-control form-control-lg"
              placeholder="Ingresa tu contraseña" />
            <label class="form-label" for="txtContrasenia">Contraseña</label>
          </div>
         <div class="form-outline mb-3">
            <asp:TextBox runat="server" type="password" required oninput="handlePassInputChange()" id="txtContrasenia2" class="form-control form-control-lg"
              placeholder="Re-ingresa tu contraseña" />
            <label class="form-label" for="txtContrasenia2">Contraseña</label>
            <div id="txtContrasenia2Feedback" class="invalid-feedback">
                <asp:Literal runat="server" ID="lblFeedback2" Mode="PassThrough" Text="La contraseña no coincide" />
            </div>
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
            <asp:Button Text="Registrar" runat="server" ID="btnRegistro" OnClick="btnRegistro_Click" class="btn btn-outline-primary btn-lg"
            style="padding-left: 2.5rem; padding-right: 2.5rem;" />

            <p class="small fw-bold mt-2 pt-1 mb-0">Ya tenes cuenta? <a href="Login.aspx"
                class="link-success">Logueate!</a></p>
          </div>
      </div>

    </div>
  </div>
</section>


</asp:Content>