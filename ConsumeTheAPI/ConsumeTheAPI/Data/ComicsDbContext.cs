using ConsumeTheAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeTheAPI.Controllers.Data
{
    public class ComicsDbContext : DbContext
    {
        public ComicsDbContext(DbContextOptions<ComicsDbContext> options) : base(options)
        {

        }

        // Database tables

        public DbSet<Title> Titles { get; set; }

        // Database tables

        public DbSet<ConsumeTheAPI.Models.CommentCollection> CommentCollection { get; set; }
    }
}
