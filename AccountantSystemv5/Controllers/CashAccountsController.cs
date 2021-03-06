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
    public class CashAccountsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public CashAccountsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: CashAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashAccount.ToListAsync());
        }

        // GET: CashAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashAccount = await _context.CashAccount
                .SingleOrDefaultAsync(m => m.CashAccountID == id);
            if (cashAccount == null)
            {
                return NotFound();
            }

            return View(cashAccount);
        }

        // GET: CashAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CashAccountID,AccountDescription,BankName,BankAccountNumber")] CashAccount cashAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cashAccount);
        }

        // GET: CashAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashAccount = await _context.CashAccount.SingleOrDefaultAsync(m => m.CashAccountID == id);
            if (cashAccount == null)
            {
                return NotFound();
            }
            return View(cashAccount);
        }

        // POST: CashAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CashAccountID,AccountDescription,BankName,BankAccountNumber")] CashAccount cashAccount)
        {
            if (id != cashAccount.CashAccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashAccountExists(cashAccount.CashAccountID))
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
            return View(cashAccount);
        }

        // GET: CashAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashAccount = await _context.CashAccount
                .SingleOrDefaultAsync(m => m.CashAccountID == id);
            if (cashAccount == null)
            {
                return NotFound();
            }

            return View(cashAccount);
        }

        // POST: CashAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashAccount = await _context.CashAccount.SingleOrDefaultAsync(m => m.CashAccountID == id);
            _context.CashAccount.Remove(cashAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CashAccountExists(int id)
        {
            return _context.CashAccount.Any(e => e.CashAccountID == id);
        }
    }
}
