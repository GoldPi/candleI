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
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Students.Include(s => s.CommentThread).Include(s => s.Father).Include(s => s.Mother);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CommentThread)
                .Include(s => s.Father)
                .Include(s => s.Mother)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id");
            ViewData["FatherId"] = new SelectList(_context.People, "Id", "Id");
            ViewData["MotherId"] = new SelectList(_context.People, "Id", "Id");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentNumber,MotherId,FatherId,FirstName,MiddleName,LastName,Title,Email,PhoneNumber,MobileNumber,Address_1,Address_2,City,State,Country,PostalCode,FaxNumber,Comments_Summary,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", student.CommentThreadId);
            ViewData["FatherId"] = new SelectList(_context.People, "Id", "Id", student.FatherId);
            ViewData["MotherId"] = new SelectList(_context.People, "Id", "Id", student.MotherId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", student.CommentThreadId);
            ViewData["FatherId"] = new SelectList(_context.People, "Id", "Id", student.FatherId);
            ViewData["MotherId"] = new SelectList(_context.People, "Id", "Id", student.MotherId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EnrollmentNumber,MotherId,FatherId,FirstName,MiddleName,LastName,Title,Email,PhoneNumber,MobileNumber,Address_1,Address_2,City,State,Country,PostalCode,FaxNumber,Comments_Summary,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", student.CommentThreadId);
            ViewData["FatherId"] = new SelectList(_context.People, "Id", "Id", student.FatherId);
            ViewData["MotherId"] = new SelectList(_context.People, "Id", "Id", student.MotherId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CommentThread)
                .Include(s => s.Father)
                .Include(s => s.Mother)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
