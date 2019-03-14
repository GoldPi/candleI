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
    public class TranscationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TranscationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transcations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transcations.Include(t => t.CommentThread);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transcations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transcation = await _context.Transcations
                .Include(t => t.CommentThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transcation == null)
            {
                return NotFound();
            }

            return View(transcation);
        }

        // GET: Transcations/Create
        public IActionResult Create()
        {
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id");
            return View();
        }

        // POST: Transcations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentGateWay,TranscationDate,Amount,Response,Succeeded,IsRefund,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] Transcation transcation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transcation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", transcation.CommentThreadId);
            return View(transcation);
        }

        // GET: Transcations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transcation = await _context.Transcations.FindAsync(id);
            if (transcation == null)
            {
                return NotFound();
            }
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", transcation.CommentThreadId);
            return View(transcation);
        }

        // POST: Transcations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PaymentGateWay,TranscationDate,Amount,Response,Succeeded,IsRefund,Id,CreatedOn,UpdateOn,CreatedByUserId,UpdateByUserId,IsDeleted,CommentThreadId")] Transcation transcation)
        {
            if (id != transcation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transcation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranscationExists(transcation.Id))
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
            ViewData["CommentThreadId"] = new SelectList(_context.CommentThreads, "Id", "Id", transcation.CommentThreadId);
            return View(transcation);
        }

        // GET: Transcations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transcation = await _context.Transcations
                .Include(t => t.CommentThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transcation == null)
            {
                return NotFound();
            }

            return View(transcation);
        }

        // POST: Transcations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transcation = await _context.Transcations.FindAsync(id);
            _context.Transcations.Remove(transcation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranscationExists(string id)
        {
            return _context.Transcations.Any(e => e.Id == id);
        }
    }
}
