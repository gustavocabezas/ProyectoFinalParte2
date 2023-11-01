<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePeliculas.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.DetallePeliculas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/DetallePeliculas.css" rel="stylesheet" />
    <br />
    <br />

    <div class="contenedor">
        <div>
            <img src="../Posters/Alien-Vs-Depredador.jpg" width="300" height="400" alt="Primer slide" />
        </div>
        <div class="contente">
            <p class="P">Nombre: Alein Vs Depredador</p>
            <p class="p">Descripcion: El descubrimiento de una antigua pirámide enterrada bajo los hielos de la Antártida hace acudir hasta el continente helado a un equipo de científicos y aventureros. Una vez allí, hacen un descubrimiento aún más aterrador: dos razas de extraterrestres en guerra. Gane quien gane, nosotros perdemos. La increíble y terrorífica aventura comienza cuando el millonario industrial Charles Bishop Weyland reúne a un equipo internacional de arqueólogos, científicos y expertos en seguridad, dirigidos por la especialista en medioambiente y aventurera Alexa ”Lex” Woods, para investigar unas misteriosas ”emanaciones de calor” que surgen desde las profundidades de la Antártida.</p>
            <p>Fecha de estreno: 2004</p> 
            <p>Actores: Sanaa Lathan, Raoul Bova, Lance Henriksen</p>
        </div>
    </div>
    <br />
    <br />

    <div class="contente">
        <div class="comentarios-container">
            <asp:TextBox ID="txtNuevoComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Columns="50" />
            <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar Comentario" OnClick="AgregarComentario" CssClass="btn btn-primary" />
         </div>
            <asp:Repeater ID="rptComentarios" runat="server">
                <ItemTemplate>
                     <div class="comentario">
                        <div class="comentario-text"  style="float: right;">
                            <p><%# Eval("Texto") %></p>
                        </div>
                         <div class="comentario-respuestas">
                            <asp:Button ID="btnResponder" runat="server" Text="Responder" OnClick="ResponderComentario" CommandArgument='<%# Eval("ID") %>' />
                                 <asp:Repeater ID="rptRespuestas" runat="server">
                                <ItemTemplate>
                                    <div class="respuesta">
                                        <p><%# Eval("Texto") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    
                </ItemTemplate>
            </asp:Repeater>
    </div>

</asp:Content>

