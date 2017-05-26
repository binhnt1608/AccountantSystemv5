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
    public class ReservationPurchaseOrderInventoriesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public ReservationPurchaseOrderInventoriesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: ReservationPurchaseOrderInventories
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.ReservationPurchaseOrderInventory.Include(r => r.Inventory);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: ReservationPurchaseOrderInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationPurchaseOrderInventory = await _context.ReservationPurchaseOrderInventory
                .Include(r => r.Inventory)
                .SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (reservationPurchaseOrderInventory == null)
            {
                return NotFound();
            }

            return View(reservationPurchaseOrderInventory);
        }

        // GET: ReservationPurchaseOrderInventories/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice");
            return View();
        }

        // POST: ReservationPurchaseOrderInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseOrderID,InventoryID,QuantityOrdered,POPrice,VendorItemID")] ReservationPurchaseOrderInventory reservationPurchaseOrderInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationPurchaseOrderInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", reservationPurchaseOrderInventory.InventoryID);
            return View(reservationPurchaseOrderInventory);
        }

        // GET: ReservationPurchaseOrderInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationPurchaseOrderInventory = await _context.ReservationPurchaseOrderInventory.SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (reservationPurchaseOrderInventory == null)
            {
                return NotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", reservationPurchaseOrderInventory.InventoryID);
            return View(reservationPurchaseOrderInventory);
        }

        // POST: ReservationPurchaseOrderInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderID,InventoryID,QuantityOrdered,POPrice,VendorItemID")] ReservationPurchaseOrderInventory reservationPurchaseOrderInventory)
        {
            if (id != reservationPurchaseOrderInventory.PurchaseOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationPurchaseOrderInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationPurchaseOrderInventoryExists(reservationPurchaseOrderInventory.PurchaseOrderID))
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
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", reservationPurchaseOrderInventory.InventoryID);
            return View(reservationPurchaseOrderInventory);
        }

        // GET: ReservationPurchaseOrderInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationPurchaseOrderInventory = await _context.ReservationPurchaseOrderInventory
                .Include(r => r.Inventory)
                .SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (reservationPurchaseOrderInventory == null)
            {
                return NotFound();
            }

            return View(reservationPurchaseOrderInventory);
        }

        // POST: ReservationPurchaseOrderInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationPurchaseOrderInventory = await _context.ReservationPurchaseOrderInventory.SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            _context.ReservationPurchaseOrderInventory.Remove(reservationPurchaseOrderInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReservationPurchaseOrderInventoryExists(int id)
        {
            return _context.ReservationPurchaseOrderInventory.Any(e => e.PurchaseOrderID == id);
        }
    }
}
