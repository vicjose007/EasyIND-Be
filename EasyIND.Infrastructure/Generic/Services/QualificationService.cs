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

    public class QualificationService : EntityCRUDService<Qualification, QualificationDto>, IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository;
        public QualificationService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, IQualificationRepository qualificationRepository)
            : base(mapper, uow)
        {
            _qualificationRepository = qualificationRepository;
        }
        public Qualification CreateQualification(Qualification qualification)
        {
            _qualificationRepository.CreateQualification(qualification);
            return qualification;
        }

        public Qualification DeleteQualification(Qualification qualification)
        {
            _qualificationRepository.DeleteQualification(qualification);
            return qualification;
        }
        public List<Qualification> GetAllQualifications()
        {
            var qualifications = _qualificationRepository.GetAllQualifications();

            return qualifications;
        }
    }
}
