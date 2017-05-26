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
    public class FulfillmentLACDsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public FulfillmentLACDsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: FulfillmentLACDs
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.FulfillmentLACD.Include(f => f.LoanAgreement);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: FulfillmentLACDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fulfillmentLACD = await _context.FulfillmentLACD
                .Include(f => f.LoanAgreement)
                .SingleOrDefaultAsync(m => m.LoanPaymentID == id);
            if (fulfillmentLACD == null)
            {
                return NotFound();
            }

            return View(fulfillmentLACD);
        }

        // GET: FulfillmentLACDs/Create
        public IActionResult Create()
        {
            ViewData["LoanID"] = new SelectList(_context.Set<LoanAgreement>(), "LoanID", "InterestRate");
            return View();
        }

        // POST: FulfillmentLACDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanPaymentID,LoanID,PaymentDueDate,PaymentNum,PrincipalAmount,InterestAmount")] FulfillmentLACD fulfillmentLACD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fulfillmentLACD);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LoanID"] = new SelectList(_context.Set<LoanAgreement>(), "LoanID", "InterestRate", fulfillmentLACD.LoanID);
            return View(fulfillmentLACD);
        }

        // GET: FulfillmentLACDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fulfillmentLACD = await _context.FulfillmentLACD.SingleOrDefaultAsync(m => m.LoanPaymentID == id);
            if (fulfillmentLACD == null)
            {
                return NotFound();
            }
            ViewData["LoanID"] = new SelectList(_context.Set<LoanAgreement>(), "LoanID", "InterestRate", fulfillmentLACD.LoanID);
            return View(fulfillmentLACD);
        }

        // POST: FulfillmentLACDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanPaymentID,LoanID,PaymentDueDate,PaymentNum,PrincipalAmount,InterestAmount")] FulfillmentLACD fulfillmentLACD)
        {
            if (id != fulfillmentLACD.LoanPaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fulfillmentLACD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FulfillmentLACDExists(fulfillmentLACD.LoanPaymentID))
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
            ViewData["LoanID"] = new SelectList(_context.Set<LoanAgreement>(), "LoanID", "InterestRate", fulfillmentLACD.LoanID);
            return View(fulfillmentLACD);
        }

        // GET: FulfillmentLACDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fulfillmentLACD = await _context.FulfillmentLACD
                .Include(f => f.LoanAgreement)
                .SingleOrDefaultAsync(m => m.LoanPaymentID == id);
            if (fulfillmentLACD == null)
            {
                return NotFound();
            }

            return View(fulfillmentLACD);
        }

        // POST: FulfillmentLACDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fulfillmentLACD = await _context.FulfillmentLACD.SingleOrDefaultAsync(m => m.LoanPaymentID == id);
            _context.FulfillmentLACD.Remove(fulfillmentLACD);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FulfillmentLACDExists(int id)
        {
            return _context.FulfillmentLACD.Any(e => e.LoanPaymentID == id);
        }
    }
}
