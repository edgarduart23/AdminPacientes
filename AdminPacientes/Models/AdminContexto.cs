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
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<SeguroMedico> SeguroMedicos { get; set; }

    }
}

