using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewLynn_GymDb.Areas.Identity.Data;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private readonly NewLynn_GymDbContext _context;

        public AttendancesController(NewLynn_GymDbContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var newLynn_GymDbContext = _context.Attendance.Include(a => a.Employee).Include(a => a.Member);
            return View(await newLynn_GymDbContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Employee)
                .Include(a => a.Member)
                .FirstOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "MemberId");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceID,MemberID,EmployeeID,AttendanceDate,Status")] Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "FirstName", attendance.EmployeeID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "FirstName", attendance.MemberID);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "Email", attendance.EmployeeID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "Address", attendance.MemberID);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceID,MemberID,EmployeeID,AttendanceDate,Status")] Attendance attendance)
        {
            if (id != attendance.AttendanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "Email", attendance.EmployeeID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "Address", attendance.MemberID);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Employee)
                .Include(a => a.Member)
                .FirstOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendance == null)
            {
                return Problem("Entity set 'NewLynn_GymDbContext.Attendance'  is null.");
            }
            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendance.Remove(attendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
          return (_context.Attendance?.Any(e => e.AttendanceID == id)).GetValueOrDefault();
        }
    }
}
