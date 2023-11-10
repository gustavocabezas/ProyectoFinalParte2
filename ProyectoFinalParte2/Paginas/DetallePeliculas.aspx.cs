using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Negocios_CusumoApi;
using ProyectoFinalParte2BO;

namespace ProyectoFinalParte2.Paginas
{
    public partial class DetallePeliculas : System.Web.UI.Page
    {
        protected ResponseModel2 peliculaSeleccionada;
        protected ResponseModel3 actores;
        protected ResponseModel5 calificacionesExpertos;

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

                    string apiUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Peliculas/PeliculasNombre/" + nombre;
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var pelicula = JsonConvert.DeserializeObject<ResponseModel2>(json);

                        byte[] imageBytes = Convert.FromBase64String(pelicula.Mensaje.Poster);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pelicula.Mensaje.PosterImage = ms.ToArray();
                        }

                        peliculaSeleccionada = pelicula;

                        apiUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/PeliculaRolesPersonas/" + pelicula.Mensaje.IdPelicula;
                        response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string actoresIdsJson = await response.Content.ReadAsStringAsync();
                            var actoresIds = JsonConvert.DeserializeObject<List<PeliculaRolesPersonas>>(actoresIdsJson);

                            var PrioriodadCreditosID = actoresIds.Select(actor => new PrioridadCreditosPersona
                            {
                                IdPersona = actor.idPersona,
                                PrioridadCreditos = actor.PrioridadCreditos
                            }).ToList();

                            var nombresActores = new List<Involucrado>();

                            foreach (var actorId in actoresIds)
                            {
                                apiUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Personas/id=" + actorId.idPersona;
                                response = await httpClient.GetAsync(apiUrl);

                                if (response.IsSuccessStatusCode)
                                {
                                    string nombreActorJson = await response.Content.ReadAsStringAsync();
                                    var nombreActor = JsonConvert.DeserializeObject<Personas>(nombreActorJson);

                                    var involucrado = new Involucrado
                                    {
                                        idPersona = actorId.idPersona,
                                        Nombre = nombreActor.Nombre,
                                        PrimerApellido = nombreActor.PrimerApellido
                                    };

                                    string apiUrl2 = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/RolesPersonas/" + actorId.idRolPersona;
                                    HttpResponseMessage response2 = await httpClient.GetAsync(apiUrl2);

                                    if (response2.IsSuccessStatusCode)
                                    {
                                        string rolInvolucrado = await response2.Content.ReadAsStringAsync();
                                        var actor = JsonConvert.DeserializeObject<RolesPersonas>(rolInvolucrado);
                                        involucrado.Rol = actor.Rol;
                                    }

                                    nombresActores.Add(involucrado);
                                }
                            }

                            var personasOrdenadas = nombresActores
                                .Join(PrioriodadCreditosID, persona => persona.idPersona, prioridad => prioridad.IdPersona,
                                    (persona, prioridad) => new { Persona = persona, Prioridad = prioridad.PrioridadCreditos })
                                .OrderBy(a => a.Prioridad)
                                .Select(a => a.Persona)
                                .ToList();

                            var responseModel3 = new ResponseModel3
                            {
                                TotalActores = personasOrdenadas
                            };
                            actores = responseModel3;
                        }

                        // Obtener calificaciones de expertos
                        apiUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Expertos/id=" + pelicula.Mensaje.IdPelicula;
                        response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonExpertosCalificaciones = await response.Content.ReadAsStringAsync();
                            var expertosCalificaciones = JsonConvert.DeserializeObject<List<ExpertoCalificacion>>(jsonExpertosCalificaciones);

                            calificacionesExpertos = new ResponseModel5
                            {
                                Codigo = 200,
                                Mensajes = expertosCalificaciones
                            };
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
