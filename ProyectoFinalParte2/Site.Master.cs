using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoFinalParte2
{
    public partial class SiteMaster : MasterPage
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl navbar;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtén el nombre de la página actual sin la ruta
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            // Verifica si la página actual es "Login.aspx"
            if (currentPage.EndsWith("Login"))
            {
                navbar.Visible = false; // Oculta el control "navbar"
            }

            if (!IsPostBack)
            {
                bool isAuthenticated = Application["Authorization"] != null;

                if (isAuthenticated)
                {
                    navLinkLogin.Visible = !isAuthenticated;
                }
                else
                {
                    navLinkLogin.Visible = !isAuthenticated;
                }

            }
        }

        protected void buscarPeliculas_Click(object sender, EventArgs e)
        {
            string textoBusqueda = keysss.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                Response.Redirect("PeliculasTotal.aspx");
            }
            else
            {
                Response.Redirect("PeliculasPorNombre.aspx?nombre=" + textoBusqueda);
            }

        }

        protected void keysss_TextChanged(object sender, EventArgs e)
        {
            //r
        }
    }
}