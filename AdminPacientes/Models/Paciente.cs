using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Paciente: Persona
    {
        
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public int NumeroAfiliado { get; set; }
        //relacion entre Tutor
        public ICollection<Tutor> Tutores { get; set; }
        //relacion entre ObraSocial
        [ForeignKey("ObraSocial")]
        public int ObraSocialId { get; set; }
        [JsonIgnore]
        public ObraSocial ObraSociales { get; set; }
        
        }
}
