using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalParte2.Paginas
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("Authorization");
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("~/Paginas/Login.aspx");
        }
    }
}