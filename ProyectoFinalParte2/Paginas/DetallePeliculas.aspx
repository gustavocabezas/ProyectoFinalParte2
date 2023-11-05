<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePeliculas.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.DetallePeliculas" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/DetallePeliculas.css" rel="stylesheet" />
    <br />
    <br />

    <div class="contenedor">
        <div>
            <%--<img src='<%# GetImageUrl(peliculaSeleccionada.PosterImage) %>' width="300" height="400" alt="Poster de la película" />--%>
        </div>

        <div class="contente">
            <p class="P">Nombre: <%# peliculaSeleccionada.Nombre %></p>
            <p class="p">Descripción: <%# peliculaSeleccionada.Reseña %></p>
            <p class="P">Fecha de estreno: <%# peliculaSeleccionada.FechaSalida.ToString("yyyy-MM-dd") %></p>
            <p class="P">Actores: <%# peliculaSeleccionada.Nombre %></p>
        </div>
    </div>
    <br />
</asp:Content>
