using Newtonsoft.Json;
using ProyectoFinalParte2BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios_CusumoApi
{
    public partial class Personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personas()
        {
            this.PeliculaRolesPersonas = new HashSet<PeliculaRolesPersonas>();
        }

        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PaginaWeb { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<PeliculaRolesPersonas> PeliculaRolesPersonas { get; set; }
    }

    public class ResponseModel3
    {
        public List<Involucrado> TotalActores { get; set; }
    }

    public class ResponseModel4
    {
        public int Codigo { get; set; }
        public List<Personas> Mensajes { get; set; }

    }


    public class PrioridadCreditosPersona
    {
        public int IdPersona { get; set; }
        public int PrioridadCreditos { get; set;}

    }

    public class Involucrado
    {
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Rol { get; set; }
    }
    public class ExpertoCalificacion
    {
        public int IdExperto { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Estado { get; set; }
        public decimal Calificacion { get; set; }
    }

    public class ResponseModel5
    {
        public int Codigo { get; set; }
        public List<ExpertoCalificacion> Mensajes { get; set; }

    }
}
