using AdminPacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Data.Interfaces
{
    public interface IPacienteRepository : IGenericRepository<Paciente>
    {
        Task<Paciente> GetByNamePaciente(int dni);
        IEnumerable<Paciente> GetAllporDomicilio(int id);
        
    }
}
