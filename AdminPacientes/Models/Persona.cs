using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdminPacientes.Models
{
    public abstract class Persona
    {
        public int Id { get; set; }
        [Required]
        public int Dni { get; set; }

        [RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido invalido"), MaxLength(30)]
        public string Apellido { get; set; }
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }

        [Display(Name = "Direccion de Emails")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email{ get; set; }
        //relacion entre domicilio
        public ICollection<Domicilio> Domicilios { get; set; }

    }
}
