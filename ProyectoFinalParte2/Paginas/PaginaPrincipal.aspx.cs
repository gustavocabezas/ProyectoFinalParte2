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
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace ProyectoFinalParte2.Paginas
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected List<Peliculas> peliculasRecientes = new List<Peliculas>();
        protected ResponseModel2 peliculaSeleccionada;
        protected ResponseModel3 actores;
        protected List<Peliculas> peliculasReciente = new List<Peliculas>();
        protected List<Personas> listaActores = new List<Personas>();
        protected List<PeliculasReciente> listaPeliculas = new List<PeliculasReciente>();



        //PeliculasReciente

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
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (string)Application["Authorization"]);

                    string apiUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Peliculas/porLanzamiento";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        var responseObj = JsonConvert.DeserializeObject<ResponseModel>(json);

                        peliculasRecientes = responseObj.Mensaje.Take(5).ToList();

                        foreach (var pelicula in peliculasRecientes)
                        {
                            var pelicularescient = new PeliculasReciente();//esto está local
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

                            listaPeliculas.Add(pelicularescient);
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

