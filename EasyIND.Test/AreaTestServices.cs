using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace EasyIND.Test
{
    public class AreaTestServices : BaseTestService
    {
        [Fact]
        public void Create_Area_Test()
        {

            var testArea = new Area()
            {
                AreaName = "Test"
            };

            areaService.CreateArea(testArea);
            var result= areaService.GetById(1);

            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Area_Test()
        {

            var testArea = new Area()
            {
                AreaName = "Test"
            };

            areaService.CreateArea(testArea);
            var result = areaService.DeleteArea(testArea);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Area_Test()
        {
            var testArea = new Area()
            {
                AreaName = "TestArea"
            };
            var testAreaDto = new AreaDto()
            {
                Id = 1,
                AreaName = "TestArea2"
            };

            areaService.CreateArea(testArea);
            var updatedArea = await areaService.Update(1, testAreaDto);


            Assert.NotNull(updatedArea);
            Assert.Equal(updatedArea.AreaName, testAreaDto.AreaName);
        }
    }
}