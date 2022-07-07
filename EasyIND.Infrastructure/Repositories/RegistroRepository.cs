using EasyIND.Application.Common.Interfaces;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Infrastructure.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        public static List<Registro> Registros = new List<Registro>()
        {

        };
        private readonly EasyINDDbContext _registroDbContext;

        public RegistroRepository(EasyINDDbContext registroDbContext)
        {
            _registroDbContext = registroDbContext;
        }

        public Registro CreateRegistro(Registro registro)
        {
            _registroDbContext.Registros.Add(registro);
            _registroDbContext.SaveChanges();
            return registro;
        }

        public Registro DeleteRegistro(Registro registro)
        {
            _registroDbContext.Registros.Remove(registro);
            _registroDbContext.SaveChanges();

            return null;
        }

        public List<Registro> GetAllRegistros()
        {
            return _registroDbContext.Registros.ToList();
        }

    }
}
