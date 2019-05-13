using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMvcVda.Contexts;
using WebAppMvcVda.Models;

namespace WebAppMvcVda.Controllers
{
    public class AndeiroController : Controller
    {
        private readonly VdaContext _context;

        public AndeiroController(VdaContext context)
        {
            _context = context;
        }

        // GET: Andeiro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Andeiros.ToListAsync());
        }

        // GET: Andeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var andeiro = await _context.Andeiros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (andeiro == null)
            {
                return NotFound();
            }

            return View(andeiro);
        }

        // GET: Andeiro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Andeiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DtNascimento,Id,Nome")] Andeiro andeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(andeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(andeiro);
        }

        // GET: Andeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var andeiro = await _context.Andeiros.FindAsync(id);
            if (andeiro == null)
            {
                return NotFound();
            }
            return View(andeiro);
        }

        // POST: Andeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DtNascimento,Id,Nome")] Andeiro andeiro)
        {
            if (id != andeiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(andeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AndeiroExists(andeiro.Id))
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
            return View(andeiro);
        }

        // GET: Andeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var andeiro = await _context.Andeiros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (andeiro == null)
            {
                return NotFound();
            }

            return View(andeiro);
        }

        // POST: Andeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var andeiro = await _context.Andeiros.FindAsync(id);
            _context.Andeiros.Remove(andeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AndeiroExists(int id)
        {
            return _context.Andeiros.Any(e => e.Id == id);
        }
    }
}
