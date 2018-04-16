using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsumeTheAPI.Controllers.Data;
using ConsumeTheAPI.Models;

namespace ConsumeTheAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/CommentCollection")]
    public class CommentCollectionController : Controller
    {
        private readonly ComicsDbContext _context;
        private object title;

        public CommentCollectionController(ComicsDbContext context)
        {
            _context = context;
        }

        // GET: api/CommentCollection
        [HttpGet]
        public IEnumerable<CommentCollection> GetCommentCollection()
        {
            return _context.CommentCollection;
        }

        // GET: api/CommentCollection/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentCollection([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CommentCollection commentCollection = await _context.CommentCollection.SingleOrDefaultAsync(m => m.Id == id);
            var Title = _context.Titles.Include(s => s.CommentCollection).Where(s => s.CommentCollection.Id == commentCollection.Id);

            commentCollection.Titles = title;

            object[] myObj = new object[] { commentCollection, title };
            if (Title == null)
            {
                return NotFound();
            }

            return Ok(myObj);
        }

        // PUT: api/CommentCollection/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentCollection([FromRoute] int id, [FromBody] CommentCollection commentCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commentCollection.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentCollectionExists(id))
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

        // POST: api/CommentCollection
        [HttpPost]
        public async Task<IActionResult> PostCommentCollection([FromBody] CommentCollection commentCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CommentCollection.Add(commentCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentCollection", new { id = commentCollection.Id }, commentCollection);
        }

        // DELETE: api/CommentCollection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentCollection([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentCollection = await _context.CommentCollection.SingleOrDefaultAsync(m => m.Id == id);
            if (commentCollection == null)
            {
                return NotFound();
            }

            _context.CommentCollection.Remove(commentCollection);
            await _context.SaveChangesAsync();

            return Ok(commentCollection);
        }

        private bool CommentCollectionExists(int id)
        {
            return _context.CommentCollection.Any(e => e.Id == id);
        }
    }
}