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
    public class InventoryDiametersController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public InventoryDiametersController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: InventoryDiameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryDiameter.ToListAsync());
        }

        // GET: InventoryDiameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryDiameter = await _context.InventoryDiameter
                .SingleOrDefaultAsync(m => m.CompositionID == id);
            if (inventoryDiameter == null)
            {
                return NotFound();
            }

            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryDiameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompositionID,InventoryDiameterCode,InventoryDiameterDescription")] InventoryDiameter inventoryDiameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryDiameter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryDiameter = await _context.InventoryDiameter.SingleOrDefaultAsync(m => m.CompositionID == id);
            if (inventoryDiameter == null)
            {
                return NotFound();
            }
            return View(inventoryDiameter);
        }

        // POST: InventoryDiameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompositionID,InventoryDiameterCode,InventoryDiameterDescription")] InventoryDiameter inventoryDiameter)
        {
            if (id != inventoryDiameter.CompositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryDiameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryDiameterExists(inventoryDiameter.CompositionID))
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
            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryDiameter = await _context.InventoryDiameter
                .SingleOrDefaultAsync(m => m.CompositionID == id);
            if (inventoryDiameter == null)
            {
                return NotFound();
            }

            return View(inventoryDiameter);
        }

        // POST: InventoryDiameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryDiameter = await _context.InventoryDiameter.SingleOrDefaultAsync(m => m.CompositionID == id);
            _context.InventoryDiameter.Remove(inventoryDiameter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryDiameterExists(int id)
        {
            return _context.InventoryDiameter.Any(e => e.CompositionID == id);
        }
    }
}
