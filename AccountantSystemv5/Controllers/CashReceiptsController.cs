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
    public class CashReceiptsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public CashReceiptsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: CashReceipts
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.CashReceipt.Include(c => c.CashAccount).Include(c => c.CashReceiptType).Include(c => c.Customer).Include(c => c.Employee).Include(c => c.Sale);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: CashReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceipt = await _context.CashReceipt
                .Include(c => c.CashAccount)
                .Include(c => c.CashReceiptType)
                .Include(c => c.Customer)
                .Include(c => c.Employee)
                .Include(c => c.Sale)
                .SingleOrDefaultAsync(m => m.RemittanceAdviceID == id);
            if (cashReceipt == null)
            {
                return NotFound();
            }

            return View(cashReceipt);
        }

        // GET: CashReceipts/Create
        public IActionResult Create()
        {
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber");
            ViewData["CRTypeID"] = new SelectList(_context.CashReceiptType, "CRTypeID", "EventTypeName");
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress1");
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmAddress1");
            ViewData["InvoiceID"] = new SelectList(_context.Set<Sale>(), "InvoiceID", "InvoiceID");
            return View();
        }

        // POST: CashReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RemittanceAdviceID,CashAccountID,CRTypeID,CustomerID,EmployeeID,InvoiceID,CasheReceiptAmount,PayorCheckNum,CashReceiptDate")] CashReceipt cashReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber", cashReceipt.CashAccountID);
            ViewData["CRTypeID"] = new SelectList(_context.CashReceiptType, "CRTypeID", "EventTypeName", cashReceipt.CRTypeID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress1", cashReceipt.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmAddress1", cashReceipt.EmployeeID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Sale>(), "InvoiceID", "InvoiceID", cashReceipt.InvoiceID);
            return View(cashReceipt);
        }

        // GET: CashReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceipt = await _context.CashReceipt.SingleOrDefaultAsync(m => m.RemittanceAdviceID == id);
            if (cashReceipt == null)
            {
                return NotFound();
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber", cashReceipt.CashAccountID);
            ViewData["CRTypeID"] = new SelectList(_context.CashReceiptType, "CRTypeID", "EventTypeName", cashReceipt.CRTypeID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress1", cashReceipt.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmAddress1", cashReceipt.EmployeeID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Sale>(), "InvoiceID", "InvoiceID", cashReceipt.InvoiceID);
            return View(cashReceipt);
        }

        // POST: CashReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RemittanceAdviceID,CashAccountID,CRTypeID,CustomerID,EmployeeID,InvoiceID,CasheReceiptAmount,PayorCheckNum,CashReceiptDate")] CashReceipt cashReceipt)
        {
            if (id != cashReceipt.RemittanceAdviceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashReceiptExists(cashReceipt.RemittanceAdviceID))
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
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber", cashReceipt.CashAccountID);
            ViewData["CRTypeID"] = new SelectList(_context.CashReceiptType, "CRTypeID", "EventTypeName", cashReceipt.CRTypeID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress1", cashReceipt.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmAddress1", cashReceipt.EmployeeID);
            ViewData["InvoiceID"] = new SelectList(_context.Set<Sale>(), "InvoiceID", "InvoiceID", cashReceipt.InvoiceID);
            return View(cashReceipt);
        }

        // GET: CashReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceipt = await _context.CashReceipt
                .Include(c => c.CashAccount)
                .Include(c => c.CashReceiptType)
                .Include(c => c.Customer)
                .Include(c => c.Employee)
                .Include(c => c.Sale)
                .SingleOrDefaultAsync(m => m.RemittanceAdviceID == id);
            if (cashReceipt == null)
            {
                return NotFound();
            }

            return View(cashReceipt);
        }

        // POST: CashReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashReceipt = await _context.CashReceipt.SingleOrDefaultAsync(m => m.RemittanceAdviceID == id);
            _context.CashReceipt.Remove(cashReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CashReceiptExists(int id)
        {
            return _context.CashReceipt.Any(e => e.RemittanceAdviceID == id);
        }
    }
}
