using AzsWebApi.Context;
using AzsWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzsWebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly AzsDbContext _context;

        public StationsController(AzsDbContext context)
        {
            _context = context;
        }

        [HttpGet("getStationInfo")]
        public async Task<ActionResult<object>> Get(int id)
        {
            if (_context.Stations is null) return NotFound();
            if (id is <= 0 or >= 100) return NotFound();
            var station = await _context.Stations.FindAsync(id);
            if (station is null) return NotFound();

            return new { station.Station_ID, station.Address };
        }

        [HttpGet("stations")]
        public ActionResult<IEnumerable<object>> Get(string fuel)
        {
            if (_context.Stations is null) return NotFound();
            if (fuel is null) return BadRequest();
            if (fuel is { Length: 0 }) return NotFound();

            if (fuel.Equals("DT"))
                fuel = "Disel Fuel";

            var value = _context.Stations.Include(station => station.Data)
                .Where(station => station.Data.Any(data => data.Name == fuel))
                .Select(station =>
                new
                {
                    station.Station_ID,
                    station.Address,
                    station.Data.FirstOrDefault(data => data.Name == fuel)!.Price
                });

            return new ActionResult<IEnumerable<object>>(value);
        }

        [HttpPost("setStation")]
        public async Task<IActionResult> PostAsync(Station? station)
        {
            if (station is null) return BadRequest();
            if (_context.Stations.Any(x => x.Station_ID == station.Station_ID))
            {
                foreach (var data in station.Data)
                    _context.Entry(data).State = EntityState.Modified;
                _context.Entry(station).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            await _context.Stations.AddAsync(station);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id is <= 0 or >= 100) return NotFound();
            var station = await _context.Stations.FindAsync(id);
            if (station is null) return NotFound();
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
