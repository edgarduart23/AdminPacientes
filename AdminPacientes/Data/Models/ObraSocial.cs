using AdminPacientes.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class ObraSocial:Entidad
    {
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(40)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string Direccion { get; set; }
        public ulong Telefono { get; set; }
        [Display(Name = "Direccion de Emails")]
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        //relacion entre Paciente
        public List<Paciente> Pacientes { get; set; }
    }
}
