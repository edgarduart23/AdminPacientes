﻿using AdminPacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Data.Interfaces
{
    public interface IObraSocialRepository: IGenericRepository<ObraSocial>
    {
        Task<ObraSocial> GetByName(string nombre);
        IEnumerable<ObraSocial> GetAllpor(int id);
    }
}
