namespace Utilities;

public interface IDatabaseFactory
{
    string GetConnectionStringByDatabase(DatabaseType type);
}
