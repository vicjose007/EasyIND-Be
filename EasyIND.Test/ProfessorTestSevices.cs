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
    public class ProfessorTestServices : BaseTestService
    {
        [Fact]
        public void Create_Professor_Test()
        {

            var testProfessor = new Professor()
            {
                ProfessorName = "TestProfessor",

            };

            professorService.CreateProfessor(testProfessor);
            var result = professorService.GetById(1);

            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Professor_Test()
        {

            var testProfessor = new Professor()
            {
                ProfessorName = "TestProfessor",
            };

            professorService.CreateProfessor(testProfessor);
            var result = professorService.DeleteProfessor(testProfessor);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Professor_Test()
        {
            var testProfessor = new Professor()
            {
                ProfessorName = "TestProfessor",
            };
            var testProfessorDto = new ProfessorDto()
            {
                Id = 1,
                ProfessorName = "TestProfessor2",
            };

            professorService.CreateProfessor(testProfessor);
            var updatedProfessor = await professorService.Update(1, testProfessorDto);


            Assert.NotNull(updatedProfessor);
            Assert.Equal(updatedProfessor.ProfessorName, testProfessorDto.ProfessorName);
        }
    }
}
