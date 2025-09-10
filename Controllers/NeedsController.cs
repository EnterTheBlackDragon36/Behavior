using Behavior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Behavior.Controllers
{
    public class NeedsController : Controller
    {
        private readonly BehaviorContext _context;

        public NeedsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Needs
        [HttpGet]
        [Route("api/Needs/Index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Needs.ToListAsync());
        }

        // GET: Needs/Details/5
        [HttpGet]
        [Route("api/Needs/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var need = await _context.Needs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (need == null)
            {
                return NotFound();
            }

            return Ok(need);
        }

        // GET: Needs/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Needs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Needs/Create/{Need}")]
        public async Task<IActionResult> Create([FromBody] Need need)
        {
            if (ModelState.IsValid)
            {
                _context.Add(need);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(need);
        }

        // GET: Needs/Edit/5
        [HttpGet]
        [Route("api/Needs/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var need = await _context.Needs.FindAsync(id);
            if (need == null)
            {
                return NotFound();
            }
            return Ok(need);
        }

        // POST: Needs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Need need)
        {
            if (id != need.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(need);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeedExists(need.Id))
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
            return Ok(need);
        }

        // GET: Needs/Delete/5
        [HttpGet]
        [Route("api/Needs/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var need = await _context.Needs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (need == null)
            {
                return NotFound();
            }

            return Ok(need);
        }

        // POST: Needs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var need = await _context.Needs.FindAsync(id);
            _context.Needs.Remove(need);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeedExists(int id)
        {
            return _context.Needs.Any(e => e.Id == id);
        }
    }
}
