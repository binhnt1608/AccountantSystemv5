using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;

namespace AccountantSystemv5.Controllers
{
    public class LoanAgreementsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public LoanAgreementsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: LoanAgreements
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.LoanAgreement.Include(l => l.Employee);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: LoanAgreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanAgreement = await _context.LoanAgreement
                .Include(l => l.Employee)
                .SingleOrDefaultAsync(m => m.LoanID == id);
            if (loanAgreement == null)
            {
                return NotFound();
            }

            return View(loanAgreement);
        }

        // GET: LoanAgreements/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1");
            return View();
        }

        // POST: LoanAgreements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanID,FinancierID,EmployeeID,LoanAmount,InterestRate,LoanDate,MaturityDate,PaymentsPerYear")] LoanAgreement loanAgreement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanAgreement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", loanAgreement.EmployeeID);
            return View(loanAgreement);
        }

        // GET: LoanAgreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanAgreement = await _context.LoanAgreement.SingleOrDefaultAsync(m => m.LoanID == id);
            if (loanAgreement == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", loanAgreement.EmployeeID);
            return View(loanAgreement);
        }

        // POST: LoanAgreements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanID,FinancierID,EmployeeID,LoanAmount,InterestRate,LoanDate,MaturityDate,PaymentsPerYear")] LoanAgreement loanAgreement)
        {
            if (id != loanAgreement.LoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanAgreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanAgreementExists(loanAgreement.LoanID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", loanAgreement.EmployeeID);
            return View(loanAgreement);
        }

        // GET: LoanAgreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanAgreement = await _context.LoanAgreement
                .Include(l => l.Employee)
                .SingleOrDefaultAsync(m => m.LoanID == id);
            if (loanAgreement == null)
            {
                return NotFound();
            }

            return View(loanAgreement);
        }

        // POST: LoanAgreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanAgreement = await _context.LoanAgreement.SingleOrDefaultAsync(m => m.LoanID == id);
            _context.LoanAgreement.Remove(loanAgreement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LoanAgreementExists(int id)
        {
            return _context.LoanAgreement.Any(e => e.LoanID == id);
        }
    }
}
