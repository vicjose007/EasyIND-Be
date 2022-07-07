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
    public class ProfessorRepository : IProfessorRepository
    {
        public static List<Professor> professors = new List<Professor>()
        {

        };
        private readonly EasyINDDbContext _professorDbContext;

        public ProfessorRepository(EasyINDDbContext professorDbContext)
        {
            _professorDbContext = professorDbContext;
        }

        public Professor CreateProfessor(Professor professor)
        {
            _professorDbContext.Professors.Add(professor);
            _professorDbContext.SaveChanges();
            return professor;
        }

        public Professor DeleteProfessor(Professor professor)
        {
            _professorDbContext.Professors.Remove(professor);
            _professorDbContext.SaveChanges();

            return null;
        }

        public List<Professor> GetAllProfessors()
        {
            return _professorDbContext.Professors.ToList();
        }

    }
}
