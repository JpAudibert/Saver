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
    }
}
