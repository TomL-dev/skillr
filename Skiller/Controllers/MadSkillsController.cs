using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skiller.Models;

namespace Skiller.Controllers
{
    public class MadSkillsController : Controller
    {
        private readonly SkillerContext _context;

        public MadSkillsController(SkillerContext context)
        {
            _context = context;
        }

        // GET: MadSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.MadSkill.ToListAsync());
        }

        // GET: MadSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madSkill = await _context.MadSkill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (madSkill == null)
            {
                return NotFound();
            }

            return View(madSkill);
        }

        // GET: MadSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MadSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Awesomeness")] MadSkill madSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(madSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(madSkill);
        }

        // GET: MadSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madSkill = await _context.MadSkill.FindAsync(id);
            if (madSkill == null)
            {
                return NotFound();
            }
            return View(madSkill);
        }

        // POST: MadSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Awesomeness")] MadSkill madSkill)
        {
            if (id != madSkill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(madSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MadSkillExists(madSkill.ID))
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
            return View(madSkill);
        }

        // GET: MadSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madSkill = await _context.MadSkill
                .FirstOrDefaultAsync(m => m.ID == id);
            if (madSkill == null)
            {
                return NotFound();
            }

            return View(madSkill);
        }

        // POST: MadSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var madSkill = await _context.MadSkill.FindAsync(id);
            _context.MadSkill.Remove(madSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MadSkillExists(int id)
        {
            return _context.MadSkill.Any(e => e.ID == id);
        }
    }
}
