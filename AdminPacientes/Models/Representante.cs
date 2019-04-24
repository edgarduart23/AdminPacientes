using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Representante
    {
        public int IdRepresentate { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Dni { get; set; }
        public int Telefono { get; set; }
        public string Parentezco { get; set; }
    }
}
