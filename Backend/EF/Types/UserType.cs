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
        builder.HasMany(user => user.Finances).WithOne(finance => finance.User).HasForeignKey(finance => finance.UserId);
        builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");

        builder.HasData(new User() { Id = Guid.Parse("d5af0c60-f6e5-4b3d-af69-2d992b7ae096"), Name = "Alexandre Pato", Email = "alexandrepato@email.com", IdentificationNumber = "39212783090", Password = "patopato123", IsActive = true });
        builder.HasData(new User() { Id = Guid.Parse("70359af3-ca94-410d-87fb-f909cde413ac"), Name = "Neymar Jr", Email = "neymarjr@email.com", IdentificationNumber = "34546715072", Password = "adultoNey123", IsActive = true });
        builder.HasData(new User() { Id = Guid.Parse("548dfcc0-a38e-456f-9430-17ad3950ab39"), Name = "Craque Neto", Email = "craqueneto@email.com", IdentificationNumber = "47420061009", Password = "netaoBomBeef", IsActive = true });
        builder.HasData(new User() { Id = Guid.Parse("105b06df-73cc-4a6e-9a14-f6ee4912e8b1"), Name = "Denílson", Email = "denilson@email.com", IdentificationNumber = "09755120050", Password = "denilson123", IsActive = true });
        builder.HasData(new User() { Id = Guid.Parse("7c149996-5bba-4c04-8450-f0ab2f888299"), Name = "Renata Fan", Email = "renatafan@email.com", IdentificationNumber = "04951619008", Password = "renatafanJogoAberto", IsActive = true });
    }
}
