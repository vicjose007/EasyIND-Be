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
    public class SubjectRepository : ISubjectRepository
    {
        public static List<Subject> subjects = new List<Subject>()
        {

        };
        private readonly EasyINDDbContext _subjectDbContext;

        public SubjectRepository(EasyINDDbContext subjectDbContext)
        {
            _subjectDbContext = subjectDbContext;
        }

        public Subject CreateSubject(Subject subject)
        {
            _subjectDbContext.Subjects.Add(subject);
            _subjectDbContext.SaveChanges();
            return subject;
        }

        public Subject DeleteSubject(Subject subject)
        {
            _subjectDbContext.Subjects.Remove(subject);
            _subjectDbContext.SaveChanges();

            return null;
        }

        public List<Subject> GetAllSubjects()
        {
            return _subjectDbContext.Subjects.ToList();
        }

    }
}
