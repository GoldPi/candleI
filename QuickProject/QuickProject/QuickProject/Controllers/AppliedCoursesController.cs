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
    public class AppliedCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppliedCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppliedCourses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AppliedCourses.Include(a => a.CommentThread).Include(a => a.AcadamicYear);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppliedCourses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliedCourse = await _context.AppliedCourses
                .Include(a => a.CommentThread)
                .Include(a => a.AcadamicYear)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appliedCourse == null)
            {
                return NotFound();
            }

            return View(appliedCourse);
        }

        // GET: AppliedCourses/Create
        public IActionResult Create()
        {
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id");
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Id");
            return View();
        }

        // POST: AppliedCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,AcadamicYearId,Fee,ScholarShipDeduction,CourseName,Fees,DurationInDays,Details,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] AppliedCourse appliedCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appliedCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", appliedCourse.CommentThreadId);
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Id", appliedCourse.AcadamicYearId);
            return View(appliedCourse);
        }

        // GET: AppliedCourses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliedCourse = await _context.AppliedCourses.FindAsync(id);
            if (appliedCourse == null)
            {
                return NotFound();
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", appliedCourse.CommentThreadId);
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Id", appliedCourse.AcadamicYearId);
            return View(appliedCourse);
        }

        // POST: AppliedCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,AcadamicYearId,Fee,ScholarShipDeduction,CourseName,Fees,DurationInDays,Details,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] AppliedCourse appliedCourse)
        {
            if (id != appliedCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appliedCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppliedCourseExists(appliedCourse.Id))
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
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", appliedCourse.CommentThreadId);
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Id", appliedCourse.AcadamicYearId);
            return View(appliedCourse);
        }

        // GET: AppliedCourses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliedCourse = await _context.AppliedCourses
                .Include(a => a.CommentThread)
                .Include(a => a.AcadamicYear)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appliedCourse == null)
            {
                return NotFound();
            }

            return View(appliedCourse);
        }

        // POST: AppliedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appliedCourse = await _context.AppliedCourses.FindAsync(id);
            _context.AppliedCourses.Remove(appliedCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppliedCourseExists(string id)
        {
            return _context.AppliedCourses.Any(e => e.Id == id);
        }
    }
}
