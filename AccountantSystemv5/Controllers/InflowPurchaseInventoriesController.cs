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
    public class InflowPurchaseInventoriesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public InflowPurchaseInventoriesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: InflowPurchaseInventories
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.InflowPurchaseInventory.Include(i => i.Inventory);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: InflowPurchaseInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inflowPurchaseInventory = await _context.InflowPurchaseInventory
                .Include(i => i.Inventory)
                .SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            if (inflowPurchaseInventory == null)
            {
                return NotFound();
            }

            return View(inflowPurchaseInventory);
        }

        // GET: InflowPurchaseInventories/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Set<Inventory>(), "InventoryID", "InventoryListPrice");
            return View();
        }

        // POST: InflowPurchaseInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryReceiptID,InventoryID,QuantityReceived,InventoryReceiptPrice")] InflowPurchaseInventory inflowPurchaseInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inflowPurchaseInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Set<Inventory>(), "InventoryID", "InventoryListPrice", inflowPurchaseInventory.InventoryID);
            return View(inflowPurchaseInventory);
        }

        // GET: InflowPurchaseInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inflowPurchaseInventory = await _context.InflowPurchaseInventory.SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            if (inflowPurchaseInventory == null)
            {
                return NotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Set<Inventory>(), "InventoryID", "InventoryListPrice", inflowPurchaseInventory.InventoryID);
            return View(inflowPurchaseInventory);
        }

        // POST: InflowPurchaseInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryReceiptID,InventoryID,QuantityReceived,InventoryReceiptPrice")] InflowPurchaseInventory inflowPurchaseInventory)
        {
            if (id != inflowPurchaseInventory.InventoryReceiptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inflowPurchaseInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InflowPurchaseInventoryExists(inflowPurchaseInventory.InventoryReceiptID))
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
            ViewData["InventoryID"] = new SelectList(_context.Set<Inventory>(), "InventoryID", "InventoryListPrice", inflowPurchaseInventory.InventoryID);
            return View(inflowPurchaseInventory);
        }

        // GET: InflowPurchaseInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inflowPurchaseInventory = await _context.InflowPurchaseInventory
                .Include(i => i.Inventory)
                .SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            if (inflowPurchaseInventory == null)
            {
                return NotFound();
            }

            return View(inflowPurchaseInventory);
        }

        // POST: InflowPurchaseInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inflowPurchaseInventory = await _context.InflowPurchaseInventory.SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            _context.InflowPurchaseInventory.Remove(inflowPurchaseInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InflowPurchaseInventoryExists(int id)
        {
            return _context.InflowPurchaseInventory.Any(e => e.InventoryReceiptID == id);
        }
    }
}
