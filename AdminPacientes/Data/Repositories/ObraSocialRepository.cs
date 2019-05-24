using AdminPacientes.Data.Interfaces;
using AdminPacientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdminPacientes.Data.Repositories
{
    public class ObraSocialRepository: GenericRepository<ObraSocial>, IObraSocialRepository
    {
        

        public ObraSocialRepository(AdminContexto context) : base(context) {  }

        public Task<ObraSocial> GetByName(string nombre)
            => FirstOrDefault(w => w.Nombre == nombre);
        public IEnumerable<ObraSocial> GetAllpor(int id)
        {
            return Context.ObraSociales.Include(x => x.Pacientes);
         }

    }
}
