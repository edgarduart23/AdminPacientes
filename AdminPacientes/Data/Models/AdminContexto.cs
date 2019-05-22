using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Models
{
    public class AdminContexto: DbContext
    {
        public AdminContexto(DbContextOptions<AdminContexto> options)
            : base(options)
        {
        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<ObraSocial> ObraSociales { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Registro> Registros { get; set; }

    }
}

