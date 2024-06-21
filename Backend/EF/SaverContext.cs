using Backend.EF.Types;
using Backend.Finances.Models;
using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.EF;

public class SaverContext : DbContext
{
    public SaverContext()
    {
    }

    public SaverContext(DbContextOptions<SaverContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = default!;
    public virtual DbSet<Finance> Finances { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserType());
        modelBuilder.ApplyConfiguration(new FinanceType());
    }
}
