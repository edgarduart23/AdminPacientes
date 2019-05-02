using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        //relacion entre domicilio
        public ICollection<Domicilio> Domicilios { get; set; }

    }
}
