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
    public class BookingsController : Controller
    {
        private readonly EntityContext _context;

        public BookingsController(EntityContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index(string sorting)
        {
            var sortingContext = await _context.Showings
      .Where(s => s.MovieDateTime > DateTime.Now)
      .Include(s => s.Movie)
      .Include(s => s.Bookings)
      .Include(s => s.Salon)
      .ToListAsync();

            ViewBag.DateTimeSorting = string.IsNullOrEmpty(sorting) ? "MovieDateTime_desc" : "";
            ViewBag.TicketsSorting = sorting == "Tickets_desc" ? "Tickets_asc" : "Tickets_desc";


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
        public async Task<IActionResult> BookTickets()
        {
            var entityContext = _context.Bookings.Include(b => b.Showing).ThenInclude(m => m.Movie).Include(s => s.Showing.Salon);
            return View(await entityContext.ToListAsync());
        }



        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Showing).ThenInclude(m => m.Movie)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ShowingId"] = new SelectList(_context.Showings, "Id", "Id");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowingId,Tickets")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowingId"] = new SelectList(_context.Showings, "Id", "Id", booking.ShowingId);
            return View(booking);
        }


        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.SingleOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            ViewData["ShowingId"] = new SelectList(_context.Showings, "Id", "Id", booking.ShowingId);
            return View(booking);
        }

        //Method to SHOW book tickets (Used for Booking)
        public async Task<IActionResult> BookNow(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.Include(bookings => bookings.Showing).ThenInclude(movie => movie.Movie).SingleOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            ViewData["ShowingId"] = new SelectList(_context.Showings, "Id", "Id", booking.ShowingId);
            ViewBag.MaxAmount = booking.Tickets < 12 ? booking.Tickets : 12;
            return View(booking);
        }

        //Method to BOOK tickets (Used for Booking)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Booking(int? id, int tickets)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showingsquery = _context.Bookings.Include(s => s.Showing).ThenInclude(m => m.Movie)
                .SingleOrDefault(m => m.Id == id);

            if (tickets < 1 || tickets > 12)
            {
                @ViewData["TicketError"] = "You can only book between 1-12 tickets";
                return View(showingsquery);
            }

            var bookedSeats = showingsquery;

            bookedSeats.Tickets -= tickets;

            if (bookedSeats.Tickets >= 0)
            {
                _context.Update(bookedSeats);

                var bookings = new Booking
                {
                    Showing = bookedSeats.Showing,
                    Tickets = tickets,
                };
                _context.Bookings.Add(bookings);
                _context.SaveChanges();
                return View(bookings);
            }
            else
            {
                bookedSeats.Tickets += tickets;
                @ViewData["TicketError"] = "There is only " + bookedSeats.Tickets + " left";

                return View(showingsquery);

            }
        }

        public IActionResult Confirmation(int? id, int tickets)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showingsquery = _context.Bookings.Include(s => s.Showing).ThenInclude(m => m.Movie)
                .SingleOrDefault(m => m.Id == id);

            if (tickets < 1 || tickets > 12)
            {
                @ViewData["TicketError"] = "You can only book between 1-12 tickets";
                return View(showingsquery);
            }

            var bookedSeats = showingsquery;

            bookedSeats.Tickets -= tickets;

            if (bookedSeats.Tickets >= 0)
            {
                _context.Update(bookedSeats);

                var bookings = new Booking
                {
                    Showing = bookedSeats.Showing,
                    Tickets = tickets,
                };
                _context.SaveChanges();
                return View(bookings);
            }
            else
            {
                bookedSeats.Tickets += tickets;
                @ViewData["TicketError"] = "There is only " + bookedSeats.Tickets + " left";

                return View(showingsquery);

            }
        }


        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowingId,Tickets")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
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
            ViewData["ShowingId"] = new SelectList(_context.Showings, "Id", "Id", booking.ShowingId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Showing)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(m => m.Id == id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
