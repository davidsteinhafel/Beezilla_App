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
    public class QueenModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueenModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QueenModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Queens.ToListAsync());
        }

        // GET: QueenModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queenModel = await _context.Queens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queenModel == null)
            {
                return NotFound();
            }

            return View(queenModel);
        }

        // GET: QueenModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QueenModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Seen,Marked,QueenStart,QueenEnd")] QueenModel queenModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queenModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(queenModel);
        }

        // GET: QueenModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queenModel = await _context.Queens.FindAsync(id);
            if (queenModel == null)
            {
                return NotFound();
            }
            return View(queenModel);
        }

        // POST: QueenModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Seen,Marked,QueenStart,QueenEnd")] QueenModel queenModel)
        {
            if (id != queenModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queenModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueenModelExists(queenModel.Id))
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
            return View(queenModel);
        }

        // GET: QueenModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var queenModel = await _context.Queens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (queenModel == null)
            {
                return NotFound();
            }

            return View(queenModel);
        }

        // POST: QueenModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var queenModel = await _context.Queens.FindAsync(id);
            _context.Queens.Remove(queenModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QueenModelExists(int id)
        {
            return _context.Queens.Any(e => e.Id == id);
        }
    }
}
