using AutoMapper;
using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Infrastructure.Generic.Services
{

    public class RegistroService : EntityCRUDService<Registro, RegistroDto>, IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;
        public RegistroService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, IRegistroRepository registroRepository)
            : base(mapper, uow)
        {
            _registroRepository = registroRepository;
        }
        public Registro CreateRegistro(Registro registro)
        {
            _registroRepository.CreateRegistro(registro);
            return registro;
        }

        public Registro DeleteRegistro(Registro registro)
        {
            _registroRepository.DeleteRegistro(registro);
            return registro;
        }
        public List<Registro> GetAllRegistros()
        {
            var registros = _registroRepository.GetAllRegistros();

            return registros;
        }
    }
}
