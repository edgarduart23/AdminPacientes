using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using AdminPacientes.Data.Models;

namespace AdminPacientes.Models
{
    public abstract class Persona:Entidad
    {
        
        [Required]
        public int Dni { get; set; }

        [RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage ="EL nombre es requerido")]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido"), MaxLength(30)]
        public string Apellido { get; set; }
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [JsonProperty("Sexo")]
        public EnumSexo Sexo { get; set; }
        public string Nacionalidad { get; set; }
        

        [Display(Name = "Direccion de Emails")]
        [Required(ErrorMessage = "La direccion de email es requerido")]
        [EmailAddress(ErrorMessage = "La direccion de email es invalida")]
        public string Email{ get; set; }
        //relacion entre domicilio
        public ICollection<Domicilio> Domicilios { get; set; }
        
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumSexo
    {
        Masculino,
        Femenino

    }

}
