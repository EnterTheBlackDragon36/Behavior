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
    public class RegretsController : Controller
    {
        private readonly BehaviorContext _context;

        public RegretsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Regrets
        [HttpGet]
        [Route("api/Regrets/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regrets.ToListAsync());
        }

        // GET: Regrets/Details/5
        [HttpGet]
        [Route("api/Regrets/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regret = await _context.Regrets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regret == null)
            {
                return NotFound();
            }

            return View(regret);
        }

        // GET: Regrets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regrets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Regrets/Create/{Regret}")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Regret regret)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regret);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regret);
        }

        // GET: Regrets/Edit/5
        [HttpGet]
        [Route("api/Regrets/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regret = await _context.Regrets.FindAsync(id);
            if (regret == null)
            {
                return NotFound();
            }
            return View(regret);
        }

        // POST: Regrets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Regret regret)
        {
            if (id != regret.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegretExists(regret.Id))
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
            return View(regret);
        }

        // GET: Regrets/Delete/5
        [HttpGet]
        [Route("api/Regrets/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regret = await _context.Regrets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regret == null)
            {
                return NotFound();
            }

            return View(regret);
        }

        // POST: Regrets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regret = await _context.Regrets.FindAsync(id);
            _context.Regrets.Remove(regret);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegretExists(int id)
        {
            return _context.Regrets.Any(e => e.Id == id);
        }
    }
}
