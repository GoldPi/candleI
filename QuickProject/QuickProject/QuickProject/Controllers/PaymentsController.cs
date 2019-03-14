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
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Payments.Include(p => p.CommentThread).Include(p => p.Student).Include(p => p.Transcation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.CommentThread)
                .Include(p => p.Student)
                .Include(p => p.Transcation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["TranscationId"] = new SelectList(_context.Transcations, "Id", "Id");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TranscationId,StudentId,PaidAmount,PaymentType,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", payments.CommentThreadId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", payments.StudentId);
            ViewData["TranscationId"] = new SelectList(_context.Transcations, "Id", "Id", payments.TranscationId);
            return View(payments);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", payments.CommentThreadId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", payments.StudentId);
            ViewData["TranscationId"] = new SelectList(_context.Transcations, "Id", "Id", payments.TranscationId);
            return View(payments);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TranscationId,StudentId,PaidAmount,PaymentType,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] Payments payments)
        {
            if (id != payments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsExists(payments.Id))
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
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", payments.CommentThreadId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", payments.StudentId);
            ViewData["TranscationId"] = new SelectList(_context.Transcations, "Id", "Id", payments.TranscationId);
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.CommentThread)
                .Include(p => p.Student)
                .Include(p => p.Transcation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var payments = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(string id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
