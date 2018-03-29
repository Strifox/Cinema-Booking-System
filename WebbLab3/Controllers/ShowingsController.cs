using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebbLab3;

namespace WebbLab3.Controllers
{
    public class ShowingsController : Controller
    {
        private readonly EntityContext _context;

        public ShowingsController(EntityContext context)
        {
            _context = context;
        }

        // GET: Showings
        public async Task<IActionResult> Index(string sorting)
        {
            ViewBag.DateTimeSorting = string.IsNullOrEmpty(sorting) ? "MovieDateTime_desc" : "";
            ViewBag.TicketsSorting = sorting == "Tickets_desc" ?  "Tickets_asc" : "Tickets_desc";


            var sortingContext = await _context.Showings
         .Where(s => s.MovieDateTime > DateTime.Now)
         .Include(s => s.Movie)
         .Include(s => s.Bookings)
         .Include(s => s.Salon)
         .ToListAsync();

            List<ShowingViewModel> sortingFilter = new List<ShowingViewModel>();

            foreach (var item in sortingContext)
            {
                sortingFilter.Add(new ShowingViewModel()
                {
                    Id = item.Id,
                    MovieId = item.MovieId,
                    MovieName = item.Movie.MovieName,
                    SalonName = item.Salon.SalonName,
                    MovieDateTime = item.MovieDateTime,
                    Tickets = item.Bookings.Sum(s => s.Tickets)
                });

            }


            switch (sorting)
            {
                case "MovieDateTime_desc":
                    sortingFilter = sortingFilter.OrderByDescending(s => s.MovieDateTime).ToList();
                    break;
                case "Tickets_desc":
                    sortingFilter = sortingFilter.OrderByDescending(s => s.Tickets).ToList();
                    break;
                case "Tickets_asc":
                    sortingFilter = sortingFilter.OrderBy(s => s.Tickets).ToList();
                    break;
                default:
                    sortingFilter = sortingFilter.OrderBy(s => s.MovieDateTime).ToList();
                    break;
            }

            return View(sortingFilter);
        }


        // GET: Showings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.Showings
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // GET: Showings/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id");
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieDateTime,MovieId,SalonId")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", showing.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", showing.SalonId);
            return View(showing);
        }

        // GET: Showings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.Showings.SingleOrDefaultAsync(m => m.Id == id);
            if (showing == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", showing.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", showing.SalonId);
            return View(showing);
        }

        // POST: Showings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieDateTime,MovieId,SalonId")] Showing showing)
        {
            if (id != showing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowingExists(showing.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", showing.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", showing.SalonId);
            return View(showing);
        }

        // GET: Showings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showing = await _context.Showings
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (showing == null)
            {
                return NotFound();
            }

            return View(showing);
        }

        // POST: Showings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showing = await _context.Showings.SingleOrDefaultAsync(m => m.Id == id);
            _context.Showings.Remove(showing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowingExists(int id)
        {
            return _context.Showings.Any(e => e.Id == id);
        }
    }
}
