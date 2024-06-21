using Backend.EF.Types;
using Backend.Finances.Models;
using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.EF;

public class SaverContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SaverContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SaverContext(DbContextOptions<SaverContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<User> Users { get; set; } = default!;
    public virtual DbSet<Finance> Finances { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Saver")).EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserType());
        modelBuilder.ApplyConfiguration(new FinanceType());
    }
}
