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
    public class ReservationSaleOrderInventoriesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public ReservationSaleOrderInventoriesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: ReservationSaleOrderInventories
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.ReservationSaleOrderInventory.Include(r => r.Inventory);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: ReservationSaleOrderInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationSaleOrderInventory = await _context.ReservationSaleOrderInventory
                .Include(r => r.Inventory)
                .SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (reservationSaleOrderInventory == null)
            {
                return NotFound();
            }

            return View(reservationSaleOrderInventory);
        }

        // GET: ReservationSaleOrderInventories/Create
        public IActionResult Create()
        {
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice");
            return View();
        }

        // POST: ReservationSaleOrderInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleOrderID,InventoryID,QuantityOrdered,SOPrice")] ReservationSaleOrderInventory reservationSaleOrderInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationSaleOrderInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", reservationSaleOrderInventory.InventoryID);
            return View(reservationSaleOrderInventory);
        }

        // GET: ReservationSaleOrderInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationSaleOrderInventory = await _context.ReservationSaleOrderInventory.SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (reservationSaleOrderInventory == null)
            {
                return NotFound();
            }
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", reservationSaleOrderInventory.InventoryID);
            return View(reservationSaleOrderInventory);
        }

        // POST: ReservationSaleOrderInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleOrderID,InventoryID,QuantityOrdered,SOPrice")] ReservationSaleOrderInventory reservationSaleOrderInventory)
        {
            if (id != reservationSaleOrderInventory.SaleOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationSaleOrderInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationSaleOrderInventoryExists(reservationSaleOrderInventory.SaleOrderID))
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
            ViewData["InventoryID"] = new SelectList(_context.Inventory, "InventoryID", "InventoryListPrice", reservationSaleOrderInventory.InventoryID);
            return View(reservationSaleOrderInventory);
        }

        // GET: ReservationSaleOrderInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationSaleOrderInventory = await _context.ReservationSaleOrderInventory
                .Include(r => r.Inventory)
                .SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (reservationSaleOrderInventory == null)
            {
                return NotFound();
            }

            return View(reservationSaleOrderInventory);
        }

        // POST: ReservationSaleOrderInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationSaleOrderInventory = await _context.ReservationSaleOrderInventory.SingleOrDefaultAsync(m => m.SaleOrderID == id);
            _context.ReservationSaleOrderInventory.Remove(reservationSaleOrderInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReservationSaleOrderInventoryExists(int id)
        {
            return _context.ReservationSaleOrderInventory.Any(e => e.SaleOrderID == id);
        }
    }
}
