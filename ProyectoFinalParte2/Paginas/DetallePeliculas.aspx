<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePeliculas.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.DetallePeliculas" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/DetallePeliculas.css" rel="stylesheet" />
    <br />
    <br />

    <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(peliculaSeleccionada.Mensaje.PosterImage) %>" class="img d-block mx-auto" width="300" height="400" alt="Poster de la película" />


    <div class="contenedor">

        <div>
            <p class="mb-0 mt-4 text-center"><a href='<%= "DetallePeliculas.aspx?nombre=" + peliculaSeleccionada.Mensaje.Nombre %>' class="link" style="color: white; font-size: 25px;"><%= peliculaSeleccionada.Mensaje.Nombre %></a></p>
            <p></p>
            <p><strong>Reseña:</strong> <%= peliculaSeleccionada.Mensaje.Reseña %></p>
            <p><strong>Fecha de Estreno:</strong> <%= peliculaSeleccionada.Mensaje.FechaSalida.ToString("yyyy-MM-dd") %></p>
            <p><strong>Calificación:</strong> <%= peliculaSeleccionada.Mensaje.Calificación %></p>
            <% foreach (var actor in actores.TotalActores)
                { %>
            <p><strong>Actor:</strong> <%= actor.Nombre %></p>
            <p><strong>Primer Apellido:</strong> <%= actor.PrimerApellido %></p>
            <%--<p><strong>Segundo Apellido:</strong> <%= actor.SegundoApellido %></p>--%>
<%--        <p><strong>Página Web:</strong> <%= actor.PaginaWeb %></p>
            <p><strong>Facebook:</strong> <%= actor.Facebook %></p>
            <p><strong>Twitter:</strong> <%= actor.Twitter %></p>
            <p><strong>Instagram:</strong> <%= actor.Instagram %></p>
            <p><strong>Estado:</strong> <%= actor.Estado %></p>--%>
            <!-- Línea divisoria entre actores -->
            <% } %>
        </div>

    </div>
    <br />
</asp:Content>
