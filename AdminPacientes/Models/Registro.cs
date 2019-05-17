using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Registro
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="La fecha de atencion es requerida")]
        public DateTime FechaAtencion { get; set; }
        //relacion entre Paciente
        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        [JsonIgnore]
        public Paciente Paciente { get; set; }

    }
}
