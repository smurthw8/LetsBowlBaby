using System;
using Microsoft.EntityFrameworkCore;

namespace LetsBowlBaby.Models
{
    public class BowlDBContext : DbContext
    {
        public BowlDBContext(DbContextOptions<BowlDBContext> options) :base (options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
