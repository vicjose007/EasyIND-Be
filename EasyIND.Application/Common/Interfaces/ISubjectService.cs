using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface ISubjectService : IEntityCRUDService<Subject, SubjectDto>
    {
        
        List<Subject> GetAllSubjects();

        Subject CreateSubject(Subject subject);

        Subject DeleteSubject(Subject subject);

    }
}
