namespace Utilities;

public class DatabaseFactory : IDatabaseFactory
{
    public string GetConnectionStringByDatabase(DatabaseType type)
    {
        var ConnectionString = string.Empty;

        switch (type)
        {
            case DatabaseType.Postgres:
                ConnectionString =
                    "Server=localhost;Database=encryptexample;Port=5432;User Id=postgres;Password=PgAdmin;";
                    //"Server=localhost;Port=5432;User Id=postgres;Database=postgres;Pooling=true;Search Path=encryptexample";
                break;

            case DatabaseType.MSSqlServer:
                ConnectionString = "Server=.;Database=EncryptExample;Trusted_Connection=True;";
                break;

            case DatabaseType.Mysql:
                ConnectionString = "";
                break;

            case DatabaseType.MSAccess:
                ConnectionString = "";
                break;

            case DatabaseType.Sqlite:
                ConnectionString = "";
                break;

            case DatabaseType.MongoDb:
                ConnectionString = "";
                break;

        }

        return ConnectionString;
    }

}
