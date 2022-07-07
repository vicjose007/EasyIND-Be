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
    public class CareerRepository : ICareerRepository
    {
        public static List<Career> Careers = new List<Career>()
        {

        };
        private readonly EasyINDDbContext _careerDbContext;

        public CareerRepository(EasyINDDbContext careerDbContext)
        {
            _careerDbContext = careerDbContext;
        }

        public Career CreateCareer(Career career)
        {
            _careerDbContext.Careers.Add(career);
            _careerDbContext.SaveChanges();
            return career;
        }

        public Career DeleteCareer(Career career)
        {
            _careerDbContext.Careers.Remove(career);
            _careerDbContext.SaveChanges();

            return null;
        }

        public List<Career> GetAllCareers()
        {
            return _careerDbContext.Careers.ToList();
        }

    }
}
