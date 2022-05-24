using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBase
    {
        private readonly Context.AzsDbContext _context;

        public FuelTypesController(Context.AzsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.FuelType>>> Get()
        {
            if (_context.FuelTypes is null) return NotFound();
            return await _context.FuelTypes.ToListAsync();
        }
    }
}
