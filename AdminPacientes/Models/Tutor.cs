using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Tutor:Persona
    {
        
        public int Telefono { get; set; }
        public string Parentezco { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        //relacion entre Paciente
        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        [JsonIgnore]
        public Paciente Pacientes { get; set; }
    }
}
