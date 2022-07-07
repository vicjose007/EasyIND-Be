using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Dtos;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyIND.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        public static Registro registro = new Registro();
        private readonly IConfiguration _configuration;
        private readonly IRegistroService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly EasyINDDbContext Context;



        public RegistroController(IConfiguration configuration, IRegistroService service, IHttpContextAccessor accessor, EasyINDDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet]
        public async Task<ActionResult<List<Registro>>> Get()
        {
            return Ok(await Context.Registros.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> Get(int id)
        {
            var registro = await Context.Registros.FindAsync(id);
            if (registro == null)
                return BadRequest("Registro not found");
            return Ok(registro);
        }

        [HttpPost]
        public async Task<ActionResult<List<Registro>>> AddRegistros([FromForm] RegistroDto request)
        {

            registro.Rol = request.Rol;
            registro.Details = request.Details;
            registro.CareerId = request.CareerId;


            PostRegistro(registro);

            return Ok(registro);
        }

        private Registro PostRegistro(Registro registro)
        {

            var registroFromService = _service.CreateRegistro(registro);
            return registroFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Registro>>> UpdateRegistros(int id, [FromForm] RegistroDto request)
        {
            var registro = await Context.Registros.FindAsync(id);
            if (registro == null)
                return BadRequest("Registro not found.");


            registro.Rol = request.Rol;
            registro.Details = request.Details;
            registro.CareerId = request.CareerId;


            await Context.SaveChangesAsync();

            return Ok(await Context.Registros.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Registro>>> Delete(int id)
        {
            var registro = await Context.Registros.FindAsync(id);
            if (registro == null)
                return BadRequest("Registro not found");

            Context.Registros.Remove(registro);
            await Context.SaveChangesAsync();
            return Ok(await Context.Registros.ToListAsync());
        }
    }
}
