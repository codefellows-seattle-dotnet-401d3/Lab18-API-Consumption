using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumeTheAPI.Controllers.Data;
using ConsumeTheAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumeTheAPI.Controllers
{
    [Route("api/Title")]
    public class TitleController : Controller
    {
        private readonly ComicsDbContext _context;

        public TitleController(ComicsDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Title> GetTitles()
        {
            return _context.Titles;  // Object does not contain a definition for 'Titles'... oh yes it does.  Line 19 in ComicsDbContext, Line 11 in Title.cs
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var title = await _context.Titles.SingleOrDefaultAsync(m => m.Id == id);

            if (title == null)
                return NotFound();

            return Ok(title);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostTitle([FromBody]Title title)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Titles.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle([FromRoute] int id, [FromBody]Title title)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != title.Id)
                return BadRequest();

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        private bool ListItemExists(int id)
        {
            return _context.Titles.Any(e => e.Id == id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
