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

    public class ProfessorService : EntityCRUDService<Professor, ProfessorDto>, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, IProfessorRepository professorRepository)
            : base(mapper, uow)
        {
            _professorRepository = professorRepository;
        }
        public Professor CreateProfessor(Professor professor)
        {
            _professorRepository.CreateProfessor(professor);
            return professor;
        }

        public Professor DeleteProfessor(Professor professor)
        {
            _professorRepository.DeleteProfessor(professor);
            return professor;
        }
        public List<Professor> GetAllProfessors()
        {
            var professors = _professorRepository.GetAllProfessors();

            return professors;
        }
    }
}
