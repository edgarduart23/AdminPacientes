using AdminPacientes.Data.Interfaces;
using AdminPacientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Data.Repositories
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(AdminContexto context) : base(context) { }

       

        public Task<Paciente> GetByNamePaciente(int dni)
            => FirstOrDefault(w => w.Dni == dni);
        public IEnumerable<Paciente> GetAllporDomicilio(int id)
        {
            return Context.Pacientes.Include(x => x.Domicilios);
        }

      
    }
}
