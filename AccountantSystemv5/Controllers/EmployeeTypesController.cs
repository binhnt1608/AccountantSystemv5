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
    public class EmployeeTypesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public EmployeeTypesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: EmployeeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeType.ToListAsync());
        }

        // GET: EmployeeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeType = await _context.EmployeeType
                .SingleOrDefaultAsync(m => m.EmployeeTypeID == id);
            if (employeeType == null)
            {
                return NotFound();
            }

            return View(employeeType);
        }

        // GET: EmployeeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeTypeID")] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeType = await _context.EmployeeType.SingleOrDefaultAsync(m => m.EmployeeTypeID == id);
            if (employeeType == null)
            {
                return NotFound();
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeTypeID")] EmployeeType employeeType)
        {
            if (id != employeeType.EmployeeTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTypeExists(employeeType.EmployeeTypeID))
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
            return View(employeeType);
        }

        // GET: EmployeeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeType = await _context.EmployeeType
                .SingleOrDefaultAsync(m => m.EmployeeTypeID == id);
            if (employeeType == null)
            {
                return NotFound();
            }

            return View(employeeType);
        }

        // POST: EmployeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeType = await _context.EmployeeType.SingleOrDefaultAsync(m => m.EmployeeTypeID == id);
            _context.EmployeeType.Remove(employeeType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeTypeExists(int id)
        {
            return _context.EmployeeType.Any(e => e.EmployeeTypeID == id);
        }
    }
}
