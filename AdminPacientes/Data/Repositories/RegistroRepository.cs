using AdminPacientes.Data.Interfaces;
using AdminPacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Data.Repositories
{
    public class RegistroRepository : GenericRepository<Registro>, IRegistroRepository
    {
        public RegistroRepository(AdminContexto context) : base(context) { }



    }
}
