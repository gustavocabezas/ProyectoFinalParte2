using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ProyectoFinalParte2.Paginas
{
    public partial class DetallePeliculas : System.Web.UI.Page
    {

        private List<Comentario> comentarios = new List<Comentario>();
        private int comentarioId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptComentarios.DataSource = comentarios;
                rptComentarios.DataBind();
            }

        }

        protected void AgregarComentario(object sender, EventArgs e)
        {
            var nuevoComentario = txtNuevoComentario.Text;
            comentarios.Add(new Comentario(comentarioId, nuevoComentario));
            comentarioId++;
            txtNuevoComentario.Text = "";

            rptComentarios.DataSource = comentarios;
            rptComentarios.DataBind();
        }

        protected void ResponderComentario(object sender, EventArgs e)
        {
            var btnResponder = (Button)sender;
            int comentarioId = Convert.ToInt32(btnResponder.CommandArgument);

            var comentario = comentarios.Find(c => c.ID == comentarioId);
            if (comentario != null)
            {
                var respuesta = ((TextBox)btnResponder.Parent.FindControl("txtRespuesta")).Text;
                comentario.Respuestas.Add(new Comentario(comentarioId, respuesta));
            }

            rptComentarios.DataSource = comentarios;
            rptComentarios.DataBind();
        }
    }


    public class Comentario
    {
        public int ID { get; set; }
        public string Texto { get; set; }
        public List<Comentario> Respuestas { get; set; }

        public Comentario(int id, string texto)
        {
            ID = id;
            Texto = texto;
            Respuestas = new List<Comentario>();
        }
    }

}