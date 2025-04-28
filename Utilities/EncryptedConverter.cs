using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Utilities;

public class EncryptedConverter(ICryptographyService cryptographyService, ConverterMappingHints? mappingHints = null) 
    : ValueConverter<string, string>(
        content => cryptographyService.Encrypt(content), 
        content => cryptographyService.Decrypt(content), 
        mappingHints)
{
}
