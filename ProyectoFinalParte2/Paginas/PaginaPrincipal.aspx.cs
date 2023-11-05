using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using Negocios_CusumoApi;
using System.Linq;
using System.IO;
using System.Drawing;
using ProyectoFinalParte2BO;

namespace ProyectoFinalParte2.Paginas
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected List<Peliculas> peliculasRecientes = new List<Peliculas>();
        //protected List<Actores> ActoresporPelicula;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPeliculasRecientes();
            }

        }
        protected async void CargarPeliculasRecientes()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Especifica la URL de la API de películas
                    string apiUrl = "https://localhost:44311/api/Peliculas/porLanzamiento";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta de la API
                        string json = await response.Content.ReadAsStringAsync();

                        // Convierte el JSON en un objeto que contiene una lista de películas
                        var responseObj = JsonConvert.DeserializeObject<ResponseModel>(json);

                        // Toma las 5 películas más recientes
                        peliculasRecientes = responseObj.Mensaje.Take(5).ToList();

                        // Decodifica y convierte las imágenes
                        foreach (var pelicula in peliculasRecientes)
                        {
                            byte[] imageBytes = Convert.FromBase64String(pelicula.Poster);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pelicula.PosterImage = ms.ToArray();
                            }
                        }
                    }
                    else
                    {
                        // Maneja el caso en que la respuesta no sea exitosa
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
            }
        }





    }
}

