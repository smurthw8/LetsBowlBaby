using System;
using System.Linq;

namespace LetsBowlBaby.Models.ViewModels
{
    public class BowlBabyViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
        public IQueryable<Team> Teams { get; set; }
        //public string SelectedTeam { get; set; }
    }

}
