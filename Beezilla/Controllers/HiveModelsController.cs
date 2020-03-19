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

        // GET: HiveModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hives.ToListAsync());
        }

        // GET: HiveModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiveModel = await _context.Hives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiveModel == null)
            {
                return NotFound();
            }

            return View(hiveModel);
        }

        // GET: HiveModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HiveModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperament,Brood,Size,Supers,Species,Mites,HiveType,Propolis,HiveImageUrl,QueenCells,HiveStrength,SwarmPotential, HiveLat, HiveLon")] HiveModel hiveModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hiveModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hiveModel);
        }

        // GET: HiveModels/Edit/5
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
            return View(hiveModel);
        }

        // POST: HiveModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperament,Brood,Size,Supers,Species,Mites,HiveType,Propolis,HiveImageUrl,QueenCells,HiveStrength,SwarmPotential")] HiveModel hiveModel)
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
            return View(hiveModel);
        }

        // GET: HiveModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiveModel = await _context.Hives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiveModel == null)
            {
                return NotFound();
            }

            return View(hiveModel);
        }

        // POST: HiveModels/Delete/5
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
