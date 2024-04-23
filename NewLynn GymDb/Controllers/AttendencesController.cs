using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewLynn_GymDb.Areas.Identity.Data;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Controllers
{
    public class AttendencesController : Controller
    {
        private readonly NewLynn_GymDbContext _context;

        public AttendencesController(NewLynn_GymDbContext context)
        {
            _context = context;
        }

        // GET: Attendences
        public async Task<IActionResult> Index()
        {
            return _context.Attendence != null ?
                          View(await _context.Attendence.ToListAsync()) :
                          Problem("Entity set 'NewLynn_GymDbContext.Attendence'  is null.");
        }

        // GET: Attendences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendence == null)
            {
                return NotFound();
            }

            var attendence = await _context.Attendence
                .FirstOrDefaultAsync(m => m.AttendenceID == id);
            if (attendence == null)
            {
                return NotFound();
            }

            return View(attendence);
        }

        // GET: Attendences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendenceID,MemberID,EmployeeID,AttendenceDate,Status")] Attendence attendence)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(attendence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendence);
        }

        // GET: Attendences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendence == null)
            {
                return NotFound();
            }

            var attendence = await _context.Attendence.FindAsync(id);
            if (attendence == null)
            {
                return NotFound();
            }
            return View(attendence);
        }

        // POST: Attendences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendenceID,MemberID,EmployeeID,AttendenceDate,Status")] Attendence attendence)
        {
            if (id != attendence.AttendenceID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendenceExists(attendence.AttendenceID))
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
            return View(attendence);
        }

        // GET: Attendences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendence == null)
            {
                return NotFound();
            }

            var attendence = await _context.Attendence
                .FirstOrDefaultAsync(m => m.AttendenceID == id);
            if (attendence == null)
            {
                return NotFound();
            }

            return View(attendence);
        }

        // POST: Attendences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendence == null)
            {
                return Problem("Entity set 'NewLynn_GymDbContext.Attendence'  is null.");
            }
            var attendence = await _context.Attendence.FindAsync(id);
            if (attendence != null)
            {
                _context.Attendence.Remove(attendence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendenceExists(int id)
        {
          return (_context.Attendence?.Any(e => e.AttendenceID == id)).GetValueOrDefault();
        }
    }
}
