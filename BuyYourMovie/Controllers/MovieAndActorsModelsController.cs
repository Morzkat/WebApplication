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
    [Route("api/MovieAndActorsModels")]
    public class MovieAndActorsModelsController : Controller
    {
        private readonly MovieAndActorsContext _context;

        public MovieAndActorsModelsController(MovieAndActorsContext context)
        {
            _context = context;
        }

        // GET: api/MovieAndActorsModels
        [HttpGet]
        public IEnumerable<MovieAndActorsModel> GetMovieAndActors()
        {
            return _context.MovieAndActors;
        }

        // GET: api/MovieAndActorsModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieAndActorsModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieAndActorsModel = await _context.MovieAndActors.SingleOrDefaultAsync(m => m.id == id);

            if (movieAndActorsModel == null)
            {
                return NotFound();
            }

            return Ok(movieAndActorsModel);
        }

        // PUT: api/MovieAndActorsModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieAndActorsModel([FromRoute] int id, [FromBody] MovieAndActorsModel movieAndActorsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieAndActorsModel.id)
            {
                return BadRequest();
            }

            _context.Entry(movieAndActorsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieAndActorsModelExists(id))
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

        // POST: api/MovieAndActorsModels
        [HttpPost]
        public async Task<IActionResult> PostMovieAndActorsModel([FromBody] MovieAndActorsModel movieAndActorsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MovieAndActors.Add(movieAndActorsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieAndActorsModel", new { id = movieAndActorsModel.id }, movieAndActorsModel);
        }

        // DELETE: api/MovieAndActorsModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAndActorsModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieAndActorsModel = await _context.MovieAndActors.SingleOrDefaultAsync(m => m.id == id);
            if (movieAndActorsModel == null)
            {
                return NotFound();
            }

            _context.MovieAndActors.Remove(movieAndActorsModel);
            await _context.SaveChangesAsync();

            return Ok(movieAndActorsModel);
        }

        private bool MovieAndActorsModelExists(int id)
        {
            return _context.MovieAndActors.Any(e => e.id == id);
        }
    }
}