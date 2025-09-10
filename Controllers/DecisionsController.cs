using Behavior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Behavior.Controllers
{
    public class DecisionsController : Controller
    {
        private readonly BehaviorContext _context;

        public DecisionsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Decisions
        [HttpGet]
        [Route("api/Decisions/Index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Decisions.ToListAsync());
        }

        // GET: Decisions/Details/5
        [HttpGet]
        [Route("api/Decisions/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decision = await _context.Decisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decision == null)
            {
                return NotFound();
            }

            return Ok(decision);
        }

        // GET: Decisions/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Decisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Decisions/Create/{Decision}")]
        public async Task<IActionResult> Create([FromBody] Decision decision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(decision);
        }

        // GET: Decisions/Edit/5
        [HttpGet]
        [Route("api/Decisions/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decision = await _context.Decisions.FindAsync(id);
            if (decision == null)
            {
                return NotFound();
            }
            return Ok(decision);
        }

        // POST: Decisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Decision decision)
        {
            if (id != decision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecisionExists(decision.Id))
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
            return Ok(decision);
        }

        // GET: Decisions/Delete/5
        [HttpGet]
        [Route("api/Decisions/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decision = await _context.Decisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decision == null)
            {
                return NotFound();
            }

            return Ok(decision);
        }

        // POST: Decisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var decision = await _context.Decisions.FindAsync(id);
            _context.Decisions.Remove(decision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DecisionExists(int id)
        {
            return _context.Decisions.Any(e => e.Id == id);
        }
    }
}
