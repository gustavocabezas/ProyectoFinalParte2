using Negocios_CusumoApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoFinalParte2.Paginas
{
    public partial class PeliculasPorNombre : System.Web.UI.Page
    {
        protected List<Peliculas> peliculasLike;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["nombre"]))
                {
                    string nombrePelicula = Request.QueryString["nombre"];

                   BuscarPeliculasPorNombre(nombrePelicula);
  
                }
                else
                {
                    // El parámetro "nombre" no se ha pasado, puedes redirigir a otra página o mostrar un mensaje de error.
                }
            }

        }

        public async void BuscarPeliculasPorNombre(string nombre)
        {
            string apiUrl = $"https://localhost:44311/api/Peliculas/PeliculasNombreLike/{nombre}";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (string)Application["Authorization"]);
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        var responseModel = JsonConvert.DeserializeObject<ResponseModel>(json);

                        peliculasLike = responseModel.Mensaje.ToList();

                        // Decodifica y convierte las imágenes
                        foreach (var pelicula in peliculasLike)
                        {
                            byte[] imageBytes = Convert.FromBase64String(pelicula.Poster);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pelicula.PosterImage = ms.ToArray();
                            }
                        }

                        if (responseModel != null && responseModel.Codigo == 200)
                        {
                            peliculasLike = responseModel.Mensaje.ToList();
                        }
                    }
                    else
                    {


                    }

                        // Maneja errores o respuestas no exitosas aquí
                    }
                catch (Exception ex)
                {
                    // Maneja excepciones aquí
                }

            }
        }
   }
}
