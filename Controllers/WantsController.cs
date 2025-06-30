using Behavior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Behavior.Controllers
{
    public class WantsController : Controller
    {
        private readonly BehaviorContext _context;

        public WantsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Wants
        [HttpGet]
        [Route("api/Wants/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wants.ToListAsync());
        }

        // GET: Wants/Details/5
        [HttpGet]
        [Route("api/Wants/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var want = await _context.Wants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (want == null)
            {
                return NotFound();
            }

            return View(want);
        }

        // GET: Wants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Wants/Create/{Want}")]
        public async Task<IActionResult> Create([FromBody] Want want)
        {
            if (ModelState.IsValid)
            {
                _context.Add(want);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(want);
        }

        // GET: Wants/Edit/5
        [HttpGet]
        [Route("api/Wants/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var want = await _context.Wants.FindAsync(id);
            if (want == null)
            {
                return NotFound();
            }
            return View(want);
        }

        // POST: Wants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Want want)
        {
            if (id != want.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(want);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WantExists(want.Id))
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
            return View(want);
        }

        // GET: Wants/Delete/5
        [HttpGet]
        [Route("api/Wants/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var want = await _context.Wants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (want == null)
            {
                return NotFound();
            }

            return View(want);
        }

        // POST: Wants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var want = await _context.Wants.FindAsync(id);
            _context.Wants.Remove(want);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WantExists(int id)
        {
            return _context.Wants.Any(e => e.Id == id);
        }
    }
}
