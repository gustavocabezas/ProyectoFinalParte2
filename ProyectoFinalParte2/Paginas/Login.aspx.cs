using Microsoft.Ajax.Utilities;
using Negocios_CusumoApi;
using ProyectoFinalParte2BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalParte2.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (LoginClient loginClient = new LoginClient())
                {
                    LoginBO login = new LoginBO() { NombreUsuario = TextBox2.Text, Contraseña = TextBox3.Text };
                    string authorization = await loginClient.PostLogin(login);
                    if (!string.IsNullOrEmpty(authorization))
                    {
                        // Almacenar el valor de autorización en una cookie o en la sesión, según tus necesidades
                        HttpContext.Current.Session["Authorization"] = authorization;
                        // Redirigir al usuario a la página principal
                        Response.Redirect("PaginaPrincipal.aspx");
                    }
                    else
                    {
                        // Manejar el caso en el que no se obtuvo un valor de autorización 
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        // mensaje para el bloqueo “Su usuario se encuentra inactivo,por favor comuníquese con el administrador”
    }
}

// mensaje a mostrar Usuario y/o contraseña incorrectos