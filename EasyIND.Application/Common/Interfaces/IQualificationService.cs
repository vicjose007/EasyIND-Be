using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IQualificationService : IEntityCRUDService<Qualification, QualificationDto>
    {

        List<Qualification> GetAllQualifications();

        Qualification CreateQualification(Qualification qualification);

        Qualification DeleteQualification(Qualification qualification);

    }
}
