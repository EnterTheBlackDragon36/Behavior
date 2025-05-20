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
    public class LearnController : Controller
    {
        private readonly BehaviorContext _context;

        public LearnController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Learn
        [HttpGet]
        [Route("api/Learn/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Learns.ToListAsync());
        }

        // GET: Learn/Details/5
        [HttpGet]
        [Route("api/Learn/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learn = await _context.Learns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learn == null)
            {
                return NotFound();
            }

            return View(learn);
        }

        // GET: Learn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Learn/Create/{Learn}")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Learn learn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learn);
        }

        // GET: Learn/Edit/5
        [HttpGet]
        [Route("api/Learn/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learn = await _context.Learns.FindAsync(id);
            if (learn == null)
            {
                return NotFound();
            }
            return View(learn);
        }

        // POST: Learn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Learn learn)
        {
            if (id != learn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnExists(learn.Id))
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
            return View(learn);
        }

        // GET: Learn/Delete/5
        [HttpGet]
        [Route("api/Learn/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learn = await _context.Learns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learn == null)
            {
                return NotFound();
            }

            return View(learn);
        }

        // POST: Learn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learn = await _context.Learns.FindAsync(id);
            _context.Learns.Remove(learn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnExists(int id)
        {
            return _context.Learns.Any(e => e.Id == id);
        }
    }
}
