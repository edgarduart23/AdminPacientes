using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class SeguroMedico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumPoliza { get; set; }
        public string Tipo { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
    }
}
