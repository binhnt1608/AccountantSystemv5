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
    public class FulfillmentSSCDsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public FulfillmentSSCDsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: FulfillmentSSCDs
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.FulfillmentSSCD.Include(f => f.StockSubscription);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: FulfillmentSSCDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fulfillmentSSCD = await _context.FulfillmentSSCD
                .Include(f => f.StockSubscription)
                .SingleOrDefaultAsync(m => m.DividendID == id);
            if (fulfillmentSSCD == null)
            {
                return NotFound();
            }

            return View(fulfillmentSSCD);
        }

        // GET: FulfillmentSSCDs/Create
        public IActionResult Create()
        {
            ViewData["StockID"] = new SelectList(_context.Set<StockSubscription>(), "StockID", "StockID");
            return View();
        }

        // POST: FulfillmentSSCDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DividendID,StockID,DividendDeclarationDate,DividendPerShare")] FulfillmentSSCD fulfillmentSSCD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fulfillmentSSCD);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["StockID"] = new SelectList(_context.Set<StockSubscription>(), "StockID", "StockID", fulfillmentSSCD.StockID);
            return View(fulfillmentSSCD);
        }

        // GET: FulfillmentSSCDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fulfillmentSSCD = await _context.FulfillmentSSCD.SingleOrDefaultAsync(m => m.DividendID == id);
            if (fulfillmentSSCD == null)
            {
                return NotFound();
            }
            ViewData["StockID"] = new SelectList(_context.Set<StockSubscription>(), "StockID", "StockID", fulfillmentSSCD.StockID);
            return View(fulfillmentSSCD);
        }

        // POST: FulfillmentSSCDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DividendID,StockID,DividendDeclarationDate,DividendPerShare")] FulfillmentSSCD fulfillmentSSCD)
        {
            if (id != fulfillmentSSCD.DividendID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fulfillmentSSCD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FulfillmentSSCDExists(fulfillmentSSCD.DividendID))
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
            ViewData["StockID"] = new SelectList(_context.Set<StockSubscription>(), "StockID", "StockID", fulfillmentSSCD.StockID);
            return View(fulfillmentSSCD);
        }

        // GET: FulfillmentSSCDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fulfillmentSSCD = await _context.FulfillmentSSCD
                .Include(f => f.StockSubscription)
                .SingleOrDefaultAsync(m => m.DividendID == id);
            if (fulfillmentSSCD == null)
            {
                return NotFound();
            }

            return View(fulfillmentSSCD);
        }

        // POST: FulfillmentSSCDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fulfillmentSSCD = await _context.FulfillmentSSCD.SingleOrDefaultAsync(m => m.DividendID == id);
            _context.FulfillmentSSCD.Remove(fulfillmentSSCD);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FulfillmentSSCDExists(int id)
        {
            return _context.FulfillmentSSCD.Any(e => e.DividendID == id);
        }
    }
}
