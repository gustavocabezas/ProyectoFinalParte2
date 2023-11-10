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
                       <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(listaPeliculas[i].PosterImage) %>" class="img d-block w-30" alt="Poster de la película" />
                      <div>

                            <p class="mb-0 mt-4 text-center"><a href='<%= "DetallePeliculas.aspx?nombre=" + listaPeliculas[i].Nombre %>' class="link" style="color: white; font-size: 25px;"><%= listaPeliculas[i].Nombre %></a></p>

                            <p></p>
                            <p><strong>Reseña:</strong> <%= listaPeliculas[i].Reseña %></p>
                            <p><strong>Fecha de Estreno:</strong> <%= listaPeliculas[i].FechaSalida.ToString("yyyy-MM-dd") %></p>
                            <p>Involucrados:</p>
                            <p><strong></strong> <%= listaPeliculas[i].Actor1 + " " + listaPeliculas[i].Apellido1  %></p>
                            <p><strong></strong> <%= listaPeliculas[i].Actor2 + " " + listaPeliculas[i].Apellido2  %></p>
                            <p><strong></strong> <%= listaPeliculas[i].Actor3 + " " + listaPeliculas[i].Apellido3  %></p>

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

   <%-- <asp:Repeater ID="rptPeliculas" runat="server">
    <ItemTemplate>
        <div>
            <p class="mb-0 mt-4 text-center">
                <a href='<%# "DetallePeliculas.aspx?nombre=" + Eval("Nombre") %>' class="link" style="color: white; font-size: 25px;">
                    <%# Eval("Nombre") %>
                </a>
            </p>
            <p></p>
            <p><strong>Reseña:</strong> <%# Eval("Reseña") %></p>
            <p><strong>Fecha de Estreno:</strong> <%# Eval("FechaSalida", "{0:yyyy-MM-dd}") %></p>
            <p>Involucrados:</p>
            <p><strong></strong> <%# Eval("Actor1") + " " + Eval("Apellido1") %></p>
            <p><strong></strong> <%# Eval("Actor2") + " " + Eval("Apellido2") %></p>
            <p><strong></strong> <%# Eval("Actor3") + " " + Eval("Apellido3") %></p>
        </div>
    </ItemTemplate>
</asp:Repeater>--%>



    <!-- JavaScript para la función buscarPeliculas -->
    <script type="text/javascript">
        function buscarPeliculas() {
            var keyword = document.getElementById("keysss").value;
            // Realiza la búsqueda de películas aquí o redirige a la página de resultados.
            window.location.href = "/PeliculasPorNombre.aspx?keyword=" + keyword;
        }
    </script>
</asp:Content>
