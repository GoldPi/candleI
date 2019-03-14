using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityModel;
using QuickProject.Data;

namespace QuickProject.Controllers
{
    public class AcadamicYearController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcadamicYearController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcadamicYear
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AcadamicYears.Include(a => a.CommentThread);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AcadamicYear/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acadamicYear = await _context.AcadamicYears
                .Include(a => a.CommentThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acadamicYear == null)
            {
                return NotFound();
            }

            return View(acadamicYear);
        }

        // GET: AcadamicYear/Create
        public IActionResult Create()
        {
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id");
            return View();
        }

        // POST: AcadamicYear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,StartDate,EndDate,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] AcadamicYear acadamicYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acadamicYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", acadamicYear.CommentThreadId);
            return View(acadamicYear);
        }

        // GET: AcadamicYear/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acadamicYear = await _context.AcadamicYears.FindAsync(id);
            if (acadamicYear == null)
            {
                return NotFound();
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", acadamicYear.CommentThreadId);
            return View(acadamicYear);
        }

        // POST: AcadamicYear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,StartDate,EndDate,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] AcadamicYear acadamicYear)
        {
            if (id != acadamicYear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acadamicYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcadamicYearExists(acadamicYear.Id))
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
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", acadamicYear.CommentThreadId);
            return View(acadamicYear);
        }

        // GET: AcadamicYear/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acadamicYear = await _context.AcadamicYears
                .Include(a => a.CommentThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acadamicYear == null)
            {
                return NotFound();
            }

            return View(acadamicYear);
        }

        // POST: AcadamicYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var acadamicYear = await _context.AcadamicYears.FindAsync(id);
            _context.AcadamicYears.Remove(acadamicYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcadamicYearExists(string id)
        {
            return _context.AcadamicYears.Any(e => e.Id == id);
        }
    }
}
