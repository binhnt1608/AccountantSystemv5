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
    public class StockHolderCreditorsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public StockHolderCreditorsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: StockHolderCreditors
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockHolderCreditor.ToListAsync());
        }

        // GET: StockHolderCreditors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockHolderCreditor = await _context.StockHolderCreditor
                .SingleOrDefaultAsync(m => m.VendorID == id);
            if (stockHolderCreditor == null)
            {
                return NotFound();
            }

            return View(stockHolderCreditor);
        }

        // GET: StockHolderCreditors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockHolderCreditors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendorID,FinancierName,FinancierAddress1,FinancierAddress2,FinancierCity,FinancierState,FinancierZipCode,FinancierTelephone,FinancierPrimaryContact")] StockHolderCreditor stockHolderCreditor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockHolderCreditor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stockHolderCreditor);
        }

        // GET: StockHolderCreditors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockHolderCreditor = await _context.StockHolderCreditor.SingleOrDefaultAsync(m => m.VendorID == id);
            if (stockHolderCreditor == null)
            {
                return NotFound();
            }
            return View(stockHolderCreditor);
        }

        // POST: StockHolderCreditors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendorID,FinancierName,FinancierAddress1,FinancierAddress2,FinancierCity,FinancierState,FinancierZipCode,FinancierTelephone,FinancierPrimaryContact")] StockHolderCreditor stockHolderCreditor)
        {
            if (id != stockHolderCreditor.VendorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockHolderCreditor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockHolderCreditorExists(stockHolderCreditor.VendorID))
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
            return View(stockHolderCreditor);
        }

        // GET: StockHolderCreditors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockHolderCreditor = await _context.StockHolderCreditor
                .SingleOrDefaultAsync(m => m.VendorID == id);
            if (stockHolderCreditor == null)
            {
                return NotFound();
            }

            return View(stockHolderCreditor);
        }

        // POST: StockHolderCreditors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockHolderCreditor = await _context.StockHolderCreditor.SingleOrDefaultAsync(m => m.VendorID == id);
            _context.StockHolderCreditor.Remove(stockHolderCreditor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StockHolderCreditorExists(int id)
        {
            return _context.StockHolderCreditor.Any(e => e.VendorID == id);
        }
    }
}
