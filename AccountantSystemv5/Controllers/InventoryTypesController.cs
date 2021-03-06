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
    public class InventoryTypesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public InventoryTypesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: InventoryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryType.ToListAsync());
        }

        // GET: InventoryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryType = await _context.InventoryType
                .SingleOrDefaultAsync(m => m.CompositionID == id);
            if (inventoryType == null)
            {
                return NotFound();
            }

            return View(inventoryType);
        }

        // GET: InventoryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompositionID,InventoryTypeCode,InventoryTypeDescription")] InventoryType inventoryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inventoryType);
        }

        // GET: InventoryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryType = await _context.InventoryType.SingleOrDefaultAsync(m => m.CompositionID == id);
            if (inventoryType == null)
            {
                return NotFound();
            }
            return View(inventoryType);
        }

        // POST: InventoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompositionID,InventoryTypeCode,InventoryTypeDescription")] InventoryType inventoryType)
        {
            if (id != inventoryType.CompositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryTypeExists(inventoryType.CompositionID))
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
            return View(inventoryType);
        }

        // GET: InventoryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryType = await _context.InventoryType
                .SingleOrDefaultAsync(m => m.CompositionID == id);
            if (inventoryType == null)
            {
                return NotFound();
            }

            return View(inventoryType);
        }

        // POST: InventoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryType = await _context.InventoryType.SingleOrDefaultAsync(m => m.CompositionID == id);
            _context.InventoryType.Remove(inventoryType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryTypeExists(int id)
        {
            return _context.InventoryType.Any(e => e.CompositionID == id);
        }
    }
}
