using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public int Dni { get; set; }
        public int Telefono { get; set; }
        public string Domicilio { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Email { get; set; }

    }
}
