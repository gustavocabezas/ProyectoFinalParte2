<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PeliculasPorNombre.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.PeliculasPorNombre" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/stiloPeli.css" rel="stylesheet" />

    <div class="PeliculasContainer">
        <div class="TPost A">
            <div class="PeliculaItem">
                <% if (peliculasLike != null && peliculasLike.Count > 0) { %>
                    <% for (int i = 0; i < peliculasLike.Count; i++) { %>
                        <div class="movie-item">
                            <figure class="Objf TpMvPlay AAIco-play_arrow">
                                <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(peliculasLike[i].PosterImage) %>"
                                    class="img d-block mx-auto" width="300" height="400" alt="Poster de la película" />
                            </figure>
                            <div class="movie-info">
                                <div class="tituloPelicula">
                                    <a href='<%= "DetallePeliculas.aspx?nombre=" + peliculasLike[i].Nombre %>'
                                        style="text-decoration: none; color: #ffffff; text-align:center;"><%= peliculasLike[i].Nombre %></a>
                                </div>
                                <p ><strong>Reseña:</strong> <%= peliculasLike[i].Reseña %></p>
                                <p><strong>Fecha de Salida:</strong> <%= peliculasLike[i].FechaSalida.ToString("yyyy-MM-dd") %></p>
                                <p><strong>Actores:</strong> <%= peliculasLike[i] %></p>
                            </div>
                        </div>
                    <% } %>
                <% } else { %>
                    <p>Película no encontrada.</p>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
