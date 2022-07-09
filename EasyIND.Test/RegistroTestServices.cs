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
    public class RegistroTestServices : BaseTestService
    {
        [Fact]
        public void Create_Registro_Test()
        {

            var testRegistro = new Registro()
            {
                Rol = "Admin",
                Details = "Test",
                CareerId = 1

            };

            registroService.CreateRegistro(testRegistro);
            var result = registroService.GetById(1);

            Assert.NotNull(result);
        }
        [Fact]
        public void Delete_Registro_Test()
        {

            var testRegistro = new Registro()
            {
                Rol = "Admin",
                Details = "Test",
                CareerId = 1
            };

            registroService.CreateRegistro(testRegistro);
            var result = registroService.DeleteRegistro(testRegistro);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Registro_Test()
        {
            var testRegistro = new Registro()
            {
                Rol = "Admin",
                Details = "Test",
                CareerId = 1
            };
            var testRegistroDto = new RegistroDto()
            {
                Id = 1,
                Rol = "Cliente",
                Details = "Test2",
                CareerId = 2

            };

            registroService.CreateRegistro(testRegistro);
            var updatedRegistro = await registroService.Update(1, testRegistroDto);


            Assert.NotNull(updatedRegistro);
            Assert.Equal(updatedRegistro.Rol, testRegistroDto.Rol);
            Assert.Equal(updatedRegistro.Details, testRegistroDto.Details);
            Assert.Equal(updatedRegistro.CareerId, testRegistroDto.CareerId);
        }
    }
}
