using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyIND.Test
{
    public class QualificationTestServices : BaseTestService
    {
        [Fact]
        public void Create_Qualification_Test()
        {

            var testQualification = new Qualification()
            {
                QualificationResult = "A",
                UserId = 1,
                ProfessorId = 1,
                SubjectId = 1

            };

            qualificationService.CreateQualification(testQualification);
            var result = qualificationService.GetById(1);

            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Qualification_Test()
        {

            var testQualification = new Qualification()
            {
                QualificationResult = "A",
                UserId = 1,
                ProfessorId = 1,
                SubjectId = 1
            };

            qualificationService.CreateQualification(testQualification);
            var result = qualificationService.DeleteQualification(testQualification);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Qualification_Test()
        {
            var testQualification = new Qualification()
            {
                QualificationResult = "A",
                UserId = 1,
                ProfessorId = 1,
                SubjectId = 1
            };
            var testQualificationDto = new QualificationDto()
            {
                Id = 1,
                QualificationResult = "B",
                UserId = 2,
                ProfessorId = 2,
                SubjectId = 2
            };

            qualificationService.CreateQualification(testQualification);
            var updatedQualification = await qualificationService.Update(1, testQualificationDto);


            Assert.NotNull(updatedQualification);
            Assert.Equal(updatedQualification.QualificationResult, testQualificationDto.QualificationResult);
            Assert.Equal(updatedQualification.UserId, testQualificationDto.UserId);
            Assert.Equal(updatedQualification.ProfessorId, testQualificationDto.ProfessorId);
            Assert.Equal(updatedQualification.SubjectId, testQualificationDto.SubjectId);
        }
    }
}
