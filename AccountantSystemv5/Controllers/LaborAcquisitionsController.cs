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
    public class LaborAcquisitionsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public LaborAcquisitionsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: LaborAcquisitions
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.LaborAcquisition.Include(l => l.Employee);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: LaborAcquisitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborAcquisition = await _context.LaborAcquisition
                .Include(l => l.Employee)
                .SingleOrDefaultAsync(m => m.TimeCardID == id);
            if (laborAcquisition == null)
            {
                return NotFound();
            }

            return View(laborAcquisition);
        }

        // GET: LaborAcquisitions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1");
            return View();
        }

        // POST: LaborAcquisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeCardID,EmployeeID,EmployeeSupervisorID,LAPayPeriodEnded,LARegularTime,LAOvertime")] LaborAcquisition laborAcquisition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laborAcquisition);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", laborAcquisition.EmployeeID);
            return View(laborAcquisition);
        }

        // GET: LaborAcquisitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborAcquisition = await _context.LaborAcquisition.SingleOrDefaultAsync(m => m.TimeCardID == id);
            if (laborAcquisition == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", laborAcquisition.EmployeeID);
            return View(laborAcquisition);
        }

        // POST: LaborAcquisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeCardID,EmployeeID,EmployeeSupervisorID,LAPayPeriodEnded,LARegularTime,LAOvertime")] LaborAcquisition laborAcquisition)
        {
            if (id != laborAcquisition.TimeCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laborAcquisition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaborAcquisitionExists(laborAcquisition.TimeCardID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmAddress1", laborAcquisition.EmployeeID);
            return View(laborAcquisition);
        }

        // GET: LaborAcquisitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborAcquisition = await _context.LaborAcquisition
                .Include(l => l.Employee)
                .SingleOrDefaultAsync(m => m.TimeCardID == id);
            if (laborAcquisition == null)
            {
                return NotFound();
            }

            return View(laborAcquisition);
        }

        // POST: LaborAcquisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laborAcquisition = await _context.LaborAcquisition.SingleOrDefaultAsync(m => m.TimeCardID == id);
            _context.LaborAcquisition.Remove(laborAcquisition);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LaborAcquisitionExists(int id)
        {
            return _context.LaborAcquisition.Any(e => e.TimeCardID == id);
        }
    }
}
