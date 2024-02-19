using Microsoft.EntityFrameworkCore;
using Test.App.ViewModel;

namespace Test.App.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : DbContext(dbContext)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

public DbSet<Test.App.ViewModel.StudentVm> StudentVm { get; set; } = default!;
}
