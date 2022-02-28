#nullable disable
using BulkyBookWeb.Web.Data;
using BulkyBookWeb.Web.Entities;
using BulkyBookWeb.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly BulkyBookWebContext _context;
    private readonly ILogger<CategoriesController> _logger;

    public CategoriesController(BulkyBookWebContext context, ILogger<CategoriesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: Categories
    public async Task<IActionResult> Index(bool? includeDeleted)
    {
        var categories = _context.Category.AsQueryable();

        if (includeDeleted is null || !includeDeleted.Value) categories = categories.Where(category => !category.IsDeleted);

        return View(await categories.ToListAsync());
    }

    // GET: Categories/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var category = await _context.Category
            .FirstOrDefaultAsync(m => m.Id == id);

        if (category == null) return NotFound();

        return View(category);
    }

    // GET: Categories/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] CategoryEntity category)
    {
        if (!ModelState.IsValid) return View(category);

        _context.Add(category);
        await _context.SaveChangesAsync();
        TempData["Success"] = Constants.CATEGORY_CREATED_MSG;

        return RedirectToAction(nameof(Index));
    }

    // GET: Categories/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
        var category = await _context.Category.FindAsync(id);

        if (category == null) return NotFound();

        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayOrder")] CategoryEntity category)
    {
        if (id != category.Id) return NotFound();

        if (!ModelState.IsValid) return View(category);

        try
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            TempData["Success"] = Constants.CATEGORY_UPDATED_MSG;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(category.Id))
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

    // GET: Categories/Delete/5
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _context.Category
            .FirstOrDefaultAsync(m => m.Id == id);

        if (category == null) return NotFound();

        return View(category);
    }

    // POST: Categories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var category = await _context.Category.FindAsync(id);
        category.IsDeleted = true;
        await _context.SaveChangesAsync();
        TempData["Success"] = Constants.CATEGORY_DELETED_MSG;

        return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(Guid id)
    {
        return _context.Category.Any(e => e.Id == id);
    }
}
