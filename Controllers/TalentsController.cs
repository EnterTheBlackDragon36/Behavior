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
    public class TalentsController : Controller
    {
        private readonly BehaviorContext _context;

        public TalentsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Talents
        [HttpGet]
        [Route("api/Talents/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Talents.ToListAsync());
        }

        // GET: Talents/Details/5
        [HttpGet]
        [Route("api/Talents/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // GET: Talents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Talents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Talents/Create/{Talent}")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Talent talent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talent);
        }

        // GET: Talents/Edit/5
        [HttpGet]
        [Route("api/Talents/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }
            return View(talent);
        }

        // POST: Talents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Talent talent)
        {
            if (id != talent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalentExists(talent.Id))
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
            return View(talent);
        }

        // GET: Talents/Delete/5
        [HttpGet]
        [Route("api/Talents/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // POST: Talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            _context.Talents.Remove(talent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalentExists(int id)
        {
            return _context.Talents.Any(e => e.Id == id);
        }
    }
}
