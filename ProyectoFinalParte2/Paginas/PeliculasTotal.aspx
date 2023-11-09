<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PeliculasTotal.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.PeliculasTotal" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/stiloPeli.css" rel="stylesheet" />

    <div class="PeliculasContainer">
        <div class="TPost A">
            <div class="PeliculaItem">
                <% if (peliculasRecientes != null && peliculasRecientes.Count > 0) { %>
                    <% for (int i = 0; i < peliculasRecientes.Count; i++) { %>
                        <div class="movie-item">
                            <figure class="Objf TpMvPlay AAIco-play_arrow">
                                <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(peliculasRecientes[i].PosterImage) %>"
                                    class="img d-block mx-auto" width="300" height="400" alt="Poster de la película" />
                            </figure>
                            <div class="movie-info">
                                <div class="tituloPelicula">
                                    <a href='<%= "DetallePeliculas.aspx?nombre=" + peliculasRecientes[i].Nombre %>'
                                        style="text-decoration: none; color: #ffffff;"><%= peliculasRecientes[i].Nombre %></a>
                                </div>
                                <p><strong>Reseña:</strong> <%= peliculasRecientes[i].Reseña %></p>
                                <p><strong>Fecha de Salida:</strong> <%= peliculasRecientes[i].FechaSalida.ToString("yyyy-MM-dd") %></p>
                                <p><strong>Actores:</strong> <%= peliculasRecientes[i] %></p>
                                
                                
                            </div>
                        </div>
                    <% } %>
                <% } else { %>
                    <p>No se encontraron películas recientes.</p>
                <% } %>
            </div>
        </div>
    </div>

</asp:Content>
