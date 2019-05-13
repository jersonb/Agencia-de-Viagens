using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMvcVda.Contexts;
using WebAppMvcVda.Models;

namespace WebAppMvcVda.Controllers
{
    public class ViagemController : Controller
    {
        private readonly VdaContext _context;

        public ViagemController(VdaContext context)
        {
            _context = context;
        }

        // GET: Viagem
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viagens.ToListAsync());
        }

        // GET: Viagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Finalizada,Descricao,DtInicio,DtFim,Realisada,Desejada")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viagem);
        }

        // GET: Viagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            return View(viagem);
        }

        // POST: Viagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Finalizada,Descricao,DtInicio,DtFim,Realisada,Desejada")] Viagem viagem)
        {
            if (id != viagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.Id))
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
            return View(viagem);
        }

        // GET: Viagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);
            _context.Viagens.Remove(viagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagens.Any(e => e.Id == id);
        }
    }
}
