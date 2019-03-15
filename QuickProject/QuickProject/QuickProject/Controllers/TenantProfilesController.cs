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
    public class TenantProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TenantProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TenantProfiles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TenantProfiles.Include(t => t.CommentThread);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TenantProfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantProfile = await _context.TenantProfiles
                .Include(t => t.CommentThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenantProfile == null)
            {
                return NotFound();
            }

            return View(tenantProfile);
        }

        // GET: TenantProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TenantProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Host,Module")] TenantProfile tenantProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenantProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenantProfile);
        }

        // GET: TenantProfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantProfile = await _context.TenantProfiles.FindAsync(id);
            if (tenantProfile == null)
            {
                return NotFound();
            }
            return View(tenantProfile);
        }

        // POST: TenantProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Host,Module,Id")] TenantProfile tenantProfile)
        {
            if (id != tenantProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenantProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantProfileExists(tenantProfile.Id))
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
            return View(tenantProfile);
        }

        // GET: TenantProfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantProfile = await _context.TenantProfiles
                .Include(t => t.CommentThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenantProfile == null)
            {
                return NotFound();
            }

            return View(tenantProfile);
        }

        // POST: TenantProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tenantProfile = await _context.TenantProfiles.FindAsync(id);
            _context.TenantProfiles.Remove(tenantProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantProfileExists(string id)
        {
            return _context.TenantProfiles.Any(e => e.Id == id);
        }
    }
}
