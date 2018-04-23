using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonCRUD.Models;
using Microsoft.EntityFrameworkCore;


namespace PokemonCRUD.Data
{
    public class PokemonContextDb :DbContext
    {
        public PokemonContextDb(DbContextOptions<PokemonContextDb> options) : base(options)
        {

        }

        public DbSet<Title> Titles { get; set; }

        public DbSet<PokemonCRUD.Models.Pokedex> Pokedex { get; set; }
        public DbSet<PokemonCRUD.Models.Pokemon> Pokemon { get; set; }
        public DbSet<PokemonCRUD.Models.Results> Results { get; set; }
    }
}
