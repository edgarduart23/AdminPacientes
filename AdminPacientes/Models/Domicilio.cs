using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int piso { get; set; }
        public string Dpto { get; set; }
        public int CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Nacionalidad { get; set; }
        public int Telefono { get; set; }
    }

}
