<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.Login" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
        <link href="../Css/Login.css" rel="stylesheet" />
        <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
        <!------ Include the above in your HEAD tag ---------->

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="login-reg-panel">
            <div class="login-info-box">
                <h2>Have an account?</h2>
                <p>Lorem ipsum dolor sit amet</p>
                <label id="label-register" for="log-reg-show">Login</label>
                <input type="radio" name="active-log-panel" id="log-reg-show" checked="checked">
            </div>

            <div class="register-info-box">
                <h2>Don't have an account?</h2>
                <p>Lorem ipsum dolor sit amet</p>
                <label id="label-login" for="log-login-show">Register</label>
                <input type="radio" name="active-log-panel" id="log-login-show">
            </div>

            <div class="white-panel">
                <div class="login-show">
                    <br />
                    <br />
                    <br />
                    <br />
                    <h2>LOGIN</h2>
                    <asp:TextBox ID="txtlogin" runat="server" placeholder="Usuario" CssClass="text"></asp:TextBox>
                    <asp:TextBox ID="txtcontrasena" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="text"></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />
                    <asp:HyperLink ID="lnkForgotPassword" runat="server" Text="Forgot password?" NavigateUrl="#" CssClass="forgot-password-link"></asp:HyperLink>
                </div>
                <div class="register-show">
                    <h2>REGISTER</h2>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Nombre de usuario" CssClass="text"></asp:TextBox>
                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="Nombre" CssClass="text"></asp:TextBox>
                    <asp:TextBox ID="txtLastName" runat="server" placeholder="Apellidos" CssClass="text"></asp:TextBox>
                    <asp:TextBox ID="txtsecunName" runat="server" placeholder="Apellidos" CssClass="text"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="text"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="text"></asp:TextBox>
                    <asp:Button ID="btnSubmit" runat="server" Text="Registrarse" OnClick="btnSubmit_Click" CssClass="button" />
                </div>
            </div>
        </div>
    </main>
    <script>
        $(document).ready(function () {
            $('.login-info-box').fadeOut();
            $('.login-show').addClass('show-log-panel');
        });


        $('.login-reg-panel input[type="radio"]').on('change', function () {
            if ($('#log-login-show').is(':checked')) {
                $('.register-info-box').fadeOut();
                $('.login-info-box').fadeIn();

                $('.white-panel').addClass('right-log');
                $('.register-show').addClass('show-log-panel');
                $('.login-show').removeClass('show-log-panel');

            }
            else if ($('#log-reg-show').is(':checked')) {
                $('.register-info-box').fadeIn();
                $('.login-info-box').fadeOut();

                $('.white-panel').removeClass('right-log');

                $('.login-show').addClass('show-log-panel');
                $('.register-show').removeClass('show-log-panel');
            }
        }); 
    </script>
</asp:Content>
