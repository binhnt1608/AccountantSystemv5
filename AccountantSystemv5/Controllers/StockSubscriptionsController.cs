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
    public class StockSubscriptionsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public StockSubscriptionsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: StockSubscriptions
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.StockSubscription.Include(s => s.Employee);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: StockSubscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockSubscription = await _context.StockSubscription
                .Include(s => s.Employee)
                .SingleOrDefaultAsync(m => m.StockID == id);
            if (stockSubscription == null)
            {
                return NotFound();
            }

            return View(stockSubscription);
        }

        // GET: StockSubscriptions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1");
            return View();
        }

        // POST: StockSubscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockID,FinancierID,EmployeeID,SharesIssued,PricePerShare,StockIssueDate")] StockSubscription stockSubscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockSubscription);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", stockSubscription.EmployeeID);
            return View(stockSubscription);
        }

        // GET: StockSubscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockSubscription = await _context.StockSubscription.SingleOrDefaultAsync(m => m.StockID == id);
            if (stockSubscription == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", stockSubscription.EmployeeID);
            return View(stockSubscription);
        }

        // POST: StockSubscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockID,FinancierID,EmployeeID,SharesIssued,PricePerShare,StockIssueDate")] StockSubscription stockSubscription)
        {
            if (id != stockSubscription.StockID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockSubscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockSubscriptionExists(stockSubscription.StockID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", stockSubscription.EmployeeID);
            return View(stockSubscription);
        }

        // GET: StockSubscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockSubscription = await _context.StockSubscription
                .Include(s => s.Employee)
                .SingleOrDefaultAsync(m => m.StockID == id);
            if (stockSubscription == null)
            {
                return NotFound();
            }

            return View(stockSubscription);
        }

        // POST: StockSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockSubscription = await _context.StockSubscription.SingleOrDefaultAsync(m => m.StockID == id);
            _context.StockSubscription.Remove(stockSubscription);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StockSubscriptionExists(int id)
        {
            return _context.StockSubscription.Any(e => e.StockID == id);
        }
    }
}
