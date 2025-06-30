using Behavior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Behavior.Controllers
{
    public class ChoicesController : Controller
    {
        private readonly BehaviorContext _context;

        public ChoicesController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Choices
        [HttpGet]
        [Route("api/Choices/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Choices.ToListAsync());
        }

        // GET: Choices/Details/5
        [HttpGet]
        [Route("api/Choices/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var choice = await _context.Choices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (choice == null)
            {
                return NotFound();
            }

            return View(choice);
        }

        // GET: Choices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Choices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Choices/Create/{Choice}")]
        public async Task<IActionResult> Create([FromBody] Choice choice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(choice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(choice);
        }

        // GET: Choices/Edit/5
        [HttpGet]
        [Route("api/Choices/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var choice = await _context.Choices.FindAsync(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Choices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Choice choice)
        {
            if (id != choice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(choice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoiceExists(choice.Id))
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
            return View(choice);
        }

        // GET: Choices/Delete/5
        [HttpGet]
        [Route("api/Choices/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var choice = await _context.Choices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (choice == null)
            {
                return NotFound();
            }

            return View(choice);
        }

        // POST: Choices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var choice = await _context.Choices.FindAsync(id);
            _context.Choices.Remove(choice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoiceExists(int id)
        {
            return _context.Choices.Any(e => e.Id == id);
        }
    }
}
