using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beezilla.Data;
using Beezilla.Models;
using System.Security.Claims;

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
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var keeperModel = _context.Keepers.Include(k => k.IdentityUser).Where(k => k.IdentityUserId == userId).FirstOrDefault();
            if(keeperModel == null)
            {
                return RedirectToAction("Create");
            }
            return View(keeperModel);
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
            //ViewData["IdentityUserId"] = new KeeperModel();
            return View();
        }

        // POST: KeeperModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,HiveCount")] KeeperModel keeperModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                keeperModel.IdentityUserId = userId;
                _context.Add(keeperModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new KeeperModel();
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
