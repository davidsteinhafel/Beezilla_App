using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beezilla.Data;
using Beezilla.Models;

namespace Beezilla.Controllers
{
    public class KeeperModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeeperModelsController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        // GET: KeeperModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Keepers.Include(k => k.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KeeperModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keeperModel = await _context.Keepers
                .Include(k => k.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keeperModel == null)
            {
                return NotFound();
            }

            return View(keeperModel);
        }

        // GET: KeeperModels/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: KeeperModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,HiveCount,IdentityUserId")] KeeperModel keeperModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keeperModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", keeperModel.IdentityUserId);
            return View(keeperModel);
        }

        // GET: KeeperModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keeperModel = await _context.Keepers.FindAsync(id);
            if (keeperModel == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", keeperModel.IdentityUserId);
            return View(keeperModel);
        }

        // POST: KeeperModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,HiveCount,IdentityUserId")] KeeperModel keeperModel)
        {
            if (id != keeperModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keeperModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeeperModelExists(keeperModel.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", keeperModel.IdentityUserId);
            return View(keeperModel);
        }

        // GET: KeeperModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keeperModel = await _context.Keepers
                .Include(k => k.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keeperModel == null)
            {
                return NotFound();
            }

            return View(keeperModel);
        }

        // POST: KeeperModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keeperModel = await _context.Keepers.FindAsync(id);
            _context.Keepers.Remove(keeperModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeeperModelExists(int id)
        {
            return _context.Keepers.Any(e => e.Id == id);
        }
    }
}
