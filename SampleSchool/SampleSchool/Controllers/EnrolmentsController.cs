using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleSchool.Models;

namespace SampleSchool.Controllers
{
    public class EnrolmentsController : Controller
    {
        private readonly SchoolContext _context;

        public EnrolmentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Enrolments
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Enrolment.Include(e => e.Course).Include(e => e.S);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Enrolments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Course)
                .Include(e => e.S)
                .FirstOrDefaultAsync(m => m.EnrolId == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // GET: Enrolments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["Sid"] = new SelectList(_context.Students, "Sid", "Sid");
            return View();
        }

        // POST: Enrolments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrolId,Sid,CourseId,EnrolmentYear,EnrolmentSemester")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", enrolment.CourseId);
            ViewData["Sid"] = new SelectList(_context.Students, "Sid", "Sid", enrolment.Sid);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment.FindAsync(id);
            if (enrolment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", enrolment.CourseId);
            ViewData["Sid"] = new SelectList(_context.Students, "Sid", "Sid", enrolment.Sid);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrolId,Sid,CourseId,EnrolmentYear,EnrolmentSemester")] Enrolment enrolment)
        {
            if (id != enrolment.EnrolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolmentExists(enrolment.EnrolId))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", enrolment.CourseId);
            ViewData["Sid"] = new SelectList(_context.Students, "Sid", "Sid", enrolment.Sid);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Course)
                .Include(e => e.S)
                .FirstOrDefaultAsync(m => m.EnrolId == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolment = await _context.Enrolment.FindAsync(id);
            _context.Enrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolmentExists(int id)
        {
            return _context.Enrolment.Any(e => e.EnrolId == id);
        }
    }
}
