using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    //The [Authorize] is used to restrict access to a particular controller or action method to authenticated users only.
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly NewLynn_GymDbContext _context;

        public TransactionsController(NewLynn_GymDbContext context)
        {
            _context = context;
        }

        // The Index action method asynchronously retrieves and filters transactions from _context.Transaction based on a search string, returning them as a view result.

        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Transaction == null)
            {
                return Problem("Entity set 'AmountTransactionContext.Transaction'  is null.");
            }

            var transactions = from m in _context.Transaction
                               select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                transactions = transactions.Where(s => s.Amount!.Contains(searchString));
            }

            return View(await transactions.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Employee)
                .Include(t => t.Member)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }
        
        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId","EmployeeId" );
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "MemberId");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,MemberID,EmployeeID,Amount,PaymentMethod,TransactionDate")] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "Email", transaction.EmployeeID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "Address", transaction.MemberID);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "Email", transaction.EmployeeID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "Address", transaction.MemberID);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,MemberID,EmployeeID,Amount,PaymentMethod,TransactionDate")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "Email", transaction.EmployeeID);
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberId", "Address", transaction.MemberID);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Employee)
                .Include(t => t.Member)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transaction == null)
            {
                return Problem("Entity set 'NewLynn_GymDbContext.Transaction'  is null.");
            }
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
          return (_context.Transaction?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
