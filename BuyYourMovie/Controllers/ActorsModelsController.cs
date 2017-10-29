using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuyYourMovie.DataLayer;
using BuyYourMovie.Models;

namespace BuyYourMovie.Controllers
{
    [Produces("application/json")]
    [Route("api/ActorsModels")]
    public class ActorsModelsController : Controller
    {
        private readonly ActorsContext _context;

        public ActorsModelsController(ActorsContext context)
        {
            _context = context;
        }

        // GET: api/ActorsModels
        [HttpGet]
        public IEnumerable<ActorsModel> GetActors()
        {
            return _context.Actors;
        }

        // GET: api/ActorsModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorsModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actorsModel = await _context.Actors.SingleOrDefaultAsync(m => m.id == id);

            if (actorsModel == null)
            {
                return NotFound();
            }

            return Ok(actorsModel);
        }

        // PUT: api/ActorsModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActorsModel([FromRoute] int id, [FromBody] ActorsModel actorsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actorsModel.id)
            {
                return BadRequest();
            }

            _context.Entry(actorsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActorsModels
        [HttpPost]
        public async Task<IActionResult> PostActorsModel([FromBody] ActorsModel actorsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Actors.Add(actorsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActorsModel", new { id = actorsModel.id }, actorsModel);
        }

        // DELETE: api/ActorsModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActorsModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actorsModel = await _context.Actors.SingleOrDefaultAsync(m => m.id == id);
            if (actorsModel == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actorsModel);
            await _context.SaveChangesAsync();

            return Ok(actorsModel);
        }

        private bool ActorsModelExists(int id)
        {
            return _context.Actors.Any(e => e.id == id);
        }
    }
}