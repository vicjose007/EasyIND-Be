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
    public class AreaController : ControllerBase
    {
        public static Area area = new Area();
        private readonly IConfiguration _configuration;
        private readonly IAreaService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly EasyINDDbContext Context;



        public AreaController(IConfiguration configuration, IAreaService service, IHttpContextAccessor accessor, EasyINDDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet]
        public async Task<ActionResult<List<Area>>> Get()
        {
            return Ok(await Context.Areas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> Get(int id)
        {
            var area = await Context.Areas.FindAsync(id);
            if (area == null)
                return BadRequest("Area not found");
            return Ok(area);
        }

        [HttpPost]
        public async Task<ActionResult<List<Area>>> AddAreas([FromForm] AreaDto request)
        {

            area.AreaName = request.AreaName;
            PostArea(area);

            return Ok(area);
        }

        private Area PostArea(Area area)
        {

            var areaFromService = _service.CreateArea(area);
            return areaFromService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Area>>> UpdateAreas(int id, [FromForm] AreaDto request)
        {
            var area = await Context.Areas.FindAsync(id);
            if (area == null)
                return BadRequest("Area not found.");


            area.AreaName = request.AreaName;


            await Context.SaveChangesAsync();

            return Ok(await Context.Areas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Area>>> Delete(int id)
        {
            var area = await Context.Areas.FindAsync(id);
            if (area == null)
                return BadRequest("Area not found");

            Context.Areas.Remove(area);
            await Context.SaveChangesAsync();
            return Ok(await Context.Areas.ToListAsync());
        }
    }
}
