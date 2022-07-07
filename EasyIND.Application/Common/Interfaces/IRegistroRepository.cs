using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IRegistroRepository
    {
        List<Registro> GetAllRegistros();

        Registro CreateRegistro(Registro registro);

        Registro DeleteRegistro(Registro registroId);


    }
}
