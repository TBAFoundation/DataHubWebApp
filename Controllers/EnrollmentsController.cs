using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataHUBWebApplication.Data;
using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Controllers;

public class EnrollmentsController : Controller
{
    private readonly DataHubContext _context;

    public EnrollmentsController(DataHubContext context)
    {
        _context = context;
    }

    // GET: Enrollments
    public async Task<IActionResult> Index()
    {
        var dataHubContext = _context.Enrollments.Include(e => e.Course).Include(e => e.User);
        return View(await dataHubContext.ToListAsync());
    }

    // GET: Enrollments/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments
            .Include(e => e.Course)
            .Include(e => e.User)
            .FirstOrDefaultAsync(m => m.EnrollmentID == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // GET: Enrollments/Create
    public IActionResult Create()
    {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Category");
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID");
        return View();
    }

    // POST: Enrollments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EnrollmentID,UserID,CourseID,EnrollmentDate")] Enrollment enrollment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Category", enrollment.CourseID);
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", enrollment.UserID);
        return View(enrollment);
    }

    // GET: Enrollments/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null)
        {
            return NotFound();
        }
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Category", enrollment.CourseID);
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", enrollment.UserID);
        return View(enrollment);
    }

    // POST: Enrollments/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,UserID,CourseID,EnrollmentDate")] Enrollment enrollment)
    {
        if (id != enrollment.EnrollmentID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(enrollment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.EnrollmentID))
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
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Category", enrollment.CourseID);
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", enrollment.UserID);
        return View(enrollment);
    }

    // GET: Enrollments/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments
            .Include(e => e.Course)
            .Include(e => e.User)
            .FirstOrDefaultAsync(m => m.EnrollmentID == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // POST: Enrollments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment != null)
        {
            _context.Enrollments.Remove(enrollment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EnrollmentExists(int id)
    {
        return _context.Enrollments.Any(e => e.EnrollmentID == id);
    }
}
