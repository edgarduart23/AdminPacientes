using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Tutor:Persona
    {
        [Required(ErrorMessage = "El telefono es requerido")]
        public ulong Telefono { get; set; }
        [Required(ErrorMessage = "El parentezco es requerido")]
        [StringLength(40)]
        public string Parentezco { get; set; }
        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "El email es requerido")]
        public EnumEstadoCivil EstadoCivil { get; set; }
        [JsonProperty("EnumSexo")]
        public string Ocupacion { get; set; }
        //relacion entre Paciente
        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        [JsonIgnore]
        public Paciente Pacientes { get; set; }
        

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumEstadoCivil
    {
        Soltero,
        Casado,
        Viudo,

    }
}
