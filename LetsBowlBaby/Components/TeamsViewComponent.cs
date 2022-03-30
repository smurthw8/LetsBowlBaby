using System;
using System.Linq;
using LetsBowlBaby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetsBowlBaby.Components
{
    public class TeamsViewComponent : ViewComponent
    {

        private IBowlerRepository repo { get; set; }

        //when class build, need to bring in Irepository called temp
        public TeamsViewComponent(IBowlerRepository temp)
        {
            repo = temp;

        }
        public IViewComponentResult Invoke()
        {
            //? > makes something "nullable" > ok if it's null
            ViewBag.SelectedTeam = RouteData?.Values["team"];

            //bring in repo, select distinct colomns entries to filter by
            var teamslist = repo.Teams.Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x).ToList();
            //return thing to filterby to view
            return View(teamslist);
        }

    }
}
