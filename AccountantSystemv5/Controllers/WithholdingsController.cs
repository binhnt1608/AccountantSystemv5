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
    public class WithholdingsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public WithholdingsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: Withholdings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Withholding.ToListAsync());
        }

        // GET: Withholdings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var withholding = await _context.Withholding
                .SingleOrDefaultAsync(m => m.ID == id);
            if (withholding == null)
            {
                return NotFound();
            }

            return View(withholding);
        }

        // GET: Withholdings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Withholdings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaritalStatus,FWTBracket,FWTLowerLimit,FWTUpperLimit,FWTRate,FWTBracketBaseAmt")] Withholding withholding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(withholding);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(withholding);
        }

        // GET: Withholdings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var withholding = await _context.Withholding.SingleOrDefaultAsync(m => m.ID == id);
            if (withholding == null)
            {
                return NotFound();
            }
            return View(withholding);
        }

        // POST: Withholdings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaritalStatus,FWTBracket,FWTLowerLimit,FWTUpperLimit,FWTRate,FWTBracketBaseAmt")] Withholding withholding)
        {
            if (id != withholding.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(withholding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WithholdingExists(withholding.ID))
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
            return View(withholding);
        }

        // GET: Withholdings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var withholding = await _context.Withholding
                .SingleOrDefaultAsync(m => m.ID == id);
            if (withholding == null)
            {
                return NotFound();
            }

            return View(withholding);
        }

        // POST: Withholdings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var withholding = await _context.Withholding.SingleOrDefaultAsync(m => m.ID == id);
            _context.Withholding.Remove(withholding);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WithholdingExists(int id)
        {
            return _context.Withholding.Any(e => e.ID == id);
        }
    }
}
