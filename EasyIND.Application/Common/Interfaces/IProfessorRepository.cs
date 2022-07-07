using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IProfessorRepository
    {
        List<Professor> GetAllProfessors();

        Professor CreateProfessor(Professor professor);

        Professor DeleteProfessor(Professor professor);


    }
}
