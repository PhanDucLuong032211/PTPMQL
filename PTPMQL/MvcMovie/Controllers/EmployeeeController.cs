using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.Entities;
using Microsoft.AspNetCore.Authentication;

namespace MvcMovie.Controllers
{
    [Authorize]
    public class EmployeeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employeee
        [Authorize(Roles = "Employeee")] 
        public async Task<IActionResult> Index()
        
        {
         
            return View(await _context.Employeee.ToListAsync());
        }
        [Authorize(Roles = "Employeee")]    
        // GET: Employeee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeee = await _context.Employeee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeee == null)
            {
                return NotFound();
            }

            return View(employeee);
        }
        [Authorize(Roles = "Admin")] 

        // GET: Employeee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employeee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Address,DateOfBirth,Position,Email,HireDate")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeee);
        }
    [Authorize(Roles = "Admin")]    
        // GET: Employeee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeee = await _context.Employeee.FindAsync(id);
            if (employeee == null)
            {
                return NotFound();
            }
            return View(employeee);
        }

        // POST: Employeee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Address,DateOfBirth,Position,Email,HireDate")] Employeee employeee)
        {
            if (id != employeee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeeExists(employeee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeee);
        }

        // GET: Employeee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeee = await _context.Employeee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeee == null)
            {
                return NotFound();
            }

            return View(employeee);
        }

        // POST: Employeee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeee = await _context.Employeee.FindAsync(id);
            if (employeee != null)
            {
                _context.Employeee.Remove(employeee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeeExists(int id)
        {
            return _context.Employeee.Any(e => e.EmployeeId == id);
        }
    }
}
