using System;
using System.Linq;


namespace LetsBowlBaby.Models
{
    public interface IBowlerRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void SaveBowler(Bowler bl);

        public void AddBowler(Bowler bl);

        public void DeleteBowler(Bowler bl);

    }
}
