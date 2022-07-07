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
    public class QualificationRepository : IQualificationRepository
    {
        public static List<Qualification> Qualifications = new List<Qualification>()
        {

        };
        private readonly EasyINDDbContext _qualificationDbContext;

        public QualificationRepository(EasyINDDbContext qualificationDbContext)
        {
            _qualificationDbContext = qualificationDbContext;
        }

        public Qualification CreateQualification(Qualification qualification)
        {
            _qualificationDbContext.Qualifications.Add(qualification);
            _qualificationDbContext.SaveChanges();
            return qualification;
        }

        public Qualification DeleteQualification(Qualification qualification)
        {
            _qualificationDbContext.Qualifications.Remove(qualification);
            _qualificationDbContext.SaveChanges();

            return null;
        }

        public List<Qualification> GetAllQualifications()
        {
            return _qualificationDbContext.Qualifications.ToList();
        }

    }
}
