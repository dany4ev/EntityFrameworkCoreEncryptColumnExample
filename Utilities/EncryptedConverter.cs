using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Utilities;

public class EncryptedConverter(ICryptographyService cryptographyService, ConverterMappingHints? mappingHints = null) 
    : ValueConverter<string, string>(
        v => cryptographyService.Encrypt(v), 
        v => cryptographyService.Decrypt(v), 
        mappingHints)
{
}
