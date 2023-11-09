using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios_CusumoApi;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using ProyectoFinalParte2BO;
using System.Net.Http.Headers;

namespace ProyectoFinalParte2.Paginas
{
    public partial class DetallePeliculas : System.Web.UI.Page
    {
        protected ResponseModel2 peliculaSeleccionada;
        protected ResponseModel3 actores;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string peliculaId = Request.QueryString["nombre"];

                if (!string.IsNullOrEmpty(peliculaId))
                {
                    CargarPeliculaPorNombre(peliculaId);
                }
            }
        }


        protected async void CargarPeliculaPorNombre(string nombre)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (string)Application["Authorization"]);

                    // Especifica la URL de la API de películas
                    string apiUrl = "https://localhost:44311/api/Peliculas/PeliculasNombre/" + nombre;
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta de la API
                        string json = await response.Content.ReadAsStringAsync();
                        // Convierte el JSON en una instancia de la clase Pelicula
                        var pelicula = JsonConvert.DeserializeObject<ResponseModel2>(json);


                        // Decodifica y convierte las imágenes

                        byte[] imageBytes = Convert.FromBase64String(pelicula.Mensaje.Poster);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pelicula.Mensaje.PosterImage = ms.ToArray();
                        }

                        peliculaSeleccionada = pelicula;

                        // Ahora obtén los IDs de los actores relacionados a la película desde PeliculaRolesPersonas
                        apiUrl = "https://localhost:44311/api/PeliculaRolesPersonas/" + pelicula.Mensaje.IdPelicula;
                        response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string actoresIdsJson = await response.Content.ReadAsStringAsync();

                            // Deserializar los datos recibidos desde la API en una lista de objetos
                            var actoresIds = JsonConvert.DeserializeObject<List<PeliculaRolesPersonas>>(actoresIdsJson);

                            // Crear una lista de objetos PrioridadCreditosPersona con las propiedades necesarias
                            var PrioriodadCreditosID = actoresIds.Select(actor => new PrioridadCreditosPersona
                            {
                                IdPersona = actor.idPersona,
                                PrioridadCreditos = actor.PrioridadCreditos
                            }).ToList();


                            var nombresActores = new List<Personas>();

                            foreach (var actorId in actoresIds)
                            {
                                apiUrl = "https://localhost:44311/api/Personas/id=" + actorId.idPersona;
                                response = await httpClient.GetAsync(apiUrl);

                                if (response.IsSuccessStatusCode)
                                {

                                    string nombreActorJson = await response.Content.ReadAsStringAsync();
                                    var nombreActor = JsonConvert.DeserializeObject<Personas>(nombreActorJson);

                                    nombresActores.Add(nombreActor);

                                }

                            }

                            //ordenar los nombres actores por orden de prioridad con idPersona

                            var personasOrdenadas = nombresActores
                            .Join(PrioriodadCreditosID, persona => persona.idPersona, prioridad => prioridad.IdPersona,
                            (persona, prioridad) => new { Persona = persona, Prioridad = prioridad.PrioridadCreditos })
                            .OrderBy(a => a.Prioridad)  // Ordena por Prioridad
                            .Select(a => a.Persona)  // Selecciona solo los objetos de Personas
                            .ToList();

                            var responseModel3 = new ResponseModel3
                            {
                                TotalActores = personasOrdenadas,  // personasOrdenadas es la lista de actores ordenados
                            };
                            actores = responseModel3;


                            //"ACA QUIERO ORDENAR LA LISTA DE ACTORES"

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
