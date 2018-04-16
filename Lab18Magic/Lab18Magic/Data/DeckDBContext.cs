using Lab18Magic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Magic.Data
{
    public class DeckDBContext : DbContext
    {
        public DeckDBContext(DbContextOptions<DeckDBContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
    }
}
