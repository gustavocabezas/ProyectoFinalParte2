using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalParte2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si la página actual es Login.aspx y oculta la barra de búsqueda y el botón de búsqueda
                if (Request.Url.AbsolutePath.EndsWith("../Paginas/Login.aspx", StringComparison.InvariantCultureIgnoreCase))
                {
                    searchBar.Visible = false;
                }
            }
        }

        protected void buscarPeliculas_Click(object sender, EventArgs e)
        {
            string textoBusqueda = keysss.Text.Trim(); // Obtenemos el texto y eliminamos espacios en blanco al principio y al final.

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                // Si el campo está vacío, redirige a "PeliculasTotal.aspx".
                Response.Redirect("PeliculasTotal.aspx");
            }
            else
            {
                // Si el campo tiene algún valor, redirige a "PeliculasPorNombre.aspx" y pasa el valor como parámetro.
                Response.Redirect("PeliculasPorNombre.aspx?nombre=" + textoBusqueda);
            }

        }
    }
}