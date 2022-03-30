using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LetsBowlBaby.Models;
using Microsoft.EntityFrameworkCore;
using LetsBowlBaby.Models.ViewModels;

namespace LetsBowlBaby.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository _repo { get; set; }

        public HomeController(IBowlerRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string team)
        {
            //List<Team> Teams = _repo.Teams.ToList();
            //ViewBag.roster = _repo.Bowlers
            //    .Include(x => x.Team)
            //    .ToList();

            var viewmod = new BowlBabyViewModel
            {
                //where > filters to where category = category passed in OR | if no category specified
                Bowlers = _repo.Bowlers.Include(x => x.Team)
                .Where(p => p.Team.TeamName == team || team == null)
                .OrderBy(p => p.BowlerLastName),

            };

            return View(viewmod);
        }

    }
}
