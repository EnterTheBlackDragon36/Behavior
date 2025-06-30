using Behavior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Action = Behavior.Models.Action;

namespace Behavior.Controllers
{
    public class ActionsController : Controller
    {
        private readonly BehaviorContext _context;

        public ActionsController(BehaviorContext context)
        {
            _context = context;
        }

        // GET: Actions
        [HttpGet]
        [Route("api/Actions/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actions.ToListAsync());
        }

        // GET: Actions/Details/5
        [HttpGet]
        [Route("api/Actions/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _context.Actions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // GET: Actions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Actions/Create/{Action}")]
        public async Task<IActionResult> Create([FromBody] Action action)
        {
            if (ModelState.IsValid)
            {
                _context.Add(action);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(action);
        }

        // GET: Actions/Edit/5
        [HttpGet]
        [Route("api/Actions/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _context.Actions.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }
            return View(action);
        }

        // POST: Actions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] Action action)
        {
            if (id != action.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(action);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionExists(action.Id))
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
            return View(action);
        }

        // GET: Actions/Delete/5
        [HttpGet]
        [Route("api/Actions/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _context.Actions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // POST: Actions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var action = await _context.Actions.FindAsync(id);
            _context.Actions.Remove(action);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionExists(int id)
        {
            return _context.Actions.Any(e => e.Id == id);
        }
    }
}
