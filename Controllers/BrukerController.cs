using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BrukereController : Controller
{
    private readonly BrukerContext _context;

    public BrukereController(BrukerContext context)
    {
        _context = context;
    }

    // GET: Brukere
    public async Task<IActionResult> Index()
    {
        return View(await _context.Brukere.ToListAsync());
    }

    // GET: Brukere/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var bruker = await _context.Brukere
            .FirstOrDefaultAsync(m => m.Id == id);
        if (bruker == null)
            return NotFound();

        return View(bruker);
    }

    // GET: Brukere/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Brukere/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Navn,KontaktInfo,AntallSpill")] Bruker bruker)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bruker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(bruker);
    }

    // GET: Brukere/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var bruker = await _context.Brukere.FindAsync(id);
        if (bruker == null)
            return NotFound();

        return View(bruker);
    }

    // POST: Brukere/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,KontaktInfo,AntallSpill")] Bruker bruker)
    {
        if (id != bruker.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bruker);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrukerExists(bruker.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(bruker);
    }

    // GET: Brukere/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var bruker = await _context.Brukere
            .FirstOrDefaultAsync(m => m.Id == id);
        if (bruker == null)
            return NotFound();

        return View(bruker);
    }

    // POST: Brukere/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var bruker = await _context.Brukere.FindAsync(id);
        if (bruker != null)
        {
            _context.Brukere.Remove(bruker);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool BrukerExists(int id)
    {
        return _context.Brukere.Any(e => e.Id == id);
    }
}
