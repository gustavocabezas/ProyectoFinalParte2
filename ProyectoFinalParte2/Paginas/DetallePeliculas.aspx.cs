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

namespace ProyectoFinalParte2.Paginas
{
    public partial class DetallePeliculas : System.Web.UI.Page
    {
        protected Peliculas peliculaSeleccionada;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string peliculaId = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(peliculaId))
                {
                    // Realiza una solicitud a la API para obtener los detalles de la película por su ID
                    peliculaSeleccionada = await GetPeliculaPorId(peliculaId);
                    // Enlaza los datos a la página
                    DataBind();
                }
            }
        }

        // Función para obtener la URL de la imagen de la película
        private async Task<Peliculas> GetPeliculaPorId(string nombre)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = "https://localhost:44311/api/Peliculas" + nombre; // Reemplaza con la URL correcta de tu API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Peliculas>(json);
                }

                return null; // Maneja el caso en que la solicitud a la API no sea exitosa
            }
        }
    }
}
