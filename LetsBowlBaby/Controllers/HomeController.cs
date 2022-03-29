using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LetsBowlBaby.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsBowlBaby.Controllers
{
    public class HomeController : Controller
    {
        private BowlDBContext _context { get; set; }

        public HomeController(BowlDBContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.ToList();
            var blah = _context.Bowlers
                .Include(x => x.Team)
                .ToList();
            return View(blah);
        }

    }
}
