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
    [Route("api/MoviesModels")]
    public class MoviesModelsController : Controller
    {
        private readonly MoviesContext _context;

        public MoviesModelsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/MoviesModels
        [HttpGet]
        public IEnumerable<MoviesModel> GetMovies()
        {
            return _context.Movies;
        }

        // GET: api/MoviesModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoviesModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moviesModel = await _context.Movies.SingleOrDefaultAsync(m => m.id == id);

            if (moviesModel == null)
            {
                return NotFound();
            }

            return Ok(moviesModel);
        }

        // PUT: api/MoviesModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesModel([FromRoute] int id, [FromBody] MoviesModel moviesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moviesModel.id)
            {
                return BadRequest();
            }

            _context.Entry(moviesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesModelExists(id))
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

        // POST: api/MoviesModels
        [HttpPost]
        public async Task<IActionResult> PostMoviesModel([FromBody] MoviesModel moviesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Movies.Add(moviesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviesModel", new { id = moviesModel.id }, moviesModel);
        }

        // DELETE: api/MoviesModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoviesModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moviesModel = await _context.Movies.SingleOrDefaultAsync(m => m.id == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(moviesModel);
            await _context.SaveChangesAsync();

            return Ok(moviesModel);
        }

        private bool MoviesModelExists(int id)
        {
            return _context.Movies.Any(e => e.id == id);
        }
    }
}