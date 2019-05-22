using AdminPacientes.Data.Interfaces;
using AdminPacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdminPacientes.Data.Repositories
{
    public class ObraSocialRepository: GenericRepository<ObraSocial>, IObraSocialRepository
    {
        public ObraSocialRepository(AdminContexto context) : base(context) { }

        public Task<ObraSocial> GetByName(string nombre)
            => FirstOrDefault(w => w.Nombre == nombre);

        
    }
}
