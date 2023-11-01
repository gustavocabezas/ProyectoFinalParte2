<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.Login" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/Login.css" rel="stylesheet" />
<main>
    <div class="section">
		<div class="container">
			<div class="row full-height justify-content-center">
				<div class="col-12 text-center align-self-center py-5">
					<div class="section pb-5 pt-5 pt-sm-2 text-center">
						<h6 class="mb-0 pb-3"><span>Log In </span><span>Sign Up</span></h6>
			          	<input class="checkbox" type="checkbox" id="reg-log" name="reg-log"/>
			          	<label for="reg-log"></label>
						<div class="card-3d-wrap mx-auto">
							<div class="card-3d-wrapper">
								<div class="card-front">
									<div class="center-wrap">
										<div class="section text-center">
											<h4 class="mb-4 pb-3">Log In</h4>
											<div class="form-group">
												<%--<input type="email" name="logemail" class="form-style" placeholder="Your Email" id="logemail" autocomplete="off">--%>
												<asp:TextBox ID="TextBox2" placeholder="Usuario" class="form-style" runat="server"></asp:TextBox>
												<i class="input-icon uil uil-at"></i>
											</div>	
											<div class="form-group mt-2">
												<%--<input type="password" name="logpass" class="form-style" placeholder="Your Password" id="logpass" autocomplete="off">--%>
												<asp:TextBox ID="TextBox3" placeholder="Contraseña" class="form-style" runat="server"></asp:TextBox>
												<i class="input-icon uil uil-lock-alt"></i>
											</div>
											<%--<a href="#" class="btn mt-4">submit</a>--%>
											<asp:Button ID="Button2"  class="btn mt-4" runat="server" Text="Ingresar" OnClick="Button2_Click" />

                            				<p class="mb-0 mt-4 text-center"><a href="#0" class="link">Forgot your password?</a></p>
				      					</div>
			      					</div>
			      				</div>
								<div class="card-back">
									<div class="center-wrap">
										<div class="section text-center">
											<h4 class="mb-4 pb-3">Sign Up</h4>
											<div class="form-group">
												<%--<input type="text" name="logname" class="form-style" placeholder="Your Full Name" id="logname" autocomplete="off">--%>
												<asp:TextBox ID="TextBox5" class="form-style" placeholder="Nombre" runat="server"></asp:TextBox>
												<i class="input-icon uil uil-user"></i>

											</div>	
											<div class="form-group mt-2">
												<%--<input type="email" name="logemail" class="form-style" placeholder="Your Email" id="logemail" autocomplete="off">--%>
												<asp:TextBox ID="TextBox4" class="form-style" placeholder="Correo" runat="server"></asp:TextBox>
												<i class="input-icon uil uil-at"></i>

											</div>	
											<div class="form-group mt-2">
												<%--<input type="password" name="logpass" class="form-style" placeholder="Your Password" id="logpass" autocomplete="off">--%>
												<asp:TextBox ID="TextBox1" class="form-style" placeholder="Contraseña" runat="server"></asp:TextBox>
												<i class="input-icon uil uil-lock-alt"></i>

											</div>
										<%--	<a href="#" class="btn mt-4">submit</a>--%>
											<asp:Button ID="Button1" class="btn mt-4" runat="server" Text="Registrarse" OnClick="Button1_Click" />

				      					</div>
			      					</div>
			      				</div>
			      			</div>
			      		</div>
			      	</div>
		      	</div>
	      	</div>
	    </div>
	</div>
</main>
</asp:Content>
