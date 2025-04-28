using Microsoft.EntityFrameworkCore;

namespace Utilities
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(
            DbContextOptions<ExampleDbContext> dbContextOptions
            ) : base(dbContextOptions)
        {
            var databaseFactory = new DatabaseFactory();
            ConnectionString = databaseFactory.GetConnectionStringByDatabase(DatabaseType.Postgres);
        }

        private readonly string ConnectionString = string.Empty;

        public DbSet<User> Users { get; set; }

        public DbSet<EncryptionConfiguration> EncryptionConfigurations { get; set; }

        /// <summary>
        /// Call Postgres function to retrieve all user records
        /// Note that we need some other way to decrypt the records returned from this method
        /// The EncryptedConverter does not work for the mapped field results returned from database this way
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers() =>
            [.. Database.SqlQueryRaw<User>("select * from GET_ALL_USERS()")];

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("encryptexample");

            string encryptionKey = EncryptionHelper.GenerateRandomKey(256); // Create a random encryption key and save it for the values being saved in database
            modelBuilder.UseEncryption(encryptionKey, this);
        }
    }
}
