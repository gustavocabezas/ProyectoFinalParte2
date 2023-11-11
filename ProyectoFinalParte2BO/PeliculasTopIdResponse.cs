using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParte2BO
{
    public class PeliculasTopIdResponse
    {
        public int Codigo { get; set; }
        public Mensaje Mensaje { get; set; }
    }

    public class Mensaje
    {
        public int PeliculaID { get; set; }
        public DatosPelicula DatosPelicula { get; set; }
        public List<object> Comentarios { get; set; }
        public List<Involucrado> Involucrados { get; set; }
        public List<CalificacionExperto> CalificacionesExpertos { get; set; }
    }

    public class DatosPelicula
    {
        public string Nombre { get; set; }
        public string Reseña { get; set; }
        public double Calificación { get; set; }
        public DateTime FechaSalida { get; set; }
        public byte[] Poster { get; set; }
    }

    public class Comentario
    {
        public int IdPelicula { get; set; }
        public int IdComentario { get; set; }
        public string ComentarioTexto { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaComentario { get; set; }
    }

    public class Involucrado
    {
        public int IdPelicula { get; set; }
        public int IdPersona { get; set; }
        public int IdRolPersona { get; set; }
        public int PrioridadCreditos { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PaginaWeb { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Estado { get; set; }
    }

    public class CalificacionExperto
    {
        public int IdCalificacion { get; set; }
        public int IdPelicula { get; set; }
        public int IdExperto { get; set; }
        public double Calificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
    }
}