using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPacientes.Data.Interfaces
{
   public interface IUnifOfWork : IDisposable
    {
        IObraSocialRepository ObraSocial { get;}
        int Complete();
    }
}
