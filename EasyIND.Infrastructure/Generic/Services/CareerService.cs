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

    public class CareerService : EntityCRUDService<Career, CareerDto>, ICareerService
    {
        private readonly ICareerRepository _careerRepository;
        public CareerService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow, ICareerRepository careerRepository)
            : base(mapper, uow)
        {
            _careerRepository = careerRepository;
        }
        public Career CreateCareer(Career career)
        {
            _careerRepository.CreateCareer(career);
            return career;
        }

        public Career DeleteCareer(Career career)
        {
            _careerRepository.DeleteCareer(career);
            return career;
        }
        public List<Career> GetAllCareers()
        {
            var careers = _careerRepository.GetAllCareers();

            return careers;
        }
    }
}
