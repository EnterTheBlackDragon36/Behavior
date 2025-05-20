using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Behavior.Models;

namespace Behavior.Controllers
{
    public class SensesController : Controller
    {
        private readonly BehaviorContext _context;

        public SensesController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Senses
        [HttpGet]
        [Route("api/Senses/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Senses.ToListAsync());
        }

        // GET: Senses/Details/5
        [HttpGet]
        [Route("api/Senses/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sense = await _context.Senses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sense == null)
            {
                return NotFound();
            }

            return View(sense);
        }

        // GET: Senses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Senses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Senses/Create/{Sense}")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Sense sense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sense);
        }

        // GET: Senses/Edit/5
        [HttpGet]
        [Route("api/Senses/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sense = await _context.Senses.FindAsync(id);
            if (sense == null)
            {
                return NotFound();
            }
            return View(sense);
        }

        // POST: Senses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Sense sense)
        {
            if (id != sense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SenseExists(sense.Id))
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
            return View(sense);
        }

        // GET: Senses/Delete/5
        [HttpGet]
        [Route("api/Senses/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sense = await _context.Senses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sense == null)
            {
                return NotFound();
            }

            return View(sense);
        }

        // POST: Senses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sense = await _context.Senses.FindAsync(id);
            _context.Senses.Remove(sense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SenseExists(int id)
        {
            return _context.Senses.Any(e => e.Id == id);
        }
    }
}
