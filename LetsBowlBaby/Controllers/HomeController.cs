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
            ViewBag.Selectedteam = team;

            var viewmod = new BowlBabyViewModel
            {
                //where > filters to where category = category passed in OR | if no category specified
                Bowlers = _repo.Bowlers.Include(x => x.Team)
                .Where(p => p.Team.TeamName == team || team == null)
                .OrderBy(p => p.BowlerLastName),

            };

            return View(viewmod);
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _repo.Teams.ToList();

            //ToString pull record using Find (then do itar by ID), or Single (expects criteria to find 1 entry)
            //finds Films object where FilmId == paramater filmid
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Add", bowler);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            Bowler b = new Bowler();
            return View(b);
        }

        [HttpPost]
        public IActionResult Edit(Bowler bl)
        {
            if (ModelState.IsValid)
            {
                if (bl.BowlerID == 0)
                {
                    _repo.AddBowler(bl);
                    //int max = _repo.Bowlers.Max(p => p.BowlerID);
                    //bl.BowlerID = max + 1;
                }
                else
                {
                    _repo.SaveBowler(bl);
                }
                //need to redirecttoaction, or pass in all Film Collection data again
                return RedirectToAction("Index");
            }
            else
            {
                return View(bl);
            }

        }

        //pass in model feilds for specific row > need to pass in Id as hidden feild on delete page
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            _repo.DeleteBowler(bowler);

            return RedirectToAction("Index");
        }

    }
}
