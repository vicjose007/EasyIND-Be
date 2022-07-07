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
    public class CareerController : ControllerBase
    {
        public static Career career = new Career();
        private readonly IConfiguration _configuration;
        private readonly ICareerService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly EasyINDDbContext Context;



        public CareerController(IConfiguration configuration, ICareerService service, IHttpContextAccessor accessor, EasyINDDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet]
        public async Task<ActionResult<List<Career>>> Get()
        {
            return Ok(await Context.Careers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Career>> Get(int id)
        {
            var career = await Context.Careers.FindAsync(id);
            if (career == null)
                return BadRequest("Career not found");
            return Ok(career);
        }

        [HttpPost]
        public async Task<ActionResult<List<Career>>> AddCareers([FromForm] CareerDto request)
        {

            career.CareerName = request.CareerName;
            career.AreaId = request.AreaId;
            PostCareer(career);

            return Ok(career);
        }

        private Career PostCareer(Career career)
        {

            var careerFromService = _service.CreateCareer(career);
            return careerFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Career>>> UpdateCareers(int id, [FromForm] CareerDto request)
        {
            var career = await Context.Careers.FindAsync(id);
            if (career == null)
                return BadRequest("Career not found.");


            career.CareerName = request.CareerName;


            await Context.SaveChangesAsync();

            return Ok(await Context.Careers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Career>>> Delete(int id)
        {
            var career = await Context.Careers.FindAsync(id);
            if (career == null)
                return BadRequest("Career not found");

            Context.Careers.Remove(career);
            await Context.SaveChangesAsync();
            return Ok(await Context.Careers.ToListAsync());
        }
    }
}
