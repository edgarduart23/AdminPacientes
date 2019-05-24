using AdminPacientes.Data.Interfaces;
using AdminPacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Data.Repositories
{
    public class DomicilioRepository : GenericRepository<Domicilio>,IDomicilioRepository
    {
        public DomicilioRepository(AdminContexto context) : base(context) { }
    
    }
}
