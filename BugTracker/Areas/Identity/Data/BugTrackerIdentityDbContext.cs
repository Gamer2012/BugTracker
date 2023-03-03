using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BugTracker.Models;

namespace BugTracker.Areas.Identity.Data;

public class BugTrackerIdentityDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Bug> Bugs { get; set; }
    public BugTrackerIdentityDbContext(DbContextOptions<BugTrackerIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
