using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAllSubjects();

        Subject CreateSubject(Subject subject);

        Subject DeleteSubject(Subject subject);


    }
}
