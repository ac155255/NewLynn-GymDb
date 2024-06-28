using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    //This code defines a custom validation attribute dateValidator that checks if a given date is not in the past and returns a validation error if it is.
    public class dateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                if (date < DateTime.Now)
                {
                    return new ValidationResult("The Join date cannot be in the past...");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class MembersController : Controller
    {
        private readonly NewLynn_GymDbContext _context;

        public MembersController(NewLynn_GymDbContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var members = from s in _context.Member
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    members = members.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    members = members.OrderBy(s => s.FirstName);
                    break;
               
            }
            int pageSize = 6;
            return View(await PaginatedList<Member>.CreateAsync(members.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,LastName,FirstName,Address,PhoneNumber,Email,DateOfBirth,MembershipType,JoinDate,PaymentInformation")] Member member)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,LastName,FirstName,Address,PhoneNumber,Email,DateOfBirth,MembershipType,JoinDate,PaymentInformation")] Member member)
        {
            if (id != member.MemberId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MemberId))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Member == null)
            {
                return Problem("Entity set 'NewLynn_GymDbContext.Member'  is null.");
            }
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
          return (_context.Member?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
