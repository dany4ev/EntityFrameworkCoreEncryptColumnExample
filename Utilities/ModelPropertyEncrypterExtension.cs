using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Utilities;

public static class ModelPropertyEncrypterExtension
{
    public static void UseEncryption(this ModelBuilder modelBuilder)
    {
        // Instantiate the EncryptionConverter
        //var cryptographyService = new ReverseCryptographyService();
        //var converter = new EncryptedConverter(cryptographyService);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string)
                    && !IsDiscriminator(property)
                    && property.PropertyInfo is not null)
                {
                    var attributes = property.PropertyInfo?.GetCustomAttributes(typeof(EncryptedAttribute), false);
                    if (attributes != null && attributes.Length != 0)
                    {
                        //property.SetValueConverter(converter);
                    }
                }
            }
        }
    }

    // A helper function to ignore EF Core Discriminator
    private static bool IsDiscriminator(IMutableProperty property) =>
        property.Name == "Discriminator" || property.PropertyInfo == null;
}
