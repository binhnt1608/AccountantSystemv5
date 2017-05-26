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
    public class OutflowSaleInventoriesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public OutflowSaleInventoriesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: OutflowSaleInventories
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.OutflowSaleInventory.Include(o => o.Inventory);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: OutflowSaleInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outflowSaleInventory = await _context.OutflowSaleInventory
                .Include(o => o.Inventory)
                .SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (outflowSaleInventory == null)
            {
                return NotFound();
            }

            return View(outflowSaleInventory);
        }

        // GET: OutflowSaleInventories/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice");
            return View();
        }

        // POST: OutflowSaleInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceID,InventoryID,QuantityOrdered,SOPrice")] OutflowSaleInventory outflowSaleInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outflowSaleInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", outflowSaleInventory.InventoryID);
            return View(outflowSaleInventory);
        }

        // GET: OutflowSaleInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outflowSaleInventory = await _context.OutflowSaleInventory.SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (outflowSaleInventory == null)
            {
                return NotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", outflowSaleInventory.InventoryID);
            return View(outflowSaleInventory);
        }

        // POST: OutflowSaleInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceID,InventoryID,QuantityOrdered,SOPrice")] OutflowSaleInventory outflowSaleInventory)
        {
            if (id != outflowSaleInventory.InvoiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outflowSaleInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutflowSaleInventoryExists(outflowSaleInventory.InvoiceID))
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
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", outflowSaleInventory.InventoryID);
            return View(outflowSaleInventory);
        }

        // GET: OutflowSaleInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outflowSaleInventory = await _context.OutflowSaleInventory
                .Include(o => o.Inventory)
                .SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (outflowSaleInventory == null)
            {
                return NotFound();
            }

            return View(outflowSaleInventory);
        }

        // POST: OutflowSaleInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var outflowSaleInventory = await _context.OutflowSaleInventory.SingleOrDefaultAsync(m => m.InvoiceID == id);
            _context.OutflowSaleInventory.Remove(outflowSaleInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OutflowSaleInventoryExists(int id)
        {
            return _context.OutflowSaleInventory.Any(e => e.InvoiceID == id);
        }
    }
}
