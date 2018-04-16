using Lab18Magic.Data;
using Lab18Magic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Magic.Controllers
{

    public class DeckController : Controller
    {
        private readonly DeckDBContext _context;

        public DeckController(DeckDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string deck, string search)
        {
            IQueryable<string> deckQuery = from d in _context.Decks
                                           orderby d.Name
                                           select d.Name;

            var decks = from d in _context.Decks select d;

            if (!String.IsNullOrEmpty(search))
            {
                decks = decks.Where(d => d.Name.Contains(search));
            }
            if (!String.IsNullOrEmpty(deck))
            {
                decks = decks.Where(d => d.Name == deck);
            }

            var deckNameVM = new DeckViewModel();
            deckNameVM.name = new SelectList(await deckQuery.Distinct().ToListAsync());
            deckNameVM.decks = await decks.ToListAsync();

            return View(deckNameVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deck = await _context.Decks.SingleOrDefaultAsync(d => d.ID == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Type,CompletedBuild")] Deck deck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(deck);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deck = await _context.Decks.SingleOrDefaultAsync(d => d.ID == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Type,Card")] Deck deck)
        {
            if (id != deck.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckExists(deck.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(deck);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var deck = await _context.Decks.SingleOrDefaultAsync(d => d.ID == id);
            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckExists(int id)
        {
            return _context.Decks.Any(d => d.ID == id);
        }
    }
}
