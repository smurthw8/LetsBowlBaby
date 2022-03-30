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

        public void SaveBowler(Bowler bl)
        {
            _context.Update(bl);
            _context.SaveChanges();
        }
        public void AddBowler(Bowler bl)
        {
            _context.Add(bl);
            _context.SaveChanges();
        }
        public void DeleteBowler(Bowler bl)
        {
            _context.Remove(bl);
            _context.SaveChanges();
        }
    }
}
