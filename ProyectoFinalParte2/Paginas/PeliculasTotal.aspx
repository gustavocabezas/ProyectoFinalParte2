<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PeliculasTotal.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.PeliculasTotal" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/stiloPeli.css" rel="stylesheet" />

    <div class="PeliculasContainer">
        <div class="TPost A">
            <div class="PeliculaItem">
                <% if (listaPeliculasLike != null && listaPeliculasLike.Count > 0) { %>
                    <% for (int i = 0; i < listaPeliculasLike.Count; i++) { %>
                        <div class="movie-item">
                            <figure class="Objf TpMvPlay AAIco-play_arrow">
                                <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(listaPeliculasLike[i].PosterImage) %>"
                                    class="img d-block mx-auto" width="300" height="400" alt="Poster de la película" />
                            </figure>
                            <div class="movie-info">
                                <div class="tituloPelicula">
                                    <a href='<%= "DetallePeliculas.aspx?nombre=" + listaPeliculasLike[i].Nombre %>'
                                        style="text-decoration: none; color: #ffffff; text-align:center;"><%= listaPeliculasLike[i].Nombre %></a>
                                </div>
                                <p ><strong>Reseña:</strong> <%= listaPeliculasLike[i].Reseña %></p>
                                <p><strong>Fecha de Salida:</strong> <%= listaPeliculasLike[i].FechaSalida.ToString("yyyy-MM-dd") %></p>
                                <p><strong>Actores:</strong> <%= listaPeliculasLike[i].Actor1 %> <%= listaPeliculasLike[i].Apellido1 %>,
                                    <%= listaPeliculasLike[i].Actor2 %> <%= listaPeliculasLike[i].Apellido2 %>,
                                    <%= listaPeliculasLike[i].Actor3 %> <%= listaPeliculasLike[i].Apellido3 %></p>
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
