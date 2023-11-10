using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParte2BO
{
    public class ComentariosBO
    {
        public int idComentario { get; set; }
        public string Comentario { get; set; }
        public string NombreUsuario { get; set; }
        public int idPelicula { get; set; }
        public Nullable<int> idRespuestaComentario { get; set; }
        public DateTime FechaComentario { get; set; }
    }
}
