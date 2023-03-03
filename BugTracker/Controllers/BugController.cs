using BugTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using BugTracker.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers;

public class BugController : Controller
{
    private readonly BugTrackerIdentityDbContext _context;

    public BugController(BugTrackerIdentityDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Bug> bugsfromdb = _context.Bugs.ToList();
        return View(bugsfromdb);
    }

    public IActionResult BugCreator(int id)
    {
        if (id != 0)
        {
            var bugFromDb = _context.Bugs.SingleOrDefault(x => x.Id == id);
            if (bugFromDb != null) return View(bugFromDb);
        }
        return View();
    }

    public IActionResult CreateBug(Bug bug)
    {
        if (bug.Id == 0)
        {
            bug.OpenedBy = User.Identity.Name;
            _context.Bugs.Add(bug);
        }
        else
        {
            _context.Bugs.Update(bug);
            
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult BugSquasher(Bug bug)
    {
        _context.Bugs.Remove(bug);

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult CloseBug(Bug bug)
    {
        Bug? bugFromDb = _context.Bugs.SingleOrDefault(x => x.Id == bug.Id);
        if (bugFromDb == null)
        {
            return NotFound();
        }
        
        bugFromDb.ClosedBy = bug.ClosedBy;
        bugFromDb.Progress = 1;
        bugFromDb.Solution = bug.Solution;

        _context.SaveChanges();
        
        
        return RedirectToAction("Index");
    }

    public IActionResult BugCloser(int id)
    {
        if (id != 0)
        {
            var bugFromDb = _context.Bugs.SingleOrDefault(x => x.Id == id);
            if (bugFromDb != null) return View(bugFromDb);
        }
        return View();
    }

    public IActionResult SolutionViewer(int id)
    {
        Bug? bugFromDb = _context.Bugs.SingleOrDefault(x => x.Id == id);

        if (bugFromDb == null)
        {
            return NotFound();
        }
        
        return View(bugFromDb);
    }

    public IActionResult HandleSolution(Bug bug)
    {
        Bug? bugFromDb = _context.Bugs.SingleOrDefault(x => x.Id == bug.Id);

        if (bugFromDb == null)
        {
            return NotFound();
        }

        bugFromDb.CloseDate = DateTime.Now;
        
        bugFromDb.Progress = bug.Progress;

        _context.Bugs.Update(bugFromDb);

        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }
}