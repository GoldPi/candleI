using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityModel;
using QuickProject.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuickProject.Controllers
{
    public class AppliedCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string UserId;
        public AppliedCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Query.Any(i => i.Key == "userid"))
                context.Result = Redirect("Students");
            else
                UserId = context.HttpContext.Request.Query.FirstOrDefault(i => i.Key == "userid").Value;
            ViewData["userid"] = UserId;
            base.OnActionExecuting(context);
        }


        public async Task<IActionResult> SelectCourse()
        {
            var applicationDbContext = _context.Courses.Include(c => c.CommentThread);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppliedCourses
        public async Task<IActionResult> Index()
        {
            
            var applicationDbContext = _context.AppliedCourses.Where(i=>i.StudentId==UserId).Include(a => a.CommentThread).Include(a => a.AcadamicYear);
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
        public IActionResult Create(string CourseId)
        {
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Name");
            var course = _context.Courses.FirstOrDefault(i => i.Id == CourseId);
            return View( new AppliedCourse { StudentId=UserId, DurationInDays =course.DurationInDays, Fees=course.Fees, Fee =course.Fees, CourseName=course.CourseName , Details=course.Details});
        }

        // POST: AppliedCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,AcadamicYearId,Fee,ScholarShipDeduction,CourseName,Fees,DurationInDays,Details,Id")] AppliedCourse appliedCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appliedCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { UserId });
            }
            
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
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Name", appliedCourse.AcadamicYearId);
            return View(appliedCourse);
        }

        // POST: AppliedCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,AcadamicYearId,Fee,ScholarShipDeduction,CourseName,Fees,DurationInDays,Details,Id")] AppliedCourse appliedCourse)
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
                return RedirectToAction(nameof(Index), new { UserId });
            }
            ViewData["AcadamicYearId"] = new SelectList(_context.AcadamicYears, "Id", "Name", appliedCourse.AcadamicYearId);
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
            return RedirectToAction(nameof(Index), new { UserId });
        }

        private bool AppliedCourseExists(string id)
        {
            return _context.AppliedCourses.Any(e => e.Id == id);
        }
    }
}
