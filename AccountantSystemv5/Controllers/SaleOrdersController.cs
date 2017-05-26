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
    public class SaleOrdersController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public SaleOrdersController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: SaleOrders
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.SaleOrder.Include(s => s.Customer).Include(s => s.Employee);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: SaleOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // GET: SaleOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1");
            return View();
        }

        // POST: SaleOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleOrderID,EmployeeID,SaleOrderDate,CustomerID,CustomerPO,SaleOrderAmount")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // GET: SaleOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder.SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleOrderID,EmployeeID,SaleOrderDate,CustomerID,CustomerPO,SaleOrderAmount")] SaleOrder saleOrder)
        {
            if (id != saleOrder.SaleOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderExists(saleOrder.SaleOrderID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerAddress1", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // POST: SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrder = await _context.SaleOrder.SingleOrDefaultAsync(m => m.SaleOrderID == id);
            _context.SaleOrder.Remove(saleOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SaleOrderExists(int id)
        {
            return _context.SaleOrder.Any(e => e.SaleOrderID == id);
        }
    }
}
