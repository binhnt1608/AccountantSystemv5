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
    public class CashDisbursementTypesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public CashDisbursementTypesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: CashDisbursementTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashDisbursementType.ToListAsync());
        }

        // GET: CashDisbursementTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursementType = await _context.CashDisbursementType
                .SingleOrDefaultAsync(m => m.CDTypeID == id);
            if (cashDisbursementType == null)
            {
                return NotFound();
            }

            return View(cashDisbursementType);
        }

        // GET: CashDisbursementTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashDisbursementTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDTypeID,EventTypeName,PayeeTypeName")] CashDisbursementType cashDisbursementType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDisbursementType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cashDisbursementType);
        }

        // GET: CashDisbursementTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursementType = await _context.CashDisbursementType.SingleOrDefaultAsync(m => m.CDTypeID == id);
            if (cashDisbursementType == null)
            {
                return NotFound();
            }
            return View(cashDisbursementType);
        }

        // POST: CashDisbursementTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDTypeID,EventTypeName,PayeeTypeName")] CashDisbursementType cashDisbursementType)
        {
            if (id != cashDisbursementType.CDTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDisbursementType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDisbursementTypeExists(cashDisbursementType.CDTypeID))
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
            return View(cashDisbursementType);
        }

        // GET: CashDisbursementTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursementType = await _context.CashDisbursementType
                .SingleOrDefaultAsync(m => m.CDTypeID == id);
            if (cashDisbursementType == null)
            {
                return NotFound();
            }

            return View(cashDisbursementType);
        }

        // POST: CashDisbursementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDisbursementType = await _context.CashDisbursementType.SingleOrDefaultAsync(m => m.CDTypeID == id);
            _context.CashDisbursementType.Remove(cashDisbursementType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CashDisbursementTypeExists(int id)
        {
            return _context.CashDisbursementType.Any(e => e.CDTypeID == id);
        }
    }
}
