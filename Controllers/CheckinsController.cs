using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ButlerApp.Data;
using ButlerApp.Models;

namespace ButlerApp.Controllers
{
    public class CheckinsController : Controller
    {
        private readonly ButlerAppContext _context;

        public CheckinsController(ButlerAppContext context)
        {
            _context = context;
        }

        // GET: Checkins
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_CheckinTimes.ToListAsync());
        }

        // GET: Checkins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkin = await _context.tbl_CheckinTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkin == null)
            {
                return NotFound();
            }

            return View(checkin);
        }

        // GET: Checkins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checkins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckinTitle,EnteredBy")] Checkin checkin)
        {
            if (ModelState.IsValid)
            {
                checkin.EnteredOn = DateTime.Now;
                _context.Add(checkin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkin);
        }

        // GET: Checkins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkin = await _context.tbl_CheckinTimes.FindAsync(id);
            if (checkin == null)
            {
                return NotFound();
            }
            return View(checkin);
        }

        // POST: Checkins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckinTitle,EnteredBy,EnteredOn")] Checkin checkin)
        {
            if (id != checkin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckinExists(checkin.Id))
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
            return View(checkin);
        }

        // GET: Checkins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkin = await _context.tbl_CheckinTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkin == null)
            {
                return NotFound();
            }

            return View(checkin);
        }

        // POST: Checkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkin = await _context.tbl_CheckinTimes.FindAsync(id);
            _context.tbl_CheckinTimes.Remove(checkin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckinExists(int id)
        {
            return _context.tbl_CheckinTimes.Any(e => e.Id == id);
        }
    }
}
