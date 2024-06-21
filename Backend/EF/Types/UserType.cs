using Backend.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.EF.Types;

public class UserType : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name).HasColumnType("varchar(150)");
        builder.Property(user => user.Email).HasColumnType("varchar(150)");
        builder.Property(user => user.IdentificationNumber).HasColumnType("varchar(11)");
        builder.Property(user => user.Password).HasColumnType("varchar");
        builder.Property(user => user.IsActive).HasColumnType("boolean");
        builder.HasMany(user => user.Finances).WithOne().HasForeignKey(finance => finance.Id);
        builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
    }
}
