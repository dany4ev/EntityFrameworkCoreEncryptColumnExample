using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utilities;

namespace EntityFrameworkCoreEncryptColumnExample.Models;

public class UserConfiguration(ICryptographyService cryptographyService) : IEntityTypeConfiguration<User>
{
    private readonly ICryptographyService _cryptographyService = cryptographyService;

    public void Configure(EntityTypeBuilder<User> builder)
    {
        //var converter = new EncryptedConverter(_cryptographyService);

        builder.ToTable($"{nameof(User)}s");
        builder.HasKey(x => x.ID)
            .HasName("PK_User_Id");

        builder.Property(p => p.ID)
        .HasColumnType("uuid")
        .HasDefaultValueSql("gen_random_uuid()")
        .IsRequired()
        .ValueGeneratedOnAdd();

        builder.Property(b => b.FirstName)
        .IsRequired();

        builder.Property(b => b.LastName)
        .IsRequired();

        builder.Property(b => b.EmailAddress)
        .IsRequired()
        .HasConversion<EncryptedConverter>();
        //.HasConversion(converter);

        builder.Property(b => b.IdentityNumber)
        .IsRequired()
        .HasConversion<EncryptedConverter>();
        //.HasConversion(converter);
    }
}