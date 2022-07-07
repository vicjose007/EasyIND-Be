using EasyIND.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Dtos
{
    public class QualificationDto : BaseEntityDto
    {
        public string QualificationResult { get; set; }

        public int UserId { get; set; }

        public int ProfessorId { get; set; }

        public int SubjectId { get; set; }
    }
}
