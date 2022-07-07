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
    public class QualificationController : ControllerBase
    {
        public static Qualification qualification = new Qualification();
        private readonly IConfiguration _configuration;
        private readonly IQualificationService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly EasyINDDbContext Context;



        public QualificationController(IConfiguration configuration, IQualificationService service, IHttpContextAccessor accessor, EasyINDDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet]
        public async Task<ActionResult<List<Qualification>>> Get()
        {
            return Ok(await Context.Qualifications.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Qualification>> Get(int id)
        {
            var qualification = await Context.Qualifications.FindAsync(id);
            if (qualification == null)
                return BadRequest("Qualification not found");
            return Ok(qualification);
        }

        [HttpPost]
        public async Task<ActionResult<List<Qualification>>> AddQualifications([FromForm] QualificationDto request)
        {

            qualification.QualificationResult = request.QualificationResult;
            qualification.ProfessorId = request.ProfessorId;
            qualification.UserId = request.UserId;
            qualification.SubjectId = request.SubjectId;


            PostQualification(qualification);

            return Ok(qualification);
        }

        private Qualification PostQualification(Qualification qualification)
        {

            var qualificationFromService = _service.CreateQualification(qualification);
            return qualificationFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Qualification>>> UpdateQualifications(int id, [FromForm] QualificationDto request)
        {
            var qualification = await Context.Qualifications.FindAsync(id);
            if (qualification == null)
                return BadRequest("Qualification not found.");


            qualification.QualificationResult = request.QualificationResult;
            qualification.ProfessorId = request.ProfessorId;
            qualification.UserId = request.UserId;
            qualification.SubjectId = request.SubjectId;


            await Context.SaveChangesAsync();

            return Ok(await Context.Qualifications.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Qualification>>> Delete(int id)
        {
            var qualification = await Context.Qualifications.FindAsync(id);
            if (qualification == null)
                return BadRequest("Qualification not found");

            Context.Qualifications.Remove(qualification);
            await Context.SaveChangesAsync();
            return Ok(await Context.Qualifications.ToListAsync());
        }
    }
}
