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
    public class ProfessorController : ControllerBase
    {
        public static Professor professor = new Professor();
        private readonly IConfiguration _configuration;
        private readonly IProfessorService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly EasyINDDbContext Context;



        public ProfessorController(IConfiguration configuration, IProfessorService service, IHttpContextAccessor accessor, EasyINDDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet]
        public async Task<ActionResult<List<Professor>>> Get()
        {
            return Ok(await Context.Professors.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> Get(int id)
        {
            var professor = await Context.Professors.FindAsync(id);
            if (professor == null)
                return BadRequest("Professor not found");
            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<List<Professor>>> AddProfessors([FromForm] ProfessorDto request)
        {

            professor.ProfessorName = request.ProfessorName;
            professor.Description = request.Description;


            PostProfessor(professor);

            return Ok(professor);
        }

        private Professor PostProfessor(Professor professor)
        {

            var professorFromService = _service.CreateProfessor(professor);
            return professorFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Professor>>> UpdateProfessors(int id, [FromForm] ProfessorDto request)
        {
            var professor = await Context.Professors.FindAsync(id);
            if (professor == null)
                return BadRequest("Professor not found.");


            professor.ProfessorName = request.ProfessorName;
            professor.Description = request.Description;


            await Context.SaveChangesAsync();

            return Ok(await Context.Professors.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Professor>>> Delete(int id)
        {
            var professor = await Context.Professors.FindAsync(id);
            if (professor == null)
                return BadRequest("Professor not found");

            Context.Professors.Remove(professor);
            await Context.SaveChangesAsync();
            return Ok(await Context.Professors.ToListAsync());
        }
    }
}
