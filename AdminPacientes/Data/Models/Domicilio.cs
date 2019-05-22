using AdminPacientes.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class Domicilio:Entidad
    {
        
        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(40)]
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Dpto { get; set; }
        [Required(ErrorMessage = "El codigo postal es requerido")]
        public int CodigoPostal { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(40)]
        public string Localidad { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(40)]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(40)]
        public string Nacionalidad { get; set; }
        //relacion entre Persona
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        [JsonIgnore]
        public Persona Personas { get; set; }
    }

}
