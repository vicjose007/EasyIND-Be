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
    public class SubjectService : EntityCRUDService<Subject, SubjectDto>, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, ISubjectRepository subjectRepository)
            : base(mapper, uow)
        {
            _subjectRepository = subjectRepository;
        }
        public Subject CreateSubject(Subject subject)
        {
            _subjectRepository.CreateSubject(subject);
            return subject;
        }

        public Subject DeleteSubject(Subject subject)
        {
            _subjectRepository.DeleteSubject(subject);
            return subject;
        }
        public List<Subject> GetAllSubjects()
        {
            var subjects = _subjectRepository.GetAllSubjects();

            return subjects;
        }
    }
}
