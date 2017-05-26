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
    public class SalesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public SalesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.Sale.Include(s => s.Customer).Include(s => s.Employee).Include(s => s.SaleOrder);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.SaleOrder)
                .SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1");
            ViewData["SaleOrderID"] = new SelectList(_context.SaleOrder, "SaleOrderID", "SaleOrderID");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceID,ShippingDate,CustomerID,SaleOrderID,EmployeeID,SaleAmount")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1", sale.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", sale.EmployeeID);
            ViewData["SaleOrderID"] = new SelectList(_context.SaleOrder, "SaleOrderID", "SaleOrderID", sale.SaleOrderID);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1", sale.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", sale.EmployeeID);
            ViewData["SaleOrderID"] = new SelectList(_context.SaleOrder, "SaleOrderID", "SaleOrderID", sale.SaleOrderID);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceID,ShippingDate,CustomerID,SaleOrderID,EmployeeID,SaleAmount")] Sale sale)
        {
            if (id != sale.InvoiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.InvoiceID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1", sale.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", sale.EmployeeID);
            ViewData["SaleOrderID"] = new SelectList(_context.SaleOrder, "SaleOrderID", "SaleOrderID", sale.SaleOrderID);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.SaleOrder)
                .SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.InvoiceID == id);
            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.InvoiceID == id);
        }
    }
}
