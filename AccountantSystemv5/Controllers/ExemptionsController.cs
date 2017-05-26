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
    public class ExemptionsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public ExemptionsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: Exemptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exemptions.ToListAsync());
        }

        // GET: Exemptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exemptions = await _context.Exemptions
                .SingleOrDefaultAsync(m => m.ExemptionNum == id);
            if (exemptions == null)
            {
                return NotFound();
            }

            return View(exemptions);
        }

        // GET: Exemptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exemptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExemptionNum,ExemptionAmount")] Exemptions exemptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exemptions);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exemptions);
        }

        // GET: Exemptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exemptions = await _context.Exemptions.SingleOrDefaultAsync(m => m.ExemptionNum == id);
            if (exemptions == null)
            {
                return NotFound();
            }
            return View(exemptions);
        }

        // POST: Exemptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExemptionNum,ExemptionAmount")] Exemptions exemptions)
        {
            if (id != exemptions.ExemptionNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exemptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExemptionsExists(exemptions.ExemptionNum))
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
            return View(exemptions);
        }

        // GET: Exemptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exemptions = await _context.Exemptions
                .SingleOrDefaultAsync(m => m.ExemptionNum == id);
            if (exemptions == null)
            {
                return NotFound();
            }

            return View(exemptions);
        }

        // POST: Exemptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exemptions = await _context.Exemptions.SingleOrDefaultAsync(m => m.ExemptionNum == id);
            _context.Exemptions.Remove(exemptions);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ExemptionsExists(int id)
        {
            return _context.Exemptions.Any(e => e.ExemptionNum == id);
        }
    }
}
