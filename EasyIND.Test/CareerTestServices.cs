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
    public class CareerTestServices : BaseTestService
    {
        [Fact]
        public void Create_Career_Test()
        {

            var testCareer = new Career()
            {
                CareerName = "TestCareer2",
                AreaId = 1
            };

            careerService.CreateCareer(testCareer);
            var result = careerService.GetById(1);

            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Career_Test()
        {

            var testCareer = new Career()
            {
                CareerName = "TestCareer2",
                AreaId = 1
            };

            careerService.CreateCareer(testCareer);
            var result = careerService.DeleteCareer(testCareer);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Career_Test()
        {
            var testCareer = new Career()
            {
                CareerName = "TestCareer"
            };
            var testCareerDto = new CareerDto()
            {
                Id = 1,
                CareerName = "TestCareer2",
                AreaId = 1
            };

            careerService.CreateCareer(testCareer);
            var updatedCareer = await careerService.Update(1, testCareerDto);


            Assert.NotNull(updatedCareer);
            Assert.Equal(updatedCareer.CareerName, testCareerDto.CareerName);
        }
    }
}
