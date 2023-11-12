<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePeliculas.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.DetallePeliculas" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/DetallePeliculas.css" rel="stylesheet" />
    <br />
    <br />

    <% if (peliculaSeleccionada != null && peliculaSeleccionada.Mensaje != null && peliculaSeleccionada.Mensaje.PosterImage != null)
        { %>
    <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(peliculaSeleccionada.Mensaje.PosterImage) %>" class="img d-block mx-auto" width="300" height="400" alt="Poster de la película" />

    <div class="contenedor">

        <div>
            <p class="mb-0 mt-4 text-center"><a href='<%= "DetallePeliculas.aspx?nombre=" + peliculaSeleccionada.Mensaje.Nombre %>' class="link" style="color: white; font-size: 25px;"><%= peliculaSeleccionada.Mensaje.Nombre %></a></p>

            <p></p>

            <p><strong>Reseña:</strong> <%= peliculaSeleccionada.Mensaje.Reseña %></p>

            <p><strong>Fecha de Estreno:</strong> <%= peliculaSeleccionada.Mensaje.FechaSalida.ToString("yyyy-MM-dd") %></p>

            <p><strong>Calificación:</strong> <%= peliculaSeleccionada.Mensaje.Calificación %></p>
            <p class="fw-bold">Involucrados:</p>

            <% foreach (var actor in actores.TotalActores)
                { %>
            <p><strong></strong><%= actor.Nombre +" "+actor.PrimerApellido+" "+actor.Rol%></p>
            <% } %>

            <p class="fw-bold">Expertos y Calificaciones:</p>

            <% if (calificacionesExpertos.Mensajes != null)
                {
                    foreach (var experto in calificacionesExpertos.Mensajes)
                    { %>

            <p><strong></strong><%= experto.Nombre + " " + experto.PrimerApellido + " - Calificación: " + experto.Calificacion %></p>
            <% }
                } %>

            <div>
                <h3>Comentarios</h3>
                <div>
                    <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Rows="2" Columns="50"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar Comentario" OnClick="btnAgregarComentario_Click" />
                </div>

                <hr class="border border-primary border-1 opacity-25">

                <asp:Repeater ID="ComentariosRepeater" runat="server">
                    <ItemTemplate>
                        <div class="comment">
                            <p><strong>Usuario:</strong> <%# Eval("NombreUsuario") %></p>
                            <p><strong>Comentario:</strong> <%# Eval("Comentario") %></p>
                            <p><strong>Fecha:</strong> <%# Eval("FechaComentario") %></p>

                            <div>
                                <asp:TextBox ID="txtRespuesta" runat="server" TextMode="MultiLine" Rows="1" Columns="1" CssClass="respuesta-textbox "></asp:TextBox>
                            </div>
                            <br />
                            <asp:Button runat="server" ID="ResponderButton" Text="Responder" OnClick="ResponderComentario" CommandArgument='<%# Eval("idComentario") %>' />
                            <asp:Button runat="server" ID="DeleteReponseButton" Text="Eliminar" OnClick="EliminarComentario" CommandArgument='<%# Eval("NombreUsuario") + "|" + Eval("idComentario") %>' />

                            <!-- Muestra respuestas a este comentario si las hay -->
                            <asp:Repeater runat="server" DataSource='<%#  ObtenerRespuestas(Convert.ToInt32(Eval("idComentario"))) %>'>
                                <ItemTemplate>
                                    <div class="comment">
                                        <br />
                                        <p><strong>Usuario:</strong> <%# Eval("NombreUsuario") %></p>
                                        <p><strong>Comentario:</strong> <%# Eval("Comentario") %></p>
                                        <p><strong>Fecha:</strong> <%# Eval("FechaComentario") %></p>
                                        <br />
                                        <div>
                                            <asp:TextBox ID="txtRespuesta2" runat="server" TextMode="MultiLine" Rows="1" Columns="1" CssClass="respuesta-textbox "></asp:TextBox>
                                        </div>
                                        <br />
                                        <asp:Button runat="server" ID="ResponderButton2" Text="Responder" OnClick="ResponderComentario" CommandArgument='<%# Eval("idComentario") %>' />
                                        <asp:Button runat="server" ID="DeleteReponseButton2" Text="Eliminar" OnClick="EliminarComentario" CommandArgument='<%# Eval("NombreUsuario") + "|" + Eval("idComentario") %>' />

                                        <!-- Muestra otra respuestas a este comentario si las hay -->
                                        <asp:Repeater runat="server" DataSource='<%#  ObtenerRespuestas(Convert.ToInt32(Eval("idComentario"))) %>'>
                                            <ItemTemplate>
                                                <div class="comment">
                                                    <br />
                                                    <p><strong>Usuario:</strong> <%# Eval("NombreUsuario") %></p>
                                                    <p><strong>Comentario:</strong> <%# Eval("Comentario") %></p>
                                                    <p><strong>Fecha:</strong> <%# Eval("FechaComentario") %></p>
                                                    <br />
                                                    <div>
                                                        <asp:TextBox ID="txtRespuesta3" runat="server" TextMode="MultiLine" Rows="1" Columns="1" CssClass="respuesta-textbox "></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <asp:Button runat="server" ID="ResponderButton3" Text="Responder" OnClick="ResponderComentario" CommandArgument='<%# Eval("idComentario") %>' />
                                                    <asp:Button runat="server" ID="DeleteReponseButton3" Text="Eliminar" OnClick="EliminarComentario" CommandArgument='<%# Eval("NombreUsuario") + "|" + Eval("idComentario") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <hr class="border border-primary border-1 opacity-25">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

    </div>
    <br />
    <% } %>
</asp:Content>
