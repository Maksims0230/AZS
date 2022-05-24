using Microsoft.AspNetCore.Mvc;

namespace AzsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DatasController : ControllerBase
    {
        private readonly Context.AzsDbContext _context;

        public DatasController(Context.AzsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Data?>> Get(int id)
        {
            if (_context.Datas is null) return NotFound();
            if (id is 0 or < 0) return BadRequest();
            return await _context.Datas.FindAsync(id);
        }
    }
}
