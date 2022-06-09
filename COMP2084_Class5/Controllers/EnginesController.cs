using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2084_Class5.Data;
using COMP2084_Class5.Models;

namespace COMP2084_Class5.Controllers
{
    public class EnginesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnginesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Engines
        public async Task<IActionResult> Index()
        {
              return _context.Engine != null ? 
                          View(await _context.Engine.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Engine'  is null.");
        }

        // GET: Engines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Engine == null)
            {
                return NotFound();
            }

            var engine = await _context.Engine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engine == null)
            {
                return NotFound();
            }

            var cars = _context.Car.Where(m => m.EngineId == id).OrderBy(car => car.Year);

            var viewModel = new EngineViewModel()
            {
                Name = engine.Name,
                Id = engine.Id,
                Cars = cars.ToList()
            };

            return View(viewModel);
        }

        // GET: Engines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Engine engine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engine);
        }

        // GET: Engines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Engine == null)
            {
                return NotFound();
            }

            var engine = await _context.Engine.FindAsync(id);
            if (engine == null)
            {
                return NotFound();
            }
            return View(engine);
        }

        // POST: Engines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Engine engine)
        {
            if (id != engine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineExists(engine.Id))
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
            return View(engine);
        }

        // GET: Engines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Engine == null)
            {
                return NotFound();
            }

            var engine = await _context.Engine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engine == null)
            {
                return NotFound();
            }

            return View(engine);
        }

        // POST: Engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Engine == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Engine'  is null.");
            }
            var engine = await _context.Engine.FindAsync(id);
            if (engine != null)
            {
                _context.Engine.Remove(engine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineExists(int id)
        {
          return (_context.Engine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    public class EngineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
