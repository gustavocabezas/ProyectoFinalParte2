using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios_CusumoApi
{
    public partial class PeliculaRolesPersonas
    {
        public int idPelicula { get; set; }
        public int idPersona { get; set; }
        public int idRolPersona { get; set; }
        public int PrioridadCreditos { get; set; }
       
    }

    public class RolesPersonas
    {
        public int idRol { get; set; }
        public string Rol { get; set; }
    }
}
