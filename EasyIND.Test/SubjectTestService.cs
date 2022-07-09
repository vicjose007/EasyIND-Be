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
    public class SubjectTestServices : BaseTestService
    {
        [Fact]
        public void Create_Subject_Test()
        {

            var testSubject = new Subject()
            {
                SubjectName = "TestSubject",
                AreaId = 1
               
            };

            subjectService.CreateSubject(testSubject);
            var result = subjectService.GetById(1);

            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Subject_Test()
        {

            var testSubject = new Subject()
            {
                SubjectName = "TestSubject",
                AreaId = 1
            };

            subjectService.CreateSubject(testSubject);
            var result = subjectService.DeleteSubject(testSubject);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Subject_Test()
        {
            var testSubject = new Subject()
            {
                SubjectName = "TestSubject",
                AreaId = 1
            };
            var testSubjectDto = new SubjectDto()
            {
                Id = 1,
                SubjectName = "TestSubject2",
                AreaId = 1
            };

            subjectService.CreateSubject(testSubject);
            var updatedSubject = await subjectService.Update(1, testSubjectDto);


            Assert.NotNull(updatedSubject);
            Assert.Equal(updatedSubject.SubjectName, testSubjectDto.SubjectName);
        }
    }
}
