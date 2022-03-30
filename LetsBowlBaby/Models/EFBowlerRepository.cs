using System;
using System.Linq;

namespace LetsBowlBaby.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlDBContext _context { get; set; }

        public EFBowlerRepository (BowlDBContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;
    }
}
