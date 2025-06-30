using Behavior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Behavior.Controllers
{
    public class FeelingsController : Controller
    {
        private readonly BehaviorContext _context;

        public FeelingsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Feelings
        [HttpGet]
        [Route("api/Feelings/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feelings.ToListAsync());
        }

        // GET: Feelings/Details/5
        [HttpGet]
        [Route("api/Feelings/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeling = await _context.Feelings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feeling == null)
            {
                return NotFound();
            }

            return View(feeling);
        }

        // GET: Feelings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feelings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Feelings/Create/{Feeling}")]
        public async Task<IActionResult> Create([FromBody] Feeling feeling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feeling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feeling);
        }

        // GET: Feelings/Edit/5
        [HttpGet]
        [Route("api/Feelings/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeling = await _context.Feelings.FindAsync(id);
            if (feeling == null)
            {
                return NotFound();
            }
            return View(feeling);
        }

        // POST: Feelings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Feeling feeling)
        {
            if (id != feeling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeelingExists(feeling.Id))
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
            return View(feeling);
        }

        // GET: Feelings/Delete/5
        [HttpGet]
        [Route("api/Feelings/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeling = await _context.Feelings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feeling == null)
            {
                return NotFound();
            }

            return View(feeling);
        }

        // POST: Feelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeling = await _context.Feelings.FindAsync(id);
            _context.Feelings.Remove(feeling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeelingExists(int id)
        {
            return _context.Feelings.Any(e => e.Id == id);
        }
    }
}
