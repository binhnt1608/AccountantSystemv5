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
    public class CashReceiptTypesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public CashReceiptTypesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: CashReceiptTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashReceiptType.ToListAsync());
        }

        // GET: CashReceiptTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceiptType = await _context.CashReceiptType
                .SingleOrDefaultAsync(m => m.CRTypeID == id);
            if (cashReceiptType == null)
            {
                return NotFound();
            }

            return View(cashReceiptType);
        }

        // GET: CashReceiptTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashReceiptTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CRTypeID,EventTypeName,PayeeTypeName")] CashReceiptType cashReceiptType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashReceiptType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cashReceiptType);
        }

        // GET: CashReceiptTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceiptType = await _context.CashReceiptType.SingleOrDefaultAsync(m => m.CRTypeID == id);
            if (cashReceiptType == null)
            {
                return NotFound();
            }
            return View(cashReceiptType);
        }

        // POST: CashReceiptTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CRTypeID,EventTypeName,PayeeTypeName")] CashReceiptType cashReceiptType)
        {
            if (id != cashReceiptType.CRTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashReceiptType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashReceiptTypeExists(cashReceiptType.CRTypeID))
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
            return View(cashReceiptType);
        }

        // GET: CashReceiptTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceiptType = await _context.CashReceiptType
                .SingleOrDefaultAsync(m => m.CRTypeID == id);
            if (cashReceiptType == null)
            {
                return NotFound();
            }

            return View(cashReceiptType);
        }

        // POST: CashReceiptTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashReceiptType = await _context.CashReceiptType.SingleOrDefaultAsync(m => m.CRTypeID == id);
            _context.CashReceiptType.Remove(cashReceiptType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CashReceiptTypeExists(int id)
        {
            return _context.CashReceiptType.Any(e => e.CRTypeID == id);
        }
    }
}
