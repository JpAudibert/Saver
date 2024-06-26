using Backend.Finances.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.EF.Types;

public class FinanceType : IEntityTypeConfiguration<Finance>
{
    public void Configure(EntityTypeBuilder<Finance> builder)
    {
        builder.ToTable("finances");
        builder.HasKey(finance => finance.Id);

        builder.Property(finance => finance.Amount).HasColumnType("double precision");
        builder.Property(finance => finance.Description).HasColumnType("varchar(150)");
        builder.Property(finance => finance.Type).HasColumnType("varchar(11)");
        builder.HasOne(finance => finance.User).WithMany(user => user.Finances).HasForeignKey(finance => finance.UserId);
        builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");

        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 10000, Description = "Salary", Type = "income", UserId = Guid.Parse("d5af0c60-f6e5-4b3d-af69-2d992b7ae096") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 250, Description = "Groceries", Type = "expense", UserId = Guid.Parse("d5af0c60-f6e5-4b3d-af69-2d992b7ae096") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 1000, Description = "Clothing", Type = "expense", UserId = Guid.Parse("d5af0c60-f6e5-4b3d-af69-2d992b7ae096") });
        
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 10000000, Description = "Salary", Type = "income", UserId = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 250215, Description = "Party", Type = "expense", UserId = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 999999, Description = "Clothing", Type = "expense", UserId = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac") });
        
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 15000, Description = "Salary", Type = "income", UserId = Guid.Parse("548dfcc0-a38e-456f-9430-17ad3950ab39") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 1000, Description = "Fine", Type = "expense", UserId = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 1534, Description = "Groceries", Type = "expense", UserId = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 2565, Description = "Clothing", Type = "expense", UserId = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac") });
        
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 20000, Description = "Salary", Type = "income", UserId = Guid.Parse("105b06df-73cc-4a6e-9a14-f6ee4912e8b1") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 1000, Description = "Tax Refund", Type = "income", UserId = Guid.Parse("105b06df-73cc-4a6e-9a14-f6ee4912e8b1") });
        
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 30000, Description = "Salary", Type = "income", UserId = Guid.Parse("7c149996-5bba-4c04-8450-f0ab2f888299") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 5548, Description = "Clothing", Type = "expense", UserId = Guid.Parse("7c149996-5bba-4c04-8450-f0ab2f888299") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 2544, Description = "Salon", Type = "expense", UserId = Guid.Parse("7c149996-5bba-4c04-8450-f0ab2f888299") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 2400, Description = "Hairdresser", Type = "expense", UserId = Guid.Parse("7c149996-5bba-4c04-8450-f0ab2f888299") });
        builder.HasData(new Finance() { Id = Guid.NewGuid(), Amount = 250, Description = "Clothing", Type = "expense", UserId = Guid.Parse("7c149996-5bba-4c04-8450-f0ab2f888299") });
    }
}
