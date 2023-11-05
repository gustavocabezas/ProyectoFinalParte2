<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.PaginaPrincipal" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <link href="../Css/PaginaPrincipal.css" rel="stylesheet" />



    <h2 class="h2">Peliculas Top 5 </h2>
    <div class="d-flex justify-content-center">


    <div>
        

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicadores -->
            <ol class="carousel-indicators">
                <% for (int i = 0; i < peliculasRecientes.Count; i++) { %>
                    <li data-target="#myCarousel" data-slide-to="<%= i %>" class="<%= i == 0 ? "active" : "" %>"></li>
                <% } %>
            </ol>

            <!-- Contenido del carrusel -->
            <div class="carousel-inner">
                <% for (int i = 0; i < peliculasRecientes.Count; i++) { %>
                    <div class="carousel-item <%= i == 0 ? "active" : "" %>">
                        <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(peliculasRecientes[i].PosterImage) %>" class="img d-block w-30" alt="Poster de la película" />
                        <div>
                            <h3 class="h3"><a href='<%= "DetallePeliculas.aspx?nombre=" + peliculasRecientes[i].Nombre %>' style="text-decoration: none; color: #ffffff;"><%= peliculasRecientes[i].Nombre %></a></h3>
                            <p><strong>Reseña:</strong> <%= peliculasRecientes[i].Reseña %></p>
                            <p><strong>Fecha de Estreno:</strong> <%= peliculasRecientes[i].FechaSalida.ToString("yyyy-MM-dd") %></p>
                            <p><strong>Calificación:</strong> <%= peliculasRecientes[i].Calificación %></p>
                        </div>
                    </div>
                <% } %>
            </div>

            <!-- Controles del carrusel -->
            <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                <span  aria-hidden="true"></span>
                <span class="sr-only">Anterior</span>
            </a>
            <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                <span aria-hidden="true"></span>
                <span class="sr-only">Siguiente</span>
            </a>
        </div>
    </div>
</div>

    <!-- JavaScript para la función buscarPeliculas -->
    <script type="text/javascript">
        function buscarPeliculas() {
            var keyword = document.getElementById("keysss").value;
            // Realiza la búsqueda de películas aquí o redirige a la página de resultados.
            window.location.href = "/PeliculasPorNombre.aspx?keyword=" + keyword;
        }
    </script>
</asp:Content>
