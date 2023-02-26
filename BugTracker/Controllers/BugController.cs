using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BugTracker.Controllers;

public class BugController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}