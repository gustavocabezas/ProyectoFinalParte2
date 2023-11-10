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
        protected List<PeliculasReciente> listaPeliculasLike = new List<PeliculasReciente>();
        protected List<Personas> listaActores = new List<Personas>();

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
                    
                }
            }
        }

        public async void BuscarPeliculasPorNombre(string nombre)
        {
            string apiUrl = $"https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Peliculas/PeliculasNombreLike/{nombre}";

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

                        var peliculasLike = responseModel.Mensaje.ToList();

                        // Decodifica y convierte las imágenes
                        foreach (var pelicula in peliculasLike)
                        {
                            var pelicularescient = new PeliculasReciente();
                            //esto está local
                            string apiUrls = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Peliculas/PeliculasActores?id=" + pelicula.IdPelicula;

                            HttpResponseMessage responses = await httpClient.GetAsync(apiUrls);

                            if (responses.IsSuccessStatusCode)
                            {
                                string json1 = await responses.Content.ReadAsStringAsync();

                                var responseObj1 = JsonConvert.DeserializeObject<List<Personas>>(json1);

                                listaActores = responseObj1.Take(3).ToList();

                                var contador = 0;

                                foreach (var Actor in listaActores)
                                {
                                    if (contador == 0)
                                    {
                                        pelicularescient.Actor1 = Actor.Nombre;
                                        pelicularescient.Apellido1 = Actor.PrimerApellido;
                                    }
                                    else if (contador == 1)
                                    {
                                        pelicularescient.Actor2 = Actor.Nombre;
                                        pelicularescient.Apellido2 = Actor.PrimerApellido;
                                    }
                                    else if (contador == 2)
                                    {
                                        pelicularescient.Actor3 = Actor.Nombre;
                                        pelicularescient.Apellido3 = Actor.PrimerApellido;
                                    }

                                    contador++;
                                }
                            }

                            pelicularescient.Nombre = pelicula.Nombre;
                            pelicularescient.Reseña = pelicula.Reseña;
                            pelicularescient.FechaSalida = pelicula.FechaSalida;

                            byte[] imageBytes = Convert.FromBase64String(pelicula.Poster);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pelicularescient.PosterImage = ms.ToArray();
                            }

                            listaPeliculasLike.Add(pelicularescient);
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
