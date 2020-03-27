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
    public class HiveModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HiveModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hives.Include(h => h.KeeperModel);
            return View(await applicationDbContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiveModel = await _context.Hives
                .Include(h => h.KeeperModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiveModel == null)
            {
                return NotFound();
            }
            hiveModel.GoogleKey = Keys.GoogleApi;
            return View(hiveModel);
        }

        
        public IActionResult Create()
        {
            ViewData["KeeperModelId"] = new SelectList(_context.Keepers, "Id", "Id");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberOfFrames,Temperament,Brood,BroodPattern,Size,Species,Mites,HiveType,Propolis,HiveImageUrl,QueenCells,HiveStrength,SwarmPotential,HiveLat,HiveLon,PercentOfHiveBrood,PercentOfHiveEmpty,PercentOfHiveHoney,PercentOfHiveUnBrood,KeeperModelId")] HiveModel hiveModel)
        {
            if (ModelState.IsValid)
            {
                hiveModel.HiveStrength = Strength.StrengthCalc(hiveModel);
                hiveModel.SwarmPotential = SwarmRisk.SwarmCalc(hiveModel);
                _context.Add(hiveModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KeeperModelId"] = new SelectList(_context.Keepers, "Id", "Id", hiveModel.KeeperModelId);
            return View(hiveModel);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiveModel = await _context.Hives.FindAsync(id);
            if (hiveModel == null)
            {
                return NotFound();
            }
            ViewData["KeeperModelId"] = new SelectList(_context.Keepers, "Id", "Id", hiveModel.KeeperModelId);
            return View(hiveModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumberOfFrames,Temperament,Brood,Size,Species,Mites,HiveType,Propolis,HiveImageUrl,QueenCells,HiveStrength,SwarmPotential,HiveLat,HiveLon,PercentOfHiveBrood,PercentOfHiveEmpty,PercentOfHiveHoney,PercentOfHiveUnBrood,KeeperModelId")] HiveModel hiveModel)
        {
            if (id != hiveModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hiveModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HiveModelExists(hiveModel.Id))
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
            ViewData["KeeperModelId"] = new SelectList(_context.Keepers, "Id", "Id", hiveModel.KeeperModelId);
            return View(hiveModel);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiveModel = await _context.Hives
                .Include(h => h.KeeperModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiveModel == null)
            {
                return NotFound();
            }

            return View(hiveModel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hiveModel = await _context.Hives.FindAsync(id);
            _context.Hives.Remove(hiveModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HiveModelExists(int id)
        {
            return _context.Hives.Any(e => e.Id == id);
        }
    }
}
