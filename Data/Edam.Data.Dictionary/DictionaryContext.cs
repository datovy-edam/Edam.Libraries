using Microsoft.EntityFrameworkCore;

namespace Edam.Data.Dictionary
{

   public class DictionaryContext : DbContext
   {

      public DbSet<WordInfo> Word { get; set; }
      public DbSet<TermInfo> Term { get; set; }
      public DbSet<WordQueueInfo> WordQueue { get; set; }

      public string ConnectionString { get; }

      public DictionaryContext()
      {
         ConnectionString = DictionaryContextHelper.GetConnectionString();
      }

      public DictionaryContext(string connectionString)
      {
         ConnectionString = connectionString;
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // Configure default schema
         modelBuilder.HasDefaultSchema("Dictionary");
      }

      // Configures EF to create an SQL database using given connection string
      protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer(ConnectionString);

   }

}
