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
    public class SubjectController : ControllerBase
    {
        public static Subject subject = new Subject();
        private readonly IConfiguration _configuration;
        private readonly ISubjectService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly EasyINDDbContext Context;



        public SubjectController(IConfiguration configuration, ISubjectService service, IHttpContextAccessor accessor, EasyINDDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            return Ok(await Context.Subjects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> Get(int id)
        {
            var subject = await Context.Subjects.FindAsync(id);
            if (subject == null)
                return BadRequest("Subject not found");
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<List<Subject>>> AddSubjects([FromForm] SubjectDto request)
        {

            subject.SubjectName = request.SubjectName;
            subject.AreaId = request.AreaId;


            PostSubject(subject);

            return Ok(subject);
        }

        private Subject PostSubject(Subject subject)
        {

            var subjectFromService = _service.CreateSubject(subject);
            return subjectFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Subject>>> UpdateSubjects(int id, [FromForm] SubjectDto request)
        {
            var subject = await Context.Subjects.FindAsync(id);
            if (subject == null)
                return BadRequest("Subject not found.");


            subject.SubjectName = request.SubjectName;
            subject.AreaId = request.AreaId;


            await Context.SaveChangesAsync();

            return Ok(await Context.Subjects.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subject>>> Delete(int id)
        {
            var subject = await Context.Subjects.FindAsync(id);
            if (subject == null)
                return BadRequest("Subject not found");

            Context.Subjects.Remove(subject);
            await Context.SaveChangesAsync();
            return Ok(await Context.Subjects.ToListAsync());
        }
    }
}
