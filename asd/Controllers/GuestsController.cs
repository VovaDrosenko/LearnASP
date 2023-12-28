using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asd.Models;
using asd.Models.Entities;

namespace asd.Controllers
{
    public class GuestsController : Controller
    {
        private readonly AppDBContext _context;

        public GuestsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Guest.Include(g => g.Company);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                .Include(g => g.Company)
                .FirstOrDefaultAsync(m => m.GuestID == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID");
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestID,CompanyID,Name")] Guest guest)
        {
            
                _context.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", guest.CompanyID);
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestID,CompanyID,Name")] Guest guest, string returnUrl)
        {
            if (id != guest.GuestID)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", guest.CompanyID);
            return RedirectToAction("GuestsFromExpertSolution", "Home");
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                .Include(g => g.Company)
                .FirstOrDefaultAsync(m => m.GuestID == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guest == null)
            {
                return Problem("Entity set 'AppDBContext.Guest'  is null.");
            }
            var guest = await _context.Guest.FindAsync(id);
            if (guest != null)
            {
                _context.Guest.Remove(guest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("GuestsFromExpertSolution", "Home");
        }

        private bool GuestExists(int id)
        {
          return (_context.Guest?.Any(e => e.GuestID == id)).GetValueOrDefault();
        }
    }
}
