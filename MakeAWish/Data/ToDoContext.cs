using MakeAWish.DataConfig;
using MakeAWish.Models;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MakeAWish.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoModel> ToDoList { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        public ToDoContext() : base(GetConnection(), false)
        {
            Database.SetInitializer<ToDoContext>(null);
        }

        public static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["SQLiteConnection"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connection.ConnectionString;
            return dbCon;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ToDoConfig());
            base.OnModelCreating(modelBuilder);
        }

    }
}