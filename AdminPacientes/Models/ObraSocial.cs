using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class ObraSocial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public int Telefono { get; set; }
        [Display(Name = "Direccion de Emails")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        //relacion entre Paciente
        public List<Paciente> Pacientes { get; set; }
    }
}
