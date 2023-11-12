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
using Microsoft.Ajax.Utilities;
using System.Text;

namespace ProyectoFinalParte2.Paginas
{
    public partial class DetallePeliculas : System.Web.UI.Page
    {
        protected ResponseModel2 peliculaSeleccionada = new ResponseModel2();
        protected ResponseModel3 actores = new ResponseModel3();
        protected ResponseModel5 calificacionesExpertos = new ResponseModel5();
        public List<ComentariosBO> Comentarios = new List<ComentariosBO>();
        public List<ComentariosBO> ComentariosRespuesta = new List<ComentariosBO>();

        protected async void Page_Load(object sender, EventArgs e)
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
                        Application["idComentario"] = pelicula.Mensaje.IdPelicula;

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

                            var nombresActores = new List<Negocios_CusumoApi.Involucrado>();

                            foreach (var actorId in actoresIds)
                            {
                                apiUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/api/Personas/id=" + actorId.idPersona;
                                response = await httpClient.GetAsync(apiUrl);

                                if (response.IsSuccessStatusCode)
                                {
                                    string nombreActorJson = await response.Content.ReadAsStringAsync();
                                    var nombreActor = JsonConvert.DeserializeObject<Personas>(nombreActorJson);

                                    var involucrado = new Negocios_CusumoApi.Involucrado
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


                        await LoadCommentaries(pelicula.Mensaje.IdPelicula);
                    }
                    else
                    {
                        // Manejo de respuesta no exitosa
                    }

                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción
            }
        }

        protected async void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            UserBO userBO = (UserBO)Application["User"];
            ComentariosBO comentariosBO = new ComentariosBO()
            {

                Comentario = txtComentario.Text,
                NombreUsuario = userBO.NombreUsuario,
                idPelicula = (int)Application["idComentario"],
                idRespuestaComentario = null,
                FechaComentario = DateTime.UtcNow
            };
            ComentariosClient comentariosClient = new ComentariosClient();
            var postComentariosResponse = await comentariosClient.PostComentarios(comentariosBO, (string)Application["Authorization"]);
            Response.Redirect(Request.RawUrl);
        }

        private async Task LoadCommentaries(int id)
        {
            try
            {
                Comentarios.Clear();
                ComentariosRespuesta.Clear();
                PeliculasClient peliculasClient = new PeliculasClient();
                PeliculasTopIdResponse peliculasTopIdResponse = await peliculasClient.GetPeliculasTopInfo(id, (string)Application["Authorization"]);

                foreach (var comentarioJson in peliculasTopIdResponse.Mensaje.Comentarios)
                {
                    try
                    {
                        ComentariosBO comentario = JsonConvert.DeserializeObject<ComentariosBO>(comentarioJson.ToString());
                        if (comentario.idRespuestaComentario == null)
                            Comentarios.Add(comentario);
                        else
                            ComentariosRespuesta.Add(comentario);
                    }
                    catch (JsonSerializationException ex)
                    {
                        // Manejar la excepción si la deserialización falla
                        // Por ejemplo, puedes registrar la excepción o mostrar un mensaje de error
                    }
                }


                ComentariosRepeater.DataSource = Comentarios;
                ComentariosRepeater.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        protected async void ResponderComentario(object sender, EventArgs e)
        {
            Button btnResponder = (Button)sender;
            int idComentario = Convert.ToInt32(btnResponder.CommandArgument);

            // Encuentra el TextBox correspondiente en el Repeater
            RepeaterItem item = (RepeaterItem)btnResponder.NamingContainer;
            TextBox txtRespuesta = (TextBox)item.FindControl("txtRespuesta");

            if (txtRespuesta == null)
                txtRespuesta = (TextBox)item.FindControl("txtRespuesta2");
            if (txtRespuesta == null)
                txtRespuesta = (TextBox)item.FindControl("txtRespuesta3");

            if (txtRespuesta == null)
                return;

            string respuesta = txtRespuesta.Text;
            if (respuesta == "")
                respuesta = "Sin palabras";

            UserBO userBO = (UserBO)Application["User"];
            ComentariosBO comentariosBO = new ComentariosBO()
            {
                Comentario = respuesta,
                NombreUsuario = userBO.NombreUsuario,
                idPelicula = (int)Application["idComentario"],
                idRespuestaComentario = idComentario,
                FechaComentario = DateTime.UtcNow
            };
            ComentariosClient comentariosClient = new ComentariosClient();
            var postComentariosResponse = await comentariosClient.PostComentarios(comentariosBO, (string)Application["Authorization"]);
            txtRespuesta.Text = string.Empty;
            Response.Redirect(Request.RawUrl);
        }

        protected async void EliminarComentario(object sender, EventArgs e)
        {
            Button btnResponder = (Button)sender;

            if (!string.IsNullOrEmpty(btnResponder.CommandArgument))
            {
                string[] arguments = btnResponder.CommandArgument.Split('|');

                if (arguments.Length == 2)
                {
                    string nombreUsuario = arguments[0];
                    int idComentario = Convert.ToInt32(arguments[1]);
                    UserBO userBO = (UserBO)Application["User"];
                    if (userBO.NombreUsuario == nombreUsuario)
                    {
                        ComentariosClient comentariosClient = new ComentariosClient();
                        var deleteComentarioResponse = await comentariosClient.DeleteComentario(idComentario, (string)Application["Authorization"]);

                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        string script = "alert('Solo el propio usuario puede eliminar un comentario');";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", script, true);
                    }
                }
            }

        }

        protected List<ComentariosBO> ObtenerRespuestas(int idComentario)
        {
            return ComentariosRespuesta
                .Where(c => c.idRespuestaComentario == idComentario)
                .ToList();
        }
    }
}
